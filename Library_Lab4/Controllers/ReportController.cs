using Microsoft.AspNetCore.Mvc;

namespace Library_Lab4.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
