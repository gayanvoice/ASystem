using ASystem.Builder;
using ASystem.Context;
using ASystem.Enum;
using ASystem.Helper;
using ASystem.Models.Component;
using ASystem.Models.Context;
using ASystem.Models.View;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ASystem.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserContext _userContext;
        public UserController(IUserContext userContext)
        {
            _userContext = userContext;
        }
        public IActionResult Index()
        {
            UserViewModel.IndexViewModel indexViewModel = new UserViewModel.IndexViewModel();
            indexViewModel.ItemComponentModelEnumerable = GetItemComponentModels();
            return View(indexViewModel);
        }
        public IActionResult Insert()
        {
            UserViewModel.InsertViewModel insertViewModel = new UserViewModel.InsertViewModel();
            insertViewModel.StatusOption = ViewHelper.GetIEnumerableSelectListItem<UserEnum>();
            insertViewModel.Form = new UserViewModel.InsertViewModel.FormViewModel();
            return View(insertViewModel);
        }
        [HttpPost]
        public IActionResult Insert(UserViewModel.InsertViewModel insertViewModel)
        {
            if (!ModelState.IsValid)
            {
                insertViewModel.StatusOption = ViewHelper.GetIEnumerableSelectListItem<UserEnum>();
                return View(insertViewModel);
            }
            if (IsUsernameExist(insertViewModel.Form.Username))
            {
                ModelState.AddModelError("Form.Username", "Username is already exist");
                insertViewModel.StatusOption = ViewHelper.GetIEnumerableSelectListItem<UserEnum>();
                return View(insertViewModel);
            }
            else
            {
                UserBuilder userBuilder = new UserBuilder();
                UserContextModel userContextModel = userBuilder
                    .SetUsername(insertViewModel.Form.Username)
                    .SetPassword(insertViewModel.Form.Password)
                    .SetStatus(insertViewModel.Form.Status)
                    .Build();
                _userContext.Insert(userContextModel);
                return RedirectToAction(nameof(List));
            }
        }
        public bool IsUsernameExist(string username)
        {
            UserContextModel userContextModel = _userContext.Select(username);
            return !(userContextModel is null);
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
                editViewModel.StatusOption = ViewHelper.GetIEnumerableSelectListItem<UserEnum>();
                editViewModel.Form = UserViewModel.EditViewModel.FormViewModel.FromUserContextModel(userContextModel);
                return View(editViewModel);
            }
        }
        [HttpPost]
        public IActionResult Edit(UserViewModel.EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                editViewModel.StatusOption = ViewHelper.GetIEnumerableSelectListItem<UserEnum>();
                return View(editViewModel);
            }
            if (IsUsernameExist(editViewModel.Form.Username))
            {
                UserBuilder userBuilder = new UserBuilder();
                UserContextModel userContextModel = userBuilder
                    .SetUserId(editViewModel.Form.UserId)
                    .SetUsername(editViewModel.Form.Username)
                    .SetPassword(editViewModel.Form.Password)
                    .SetStatus(editViewModel.Form.Status)
                    .Build();
                _userContext.Update(userContextModel);
                return RedirectToAction(nameof(List));
            }
            else
            {
                ModelState.AddModelError("Form.Username", "Username is not already exist");
                editViewModel.StatusOption = ViewHelper.GetIEnumerableSelectListItem<UserEnum>();
                return View(editViewModel);
            }
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
        public IActionResult Delete(int userId)
        {
            UserContextModel userContextModel = _userContext.Select(userId);
            if (userContextModel is null)
            {
                return RedirectToAction(nameof(List));
            }
            UserViewModel.DeleteViewModel deleteViewModel = new UserViewModel.DeleteViewModel();
            deleteViewModel.UserContextModel = userContextModel;
            return View(deleteViewModel);
        }
        [HttpPost]
        public IActionResult Delete (UserViewModel.DeleteViewModel deleteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(deleteViewModel);
            }
            try
            {
                _userContext.Delete(deleteViewModel.UserContextModel.UserId);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return RedirectToAction("Error", "Show", new { Code = 100, Controller = "User", Action = "List" });
            }
        }
        private IEnumerable<ItemComponentModel> GetItemComponentModels()
        {
            List<ItemComponentModel> itemModelList = new List<ItemComponentModel>();
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Insert",
                Route = new ItemComponentModel.RouteModel() { Controller = "User", Action = "Insert" },
                ImageUrl = "/img/icon/insert.png"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "User", Action = "List" },
                ImageUrl = "/img/icon/list.png"
            });
            return itemModelList;
        }
    }
}