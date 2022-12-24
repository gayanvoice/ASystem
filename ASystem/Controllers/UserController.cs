using ASystem.Builder;
using ASystem.Context;
using ASystem.Models.Context;
using ASystem.Models.View;
using Microsoft.AspNetCore.Mvc;
namespace ASystem.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserContext _userContext;
        public UserController(IUserContext userContext)
        {
            _userContext = userContext;
        }
        public bool Insert()
        {
            UserBuilder userBuilder = new UserBuilder();
            userBuilder.SetUsername("app");
            userBuilder.SetPassword("1234");
            userBuilder.SetStatus(Enum.UserEnum.ACTIVE);

            UserContextModel userContextModel = userBuilder.Build();
            _userContext.Insert(userContextModel);

            return true;
        }
        public IActionResult Edit(int userId)
        {
            UserContextModel userContextModel = _userContext.Select(userId);
            if (userContextModel is null)
            {
                return RedirectToAction(nameof(List));
            }
            else
            {
                UserViewModel.EditViewModel editViewModel = new UserViewModel.EditViewModel();
                editViewModel.Form = UserViewModel.EditViewModel.FormViewModel.FromUserContextModel(userContextModel);
                return View(editViewModel);
            }
        }
        [HttpPost]
        public IActionResult Edit(UserViewModel.EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editViewModel);
            }
            UserBuilder userBuilder = new UserBuilder();
            UserContextModel userContextModel = userBuilder
                .SetUserId(editViewModel.Form.UserId)
                .SetUsername(editViewModel.Form.Username)
                .SetPassword(editViewModel.Form.Password)
                .SetStatus(Enum.UserEnum.DEACTIVE)
                .Build();
            _userContext.Update(userContextModel);
            return RedirectToAction(nameof(List));
        }
        public IActionResult Show(int userId)
        {
            UserContextModel userContextModel = _userContext.Select(userId);
            if (userContextModel is null)
            {
                return RedirectToAction(nameof(List));
            }
            UserViewModel.ShowViewModel showViewModel = new UserViewModel.ShowViewModel();
            showViewModel.Form = UserViewModel.ShowViewModel.FormViewModel.FromUserContextModel(userContextModel);
            return View(showViewModel);
        }
        public IActionResult List()
        {
            UserViewModel.ListViewModel list = new UserViewModel.ListViewModel();
            list.UserContextModelEnumerable = _userContext.SelectAll();
            return View(list);
        }

    }
}
