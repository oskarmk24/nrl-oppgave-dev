using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using MySqlConnector;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Controller responsible for handling requests to the Home section of the application. 
    /// Includes actions for Index, Privacy, and Error pages.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class. 
        /// Retrieves the database connection string from configuration settings.
        /// </summary>
        /// <param name="config">The application configuration that provides connection strings.</param>
        public HomeController(IConfiguration config)
        {
            connectionString = config.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// Attempts to establish a connection with the MariaDB database. 
        /// If successful, returns a success message to the Index view. 
        /// If unsuccessful, returns a failure message with the exception details.
        /// </summary>
        /// <returns>
        /// An asynchronous <see cref="Task{IActionResult}"/> that renders the Index view 
        /// with either a success or failure message as the model.
        /// </returns>
        public async Task<IActionResult> Index()
        {
            string viewModel1 = "Connected to MariaDB successfully!";
            string viewModel2 = "Failed to connect to MariaDB.";
            try
            {
                await using var conn = new MySqlConnection(connectionString);
                await conn.OpenAsync();
                return View("Index", viewModel1);
            }
            catch (Exception ex)
            {
                return View("Index", viewModel2 + " " + ex.Message);
            }
        }

        /// <summary>
        /// Displays the Privacy view of the application.
        /// </summary>
        /// <returns>
        /// An <see cref="IActionResult"/> that renders the Privacy view.
        /// </returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Displays the Error view containing details about the current request error. 
        /// Includes the Request ID for debugging purposes.
        /// </summary>
        /// <returns>
        /// An <see cref="IActionResult"/> that renders the Error view with an <see cref="ErrorViewModel"/>.
        /// </returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
