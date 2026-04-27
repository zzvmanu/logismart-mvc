using Microsoft.AspNetCore.Mvc;

namespace LogiSmartMVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
