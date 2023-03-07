using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
