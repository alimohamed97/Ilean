using Microsoft.AspNetCore.Mvc;

namespace Presentation.Portal.Controllers
{
    public class A3ApplicationController : Controller
    {

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
