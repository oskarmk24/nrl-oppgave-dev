using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class ObstacleController : Controller
    {
        private readonly ReportsRepository _repo;   // <-- injected repo

        public ObstacleController(ReportsRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public ActionResult DataForm()
        {
            return View();
        }

        /*[HttpPost]
        public ActionResult DataForm(ObstacleData obstacleData)
        {
            if (!ModelState.IsValid)
            {
                return View(obstacleData);
            }
            return View("Overview", obstacleData);
        }
        */

        [HttpPost]
        public async Task<IActionResult> DataForm(ObstacleData obstacleData)
        {
            if (!ModelState.IsValid)
            {
                return View(obstacleData);
            }

            try
            {
                // Save to obstacledb.reports (Dapper)
                int newId = await _repo.CreateAsync(
                    obstacleData.ObstacleName,
                    obstacleData.ObstacleHeight,      // DECIMAL(10,0)
                    obstacleData.ObstacleDescription,
                    obstacleData.ObstacleLocation      // Leaflet JSON from hidden input
                );

                ViewBag.SavedReportId = newId;
                TempData["Success"] = "Report saved with ID " + newId;
            }
            catch (System.Exception ex)
            {
                // Show a friendly error and stay on the form
                ModelState.AddModelError(string.Empty, "Database error: " + ex.Message);
                return View(obstacleData);
            }

            // Show summary page after save
            return View("Overview", obstacleData);
        }
    }
}
