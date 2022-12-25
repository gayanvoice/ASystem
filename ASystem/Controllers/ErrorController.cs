using ASystem.Helper;
using ASystem.Models.View;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ASystem.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Show(int code, string controller, string action)
        {
            ErrorViewModel.Url url = new ErrorViewModel.Url();
            url.Controller = controller;
            url.Action = action;
            IEnumerable<ErrorViewModel> errorViewModelIEnumerable = ErrorHelper.GetIEnumerableErrorViewModel(url);
            ErrorViewModel errorViewModel = errorViewModelIEnumerable.FirstOrDefault(errorViewModel => errorViewModel.Code.Equals(code));
            return View(errorViewModel);
        }
    }
}