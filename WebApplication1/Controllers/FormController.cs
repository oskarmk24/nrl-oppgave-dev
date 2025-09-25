using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class FormController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
