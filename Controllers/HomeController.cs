using Microsoft.AspNetCore.Mvc;
using Net6AddressBook.Models;
using System.Diagnostics;

namespace Net6AddressBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("/Home/HandleError/{code:int}")]
        public IActionResult HandleError(int code)
        {
            var customError = new CustomError();

            customError.code = code;

            if (code == 404)
            {
                customError.message = "The page you are looking for might have been removed, had it's name changed, or is temorarily unavailable";
                //Could use custom view for each different error by returning view here
                //Example: return View("~/Views/Shared/CustomError.cshtml",customError);
            }
            else
            {
                customError.message = "Sorry, something went wrong";
            }

            return View("~/Views/Shared/CustomError.cshtml",customError);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}