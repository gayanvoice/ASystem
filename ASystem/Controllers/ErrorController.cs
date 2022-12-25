using ASystem.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace ASystem.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Show(ErrorViewModel errorViewModel)
        {
            return View(errorViewModel);
        }
    }
}