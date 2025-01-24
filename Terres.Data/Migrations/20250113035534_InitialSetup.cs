using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Terres.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseLotes",
                columns: table => new
                {
                    SMP = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SM = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Barrio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Superficieedificada = table.Column<double>(name: "Superficie edificada", type: "float", nullable: true),
                    Superficieparcela = table.Column<double>(name: "Superficie parcela", type: "float", nullable: true),
                    Frente = table.Column<double>(type: "float", nullable: true),
                    Fondo = table.Column<double>(type: "float", nullable: true),
                    Valorincidenciadesuelo = table.Column<double>(name: "Valor incidencia de suelo", type: "float", nullable: true),
                    Alicuotadiferencialporzona = table.Column<double>(name: "Alicuota diferencial por zona", type: "float", nullable: true),
                    Lineainterna = table.Column<double>(name: "Linea interna", type: "float", nullable: true),
                    SEdificableB = table.Column<string>(name: "S#Edificable - B", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SEdificableCP = table.Column<string>(name: "S#Edificable - CP", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SEdificableR1 = table.Column<string>(name: "S#Edificable - R1", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SEdificableR2 = table.Column<string>(name: "S#Edificable - R2", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Posicionmanzana = table.Column<string>(name: "Posicion manzana", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Unidad = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Altura = table.Column<double>(type: "float", nullable: true),
                    Areaespecialagrupada = table.Column<string>(name: "Area especial agrupada", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Areaespecialindividualizada = table.Column<string>(name: "Area especial individualizada", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DistritosegunAE = table.Column<string>(name: "Distrito segun AE", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AEFOT = table.Column<double>(name: "AE FOT", type: "float", nullable: true),
                    Mixtura = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DistritoCPU = table.Column<string>(name: "Distrito CPU", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AlturaCPU = table.Column<double>(name: "Altura CPU", type: "float", nullable: true),
                    FOT = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Lineaespecialparticularizada = table.Column<string>(name: "Linea especial particularizada", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Tipomanzana = table.Column<string>(name: "Tipo manzana", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Catalogacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Proteccion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Ley3056EdificioAnteriorA1941 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Consolidado = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Pisosregistrados = table.Column<double>(name: "Pisos registrados", type: "float", nullable: true),
                    Cantidaddeunidades = table.Column<double>(name: "Cantidad de unidades", type: "float", nullable: true),
                    CuartilMin = table.Column<double>(name: "Cuartil - Min", type: "float", nullable: true),
                    Cuartil1 = table.Column<double>(name: "Cuartil - 1", type: "float", nullable: true),
                    Cuartil2 = table.Column<double>(name: "Cuartil - 2", type: "float", nullable: true),
                    Cuartil3 = table.Column<double>(name: "Cuartil - 3", type: "float", nullable: true),
                    Cuartil4 = table.Column<double>(name: "Cuartil - 4", type: "float", nullable: true),
                    CuartilLote = table.Column<string>(name: "Cuartil - Lote", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    centroide = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    smp_anterior = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    smp_siguiente = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    pdamatriz = table.Column<double>(type: "float", nullable: true),
                    superficie_total = table.Column<double>(type: "float", nullable: true),
                    superficie_cubierta = table.Column<double>(type: "float", nullable: true),
                    frentesegunMBA = table.Column<double>(name: "frente segun MBA", type: "float", nullable: true),
                    fondosegunMBA = table.Column<double>(name: "fondo segun MBA", type: "float", nullable: true),
                    propiedad_horizontal = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    pisos_bajo_rasante = table.Column<double>(type: "float", nullable: true),
                    pisos_sobre_rasante = table.Column<double>(type: "float", nullable: true),
                    unidades_funcionales = table.Column<double>(type: "float", nullable: true),
                    cantidad_puertas = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    LogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lvl = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.LogID);
                });

            migrationBuilder.CreateTable(
                name: "TipoLote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoLote", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoLoteId = table.Column<int>(type: "int", nullable: false),
                    SMP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lote_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Lote_TipoLote_TipoLoteId",
                        column: x => x.TipoLoteId,
                        principalTable: "TipoLote",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Lote_TipoLoteId",
                table: "Lote",
                column: "TipoLoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Lote_UserId",
                table: "Lote",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BaseLotes");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "Lote");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TipoLote");
        }
    }
}
