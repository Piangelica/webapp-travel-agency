using Microsoft.AspNetCore.Mvc;


namespace WebApp_TravelAgency.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string SearchString)
        {
            return View();
        }

    }
}