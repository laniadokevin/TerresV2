using Microsoft.AspNetCore.Mvc;
using Terres.Core.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Terres.Core.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security;
using Newtonsoft.Json;
using Terres.Web.Models.OLD;
using Terres.Core.OLD.Entities.ViewModel.Campus;
using Terres.Core.OLD.Entities.ViewModel.Lotes;
using Microsoft.AspNetCore.Identity;
using Terres.Core.Entities.Database;
using Terres.Core.Entities.Generic;

namespace Terres.Web.Areas.Web.Controllers
{
    [Area("Web")]
    [Route("/Account")]
    public class AccountController : Controller
    {

        private readonly ILoteRepository _loteRepository;
        private readonly ILogRepository _logRepository;
        private readonly IMailService _mail;

        private readonly SignInManager<JojmaUser> _signInManager;
        private readonly UserManager<JojmaUser> _userManager;


        public AccountController(ILogRepository logRepository,
            IMailService mail, ILoteRepository loteRepository, SignInManager<JojmaUser> signInManager, UserManager<JojmaUser> userManager)
        {
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _loteRepository = loteRepository ?? throw new ArgumentNullException(nameof(loteRepository));
            _logRepository = logRepository ?? throw new ArgumentNullException(nameof(logRepository));
            _mail = mail ?? throw new ArgumentNullException(nameof(mail));
        }

        [Route("~/Account/Dashboard")]
        public async Task<IActionResult> DashboardAsync()
        {
            try
            {
                var user = await _userManager.GetUserAsync(User); // Obtiene el usuario actual.

				DashboardViewModel view = new DashboardViewModel();

                view.Lotes = _loteRepository.GetAllLotes(user.Id);
                view.User = user;

                return View(view);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Account");
            }
        }

        //[Authorize(Roles = "SuperAdmin, Operador, Vendedor,Cliente")]
        [Route("~/Account/Actividad")]
        public async Task<IActionResult> ActividadAsync()
        {
            try
            {
                DashboardViewModel view = new DashboardViewModel();

                var user = await _userManager.GetUserAsync(User); // Obtiene el usuario actual.
                var remoteIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();

                view.Lotes = _loteRepository.GetAllLotes(user.Id);
                view.User = user;


                return View(view);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Account");
            }
        }

        //[Authorize(Roles = "SuperAdmin, Operador, Vendedor,Cliente")]
        //[Authorize]
        [Route("~/Account/Perfil")]
        public async Task<IActionResult> PerfilAsync()
        {
            try
            {
                PerfilViewModel perfilViewModel = new PerfilViewModel();
                var user = await _userManager.GetUserAsync(User);

                perfilViewModel.User = user;

                return View(perfilViewModel);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Account");
            }
        }

        [HttpGet]
        [Route("~/Account/Login")]
        public IActionResult Login()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Account");
            }
        }

        [HttpPost]
        [Route("~/Account/Login")]

        public async Task<IActionResult> Login(string email, string password)
        {
			var user = new JojmaUser { UserName = email, Email = email, Name = "Kevin",PasswordHash = password };

			await _signInManager.SignInAsync(user, isPersistent: false);


			var resultLogin = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);

			if (resultLogin.Succeeded)
			{
				return RedirectToAction("Dashboard", "Account");
			}

			ModelState.AddModelError("", "Invalid login attempt.");
			return View();
			/*
            User user = AuthenticateUser(username, password);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(username, password, false, lockoutOnFailure: false);

                // Inicia la sesión del usuario
             //   await _securityManager.SignIn(HttpContext, user);

                // Redirige a la página de inicio después de un login exitoso
                return RedirectToAction("Dashboard", "Account");
            }

            // Si la autenticación falla, muestra un mensaje de error
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View();
            */
		}


        [Route("~/Account/Register")]
        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        [Route("~/Account/Register")]
        public async Task<IActionResult> Register(string email, string password)
        {
            var user = new JojmaUser { UserName = email, Email = email, Name = "Kevin" };
            var result = await _userManager.CreateAsync(user, password);
            var result2 = await _userManager.AddToRoleAsync(user, "Vendedor");

            if (result.Succeeded && result2.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);


                var resultLogin = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);

                if (resultLogin.Succeeded)
                {
                    return RedirectToAction("Dashboard", "Account");
                }

                ModelState.AddModelError("", "Invalid login attempt.");
                return View();



            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View();
        }
        /*
        [HttpPost]
        [Route("~/Account/Register")]
        public async Task<IActionResult> RegisterAsync(string username = "", string password = "")
        {
            bool emailExistente = _userRepository.emailExist(username);
            if (emailExistente)
            {
                ViewBag.error = "Email Existente";
                return View("Register");
            }

            User user = new User();
            user.Email = username;
            user.DateAdded = DateTime.Now;
            //user.DireccionIP = HttpContext.Connection.RemoteIpAddress.ToString();
            user.Password = BCrypt.Net.BCrypt.HashPassword(password);

            _userRepository.createUser(user);

            UserRole userRole = new UserRole();

            userRole.UserId = user.Id;
            userRole.RoleId = 3;

            _userRoleRepository.InsertOrUpdateUserRole(userRole);
            user.UserRoles.FirstOrDefault().Role = new Role();
            user.UserRoles.FirstOrDefault().Role.Name = "Vendedor";
            user.UserRoles.FirstOrDefault().Role.Id = 3;

            var result = await _signInManager.PasswordSignInAsync(username, password, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return RedirectToAction("Dashboard", "Account");
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View();

        }
        */
        
        [HttpGet]
        [Route("~/Account/validateEmailExists")]
        public IActionResult validateEmailExists(string email = "")
        {
            var user = _userManager.FindByEmailAsync(email).Result;

            bool emailExistente =  user != null;

            if (emailExistente)
            {
                return Ok(JsonConvert.SerializeObject(new { email, data = true }));
            }
            else
                return Ok(JsonConvert.SerializeObject(new { email, data = false }));

        }
        


        [Route("~/Account/ForgotPwd")]
        public IActionResult ForgotPwd()
        {

            return View("ForgotPwd");
        }
        /*
        [HttpPost]
        [Route("~/Account/ForgotPwdPost")]
        public async Task<IActionResult> ForgotPwdPostAsync(string email)
        {

            //Send Email

            var checkEmail = _userRepository.CheckEmailDisponibility(email);
            if (checkEmail)
            {
                //Create random Password
                var newPassword = "";
                _userRepository.UpdatePwd(email, newPassword);

                MailData mailData = new MailData();

                mailData.To = email;
                mailData.Cc = "cursocresimed@gmail.com";
                mailData.ReplyTo = "Cresimed";
                mailData.ReplyToName = "replyToName";
                mailData.Subject = "Recuperación de contraseña de su cuenta Cresimed";
                //mailData.Body = $"Hola, le hemos enviado este correo para ayudarlo a recuperar su contraseña. Su contraseña es: {checkUser.Password}";
                //mailData.Body = $"Hola, le hemos enviado este correo para ayudarlo a recuperar su contraseña. Su contraseña temporal es: {newPassword} Si lo desea, puede cambiar la contraseña dentro del sistema.";
                mailData.Body = $"¡Hola!<br><br>Solicitaste recuperar tu contraseña.<br><br>Tu nueva contraseña es: {newPassword}<br>Si lo desea, puede cambiar la contraseña dentro del sistema.<br><br>Saludos cordiales,<br>El equipo de Cresimed";

                bool result = await _mail.SendAsync(mailData, new CancellationToken());

                if (result)
                {
                    ViewBag.mensaje = "El correo electrónico se ha enviado correctamente. Por favor, revise su bandeja de entrada.";
                    return View("Index");
                }
                else
                {
                    ViewBag.error = "No se pudo enviar el correo. Por favor, inténtelo de nuevo más tarde.";
                }
            }
            else
                ViewBag.error = "El mail ingresado no corresponde a ningun usuario";

            //return View();
            return View("ForgotPwd");
        }
        */
        /*
        [HttpPost]
        [Authorize(Roles = "SuperAdmin, Operador, Vendedor,Cliente")]
        [Route("~/Account/ResetPwd")]
        public IActionResult ResetPwd(string password)
        {
            var pre = _userRepository.GetUserById(int.Parse(User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(c => c.Value).SingleOrDefault()));

            if (pre != null)
            {
                pre.Password = BCrypt.Net.BCrypt.HashPassword(password);

                //var user = _userRepository.UpdateUser(pre);

                return RedirectToAction("Welcome");
            }
            else
                return View("AccessDenied");

        }
        */
        [HttpGet]
        [Authorize(Roles = "SuperAdmin, Operador, Vendedor,Cliente")]
        [Route("~/Account/ResetPwd")]
        public IActionResult ResetPwd()
        {

            return View("ResetPwd");
        }

        [Route("~/Account/accessdenied")]
        public IActionResult AccessDenied()
        {
            ViewBag.error = "Access Denied";
            return RedirectToAction("Index", "Account");

        }


        [Route("~/Account/SignOut")]
        public async Task<IActionResult> SignOutAsync()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("~/Account/sendmail")]
        public async Task<IActionResult> SendMailAsync()
        {

            MailData mailData = new MailData();

            mailData.To = "cursocresimed@gmail.com";
            //mailData.Cc = "laniadokevin@gmail.com";
            mailData.Cc = "raisbergm@gmail.com";
            mailData.ReplyTo = "Cresimed";
            mailData.ReplyToName = "replyToName";
            mailData.Subject = "Suscripcion a Cresimed";
            mailData.Body = "Hola - this is just a test to verify that our mailing works. Have a great day!";

            bool result = await _mail.SendAsync(mailData, new CancellationToken());

            if (result)
            {
                return StatusCode(StatusCodes.Status200OK, "Mail has successfully been sent.");
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured. The Mail could not be sent.");
            }
        }


    }
}
