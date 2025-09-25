using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ObstacleController : Controller
    {

        [HttpGet]
        public ActionResult DataForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DataForm(ObstacleData obstacleData)
        {
            if (!ModelState.IsValid)
            {
                return View(obstacleData);
            }
            return View("Overview", obstacleData);
        }
    }
}
