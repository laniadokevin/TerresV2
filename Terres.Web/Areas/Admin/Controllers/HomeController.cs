using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Terres.Core.Entities.Database;
using Terres.Core.OLD.Entities.ViewModel.Lotes;
using Terres.Web.Models.OLD;
using Microsoft.AspNetCore.Identity;
using Terres.Core.Interfaces;

namespace Terres.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Home")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class HomeController : Controller
    {

        private readonly ILoteRepository _loteRepository;
        private readonly ICsvFactibilidadService _csvFactibilidadService;

        private readonly UserManager<JojmaUser> _userManager;

        public HomeController(ICsvFactibilidadService csvFactibilidadService,ILoteRepository loteRepository, UserManager<JojmaUser> userManager)
        {
            _csvFactibilidadService = csvFactibilidadService;
            _loteRepository = loteRepository;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("UploadCSVFactibilidad")]
        public IActionResult UploadCSVFactibilidad()
        {
            return View();
           
        }

        [Route("UploadCSVFactibilidad")]
        [HttpPost]
        public async Task<IActionResult> UploadCsvAsync([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Archivo no válido.");
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", file.FileName);

            try
            {
                // Guardar el archivo temporalmente
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Procesar el CSV
                var result = await _csvFactibilidadService.ProcessCsvFactibilidadAsync(filePath);

                if (result)
                {
                    return RedirectToAction("Lotes");
                    return Ok("Archivo procesado exitosamente.");

                }
                else
                {
                    return StatusCode(500, "Error al procesar el archivo.");

                }
            }
            finally
            {
                // Eliminar el archivo temporal
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }
        }

        [HttpGet]
        [Route("~/Admin")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [Route("Lotes")]
        public IActionResult Lotes(string searchText, int tipoLote)
        {
            ViewBag.SearchText = searchText;
            ViewBag.TipoLoteId = tipoLote;

            AdminViewModel adminViewModel = new();

            List<Lote> lotes = _loteRepository.GetAllLotesByFilters(searchText, tipoLote);
            List<TipoLote> tipoLotes = _loteRepository.GetAllTipoLotes();

            List<LoteDto> lotesDto = lotes.Select(lote => new LoteDto
            {
                Id = lote.Id,
                Direccion = lote.Direccion,
                TipoLoteId = lote.TipoLoteId,
                TipoLote = lote.TipoLote
            }).ToList();

            List<TipoLoteDto> tipoLoteDtos = tipoLotes.Select(lote => new TipoLoteDto
            {
                Id = lote.Id,
                Nombre = lote.Nombre
            }).ToList();

            adminViewModel.Lotes = lotesDto;
            adminViewModel.TiposLote = tipoLoteDtos;

            return View(adminViewModel);
        }

        [HttpGet]
        [Route("Usuarios")]
        public IActionResult Usuarios(string searchText)
        {
            ViewBag.SearchText = searchText;

            AdminUsersViewModel adminViewModel = new();

            List<JojmaUser> users =_userManager.Users.Where(x=>x.Email.Contains(searchText)).ToList();
              adminViewModel.Users = users;


            return View(adminViewModel);
        }
    }
}