using Microsoft.AspNetCore.Mvc;

namespace Api_SIDCOP.API.Controllers.General
{
    public class DireccionesPorClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
