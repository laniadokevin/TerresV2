using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Terres.Core.Interfaces;
using Terres.Web.Models;
using Terres.Web.Models.OLD;

namespace Terres.Web.Areas.Web.Controllers
{
    [Area("Web")]
    [Route("/Home")]
    public class HomeController : Controller
    {

        private readonly ILoteRepository _loteRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogRepository _logRepository;
        private readonly IMailService _mail;


        public HomeController(IUserRepository userRepository, 
            ILogRepository logRepository,
            IMailService mail, ILoteRepository loteRepository)
        {
            _loteRepository = loteRepository ?? throw new ArgumentNullException(nameof(loteRepository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _logRepository = logRepository ?? throw new ArgumentNullException(nameof(logRepository));
            _mail = mail ?? throw new ArgumentNullException(nameof(mail));
        }

        [Route("~/")]
        [Route("~/Home")]
        [Route("~/Home/Index")]
        public IActionResult Index()
        {
            AccountViewModel accountViewModel = new();

            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }

            var tipoLotes = _loteRepository.GetAllTipoLotes();

            var lotesViewModel = tipoLotes.Select(l => new TipoLoteDto
            {
                Id = l.Id,
                Nombre = l.Nombre
            }).ToList();

            accountViewModel.TipoLotes = lotesViewModel;
            var isLogged = User.Identity.IsAuthenticated;


            return View(accountViewModel);
        }


        [Route("~/Home/About")]
        public IActionResult About()
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
        [Route("~/Home/Test")]
        public IActionResult Test()
        {

            return View("Test");

        }

    }
}