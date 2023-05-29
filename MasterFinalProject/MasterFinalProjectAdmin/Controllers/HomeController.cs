using Microsoft.AspNetCore.Mvc;

namespace MasterFinalProjectAdmin.Controllers
{

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
