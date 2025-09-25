using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using MySqlConnector;


namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly string connectionString;

        public HomeController(IConfiguration config)
        {
            connectionString = config.GetConnectionString("DefaultConnection");
        }

        public async Task<IActionResult> Index()
        {
            string viewModel1 = "Connected to MariaDB successfully!";
            string viewModel2 = "Failed to connect to MariaDB.";
            try
            {
                await using var conn = new MySqlConnection(connectionString);
                await conn.OpenAsync();
                //Return Content("Connected to MariaDB successfully!");
                return View("Index", viewModel1);
            }
            catch (Exception ex)
            {
                //Return Content("Failed to connect to MariaDB. Error: " + ex.Message);
                return View("Index", viewModel2+" "+ex.Message);
            }
        }

       

        // Pass the list of
        // public HomeController(ILogger<HomeController> logger)
        //{
        //_logger = logger;
        //}

        /*[HttpGet]
        public ActionResult DataForm()
        {             
            return View();
        }

        [HttpPost]
        public ActionResult DataForm(ObstacleData obstacleData)
        {
            return View("Overview", obstacleData);
        }
        */
        //public IActionResult Index()
        //{
            //return View();
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
