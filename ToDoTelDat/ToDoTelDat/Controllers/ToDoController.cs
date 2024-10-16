using Microsoft.AspNetCore.Mvc;

namespace ToDoTelDat.Controllers
{
    public class ToDoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
