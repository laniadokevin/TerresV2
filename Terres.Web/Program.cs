using Terres.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Terres.Core.Interfaces;
using Terres.Web.Areas.Web.Controllers;
using Terres.Data.OLD.Repositories;
using Terres.Core.Entities.Database;
using Terres.Core.Entities.Generic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<JojmaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).UseLazyLoadingProxies());

builder.Services.AddIdentity<JojmaUser, IdentityRole>()
    .AddEntityFrameworkStores<JojmaDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Events.OnRedirectToLogin = context =>
    {
        var requestPath = context.Request.Path.ToString();

        // Redirige a diferentes logins según el área
        if (requestPath.StartsWith("/Admin", StringComparison.OrdinalIgnoreCase))
        {
            context.Response.Redirect("/Admin/AdminAccount/Login");
        }
        else
        {
            context.Response.Redirect("/Web/WebAccount/Login");
        }
        return Task.CompletedTask;
    };

    options.Events.OnRedirectToAccessDenied = context =>
    {
        var requestPath = context.Request.Path.ToString();

        // Redirige a diferentes logins según el área
        if (requestPath.StartsWith("/Admin", StringComparison.OrdinalIgnoreCase))
        {
            context.Response.Redirect("/Admin/AdminAccount/AccessDenied");
        }
        else
        {
            context.Response.Redirect("/Web/WebAccount/AccessDenied");
        }
        return Task.CompletedTask;
    };
});


// Configuración de servicios
builder.Services.AddScoped<ILoteRepository, LoteRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ILogRepository, LogRepository>();

// Configuración de clientes HTTP
builder.Services.AddHttpClient();

// Configuración de envío de correos
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection(nameof(MailSettings)));
builder.Services.AddTransient<IMailService, MailService>();
builder.Services.AddTransient<IUsigNormalizador, UsigNormalizadorService>();
builder.Services.AddTransient<ICsvFactibilidadService,CsvFactibilidadService>();


var app = builder.Build();

// Crear usuarios y roles de prueba
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<JojmaUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    // Crear roles
    if (!await roleManager.RoleExistsAsync("SuperAdmin"))
    {
        await roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
    }
    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }

    if (!await roleManager.RoleExistsAsync("User"))
    {
        await roleManager.CreateAsync(new IdentityRole("User"));
    }

    if (!await roleManager.RoleExistsAsync("Vendedor"))
    {
        await roleManager.CreateAsync(new IdentityRole("Vendedor"));
    }

    if (!await roleManager.RoleExistsAsync("Comprador"))
    {
        await roleManager.CreateAsync(new IdentityRole("Comprador"));
    }

    // Crear usuario administrador
    var adminUser = await userManager.FindByEmailAsync("admin@example.com");
    if (adminUser == null)
    {
        adminUser = new JojmaUser { UserName = "admin@example.com", Email = "admin@example.com" ,Name = "Admin"};
        await userManager.CreateAsync(adminUser, "Admin123!");
        await userManager.AddToRoleAsync(adminUser, "Admin");
    }

    // Crear usuario regular
    var webUser = await userManager.FindByEmailAsync("user@example.com");
    if (webUser == null)
    {
        webUser = new JojmaUser { UserName = "user@example.com", Email = "user@example.com", Name = "User" };
        await userManager.CreateAsync(webUser, "User123!");
        await userManager.AddToRoleAsync(webUser, "User");
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();

}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapDefaultControllerRoute();

app.Run();