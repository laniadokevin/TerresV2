using Terres.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Terres.Core.Interfaces;
using System.Security;
using Terres.Web.Models.OLD;
using Terres.Core.OLD.Entities.ViewModel.Lotes;
using Microsoft.AspNetCore.Identity;
using Terres.Core.Entities.Database;
namespace Terres.Web.Areas.Web.Controllers
{
    [Area("Web")]
    [Route("/Lote")]
    public class LoteController : Controller
    {
        private readonly ILoteRepository _loteRepository;
        private readonly IUsigNormalizador _usigNormalizador;
        private readonly IUserRepository _userRepository;
        private readonly ICsvFactibilidadService _csvFactibilidadService;

        private readonly SignInManager<JojmaUser> _signInManager;
        private readonly UserManager<JojmaUser> _userManager;

        public LoteController(ILoteRepository loteRepository, IUsigNormalizador usigNormalizador, IUserRepository userRepository, SignInManager<JojmaUser> signInManager, UserManager<JojmaUser> userManager, ICsvFactibilidadService csvFactibilidadService)
        {
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _loteRepository = loteRepository ?? throw new ArgumentNullException(nameof(loteRepository));
            _usigNormalizador = usigNormalizador ?? throw new ArgumentNullException(nameof(usigNormalizador));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _csvFactibilidadService = csvFactibilidadService;
        }

        [Route("Create")]
        public ActionResult Create()
        {
            AccountViewModel accountViewModel = new();

            var tipoLotes = _loteRepository.GetAllTipoLotes();

            var lotesViewModel = tipoLotes.Select(l => new TipoLoteDto
            {
                Id = l.Id,
                Nombre = l.Nombre
            }).ToList();

            accountViewModel.TipoLotes = lotesViewModel;
            accountViewModel.isLogged = User.Identity.IsAuthenticated;

            return View(accountViewModel);
        }

        [Route("Detail")]
        public ActionResult Detalle(int id)
        {
            LoteDetalleViewModel loteDetalleViewModel = new LoteDetalleViewModel();

            Lote lote = _loteRepository.GetLoteById(id);

            if (lote.SMP == "")
            {
                var coordenadas = _usigNormalizador.ObtenerCoordenadas(SepararDireccion(lote.Direccion));
                var smp = "0" + coordenadas.Parcela;

                lote.SMP = smp;

                Lote nuevoLote = _loteRepository.SaveLote(lote);


            }
            BaseLotes loteDetalle = _loteRepository.GetLoteDetalle(lote.SMP);
            loteDetalleViewModel.Lote = lote;
            loteDetalleViewModel.DetalleLote = loteDetalle;

            return View(loteDetalleViewModel);
        }



        [Route("Potencial")]
        public ActionResult Potencial(int id)
        {
            LoteDetalleViewModel loteDetalleViewModel = new LoteDetalleViewModel();

            Lote lote = _loteRepository.GetLoteById(id);

            if (lote.SMP == "")
            {
                var coordenadas = _usigNormalizador.ObtenerCoordenadas(SepararDireccion(lote.Direccion));
                var smp = "0" + coordenadas.Parcela;

                lote.SMP = smp;

                Lote nuevoLote = _loteRepository.SaveLote(lote);


            }
            BaseLotes loteDetalle = _loteRepository.GetLoteDetalle(lote.SMP);
            loteDetalleViewModel.Lote = lote;
            loteDetalleViewModel.DetalleLote = loteDetalle;

            return View(loteDetalleViewModel);
        }

        [Route("Precio")]
        public ActionResult Precio(int id)
        {
            LoteDetalleViewModel loteDetalleViewModel = new LoteDetalleViewModel();

            Lote lote = _loteRepository.GetLoteById(id);
            var precio = _csvFactibilidadService.GetAll().FirstOrDefault();

            if (lote.SMP == "")
            {
                var coordenadas = _usigNormalizador.ObtenerCoordenadas(SepararDireccion(lote.Direccion));
                var smp = "0" + coordenadas.Parcela;

                lote.SMP = smp;

                Lote nuevoLote = _loteRepository.SaveLote(lote);


            }
            BaseLotes loteDetalle = _loteRepository.GetLoteDetalle(lote.SMP);
            loteDetalleViewModel.Lote = lote;
            loteDetalleViewModel.DetalleLote = loteDetalle;
            loteDetalleViewModel.CSVFactibilidad = precio;

            return View(loteDetalleViewModel);
        }


        [Route("Create")]
        [HttpPost]
        public async Task<JsonResult> CreateAsync([FromBody] LoteDto dto)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);

                if (user == null)
                {

                    bool emailExistente = _userRepository.emailExist(dto.Email);
                    if (emailExistente)
                    {

                        var resultLogin = await _signInManager.PasswordSignInAsync(dto.Email, dto.Password, false, lockoutOnFailure: false);

                        if (!resultLogin.Succeeded)
                        {
                            ModelState.AddModelError("", "Invalid login attempt.");
                            return Json(new { success = false, message = "clave invalida" });
                            var userDto = new JojmaUser() {Email = dto.Email, PasswordHash = dto.Password }; 
                            await _signInManager.SignInAsync(userDto, isPersistent: false);
                        }

                    }
                    else
                    {
                        user = await userCreationAsync(dto);
                        await _signInManager.SignInAsync(user, isPersistent: false);
                    }

                }
                var coordenadas = new DireccionBA();
                try
                {
                    coordenadas = _usigNormalizador.ObtenerCoordenadas(SepararDireccion(dto.Direccion));
                }
                catch (Exception ex)
                {

                }


                Lote lote = new();
                lote.Direccion = dto.Direccion;
                lote.SMP = coordenadas.Parcela != null ? "0" + coordenadas.Parcela : "";

                lote.UserId = _userManager.GetUserAsync(User).Result.Id;
                lote.TipoLoteId = dto.TipoLoteId;

                Lote nuevoLote = _loteRepository.SaveLote(lote);


                // Procesa los datos
                return Json(new { success = true, message = "Lote creado correctamente" });
            }
            catch
            {
                return Json(new { success = false, message = "Error al crear el lote" });
            }
        }

        private async Task<JojmaUser> userCreationAsync(LoteDto dto)
        {

            var user = new JojmaUser { UserName = dto.Email, Email = dto.Email };
            var result = await _userManager.CreateAsync(user, dto.Password);
            var result2 = await _userManager.AddToRoleAsync(user, "Vendedor");

            if (result.Succeeded && result2.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);


            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return user;
        }


        [Route("Normalizar")]
        public async Task<IActionResult> NormalizarDireccion([FromQuery] string direccion)
        {

            if (string.IsNullOrWhiteSpace(direccion))
            {
                return BadRequest(new { success = false, message = "La dirección es requerida." });
            }

            try
            {
                string direccionNormalizada = _usigNormalizador.NormalizarDireccion(direccion);


                if (!string.IsNullOrEmpty(direccionNormalizada) && direccionNormalizada != "No se pudo normalizar la dirección.")
                {
                    var coordenadas = _usigNormalizador.ObtenerCoordenadas(SepararDireccion(direccionNormalizada));
                    var smp = "0" + coordenadas.Parcela;

                    return Ok(new { success = true, smp });
                }
                else
                {
                    direccionNormalizada = direccion;
                    return Ok(new { success = true, direccionNormalizada });

                    //return Ok(new { success = false, message = "No se pudo normalizar la dirección." });
                }
            }
            catch (Exception ex)
            {
                string direccionNormalizada = direccion;
                return Ok(new { success = true, direccionNormalizada });
                //return StatusCode(500, new { success = false, message = "Error al procesar la solicitud.", details = ex.Message });
            }
        }


        [Route("GetSMP")]
        public async Task<IActionResult> GetSMP([FromQuery] string direccion)
        {

            if (string.IsNullOrWhiteSpace(direccion))
            {
                return BadRequest(new { success = false, message = "La dirección es requerida." });
            }

            try
            {
                var coordenadas = _usigNormalizador.ObtenerCoordenadas(SepararDireccion(direccion));
                var smp = "0" + coordenadas.Parcela;

                return Ok(new { success = true, smp });

            }
            catch (Exception ex)
            {
                string direccionNormalizada = direccion;
                return Ok(new { success = true, direccionNormalizada });
                //return StatusCode(500, new { success = false, message = "Error al procesar la solicitud.", details = ex.Message });
            }
        }




        static LoteBA SepararDireccion(string direccion)
        {
            // Expresión regular para extraer partes de la dirección
            string patron = @"^(.+?)\s+(\d+)";
            var match = Regex.Match(direccion, patron);

            LoteBA l = new LoteBA();
            if (match.Success)
            {
                string calle = match.Groups[1].Value;
                int num = int.Parse(match.Groups[2].Value);
                string localidad = match.Groups[3].Value;
                l.calle = calle;
                l.localidad = localidad;
                l.numero = num;
                return l;
            }

            return l;
        }



    }
}
