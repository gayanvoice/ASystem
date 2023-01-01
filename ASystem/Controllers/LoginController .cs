using System;
using ASystem.Context;
using ASystem.Enum.User;
using ASystem.Models.Context;
using ASystem.Models.View;
using ASystem.Singleton;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserContext _userContext;
        public LoginController(IUserContext userContext)
        {
            _userContext = userContext;
        }

        public IActionResult Index()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }
        [HttpPost]
        public IActionResult Index(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            UserContextModel userContextModel = _userContext.Select(loginViewModel.Username);
            if (userContextModel is null)
            {
                ModelState.AddModelError("Username", "Username does not exist");
                return View(loginViewModel);
            }
            else
            {
                CipherSingleton cipherSingleton = CipherSingleton.Instance;
                if (cipherSingleton.Decrypt(userContextModel.Password).Equals(loginViewModel.Password))
                {
                    if (userContextModel.Status.Equals(UserStatusEnum.ACTIVE.ToString()))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("Username", "User status is deactive");
                        return View(loginViewModel);
                    }
                }
                else
                {
                    ModelState.AddModelError("Password", "Incorrect password");
                    return View(loginViewModel);
                }
            }
        }
    }
}

