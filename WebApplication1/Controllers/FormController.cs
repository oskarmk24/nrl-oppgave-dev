using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Controller responsible for handling requests related to the form.
    /// </summary>
    public class FormController : Controller
    {
        /// <summary>
        /// Handles GET requests to the Index page of the form. 
        /// Returns the default view associated with this action.
        /// </summary>
        /// <returns>
        /// An <see cref="IActionResult"/> that renders the Index view.
        /// </returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
