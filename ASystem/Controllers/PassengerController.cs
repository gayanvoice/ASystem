using ASystem.Builder;
using ASystem.Context;
using ASystem.Enum;
using ASystem.Enum.Class;
using ASystem.Enum.FlightSchedule;
using ASystem.Enum.Passport;
using ASystem.Enum.User;
using ASystem.Helper;
using ASystem.Models.Component;
using ASystem.Models.Context;
using ASystem.Models.View;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ASystem.Controllers
{
    public class PassengerController : Controller
    {
        private readonly IPassengerContext _passengerContext;
        private readonly IPassportContext _passportContext;
        public PassengerController(IPassengerContext passengerContext, IPassportContext passportContext)
        {
            _passengerContext = passengerContext;
            _passportContext = passportContext;
        }
        public IActionResult Index()
        {
            string username = Request.Cookies[UserCookieEnum.A_SYSTEM_USERNAME.ToString()];
            string role = Request.Cookies[UserCookieEnum.A_SYSTEM_ROLE.ToString()];
            if (username is null)
            {
                return RedirectToAction("LogIn", "Home", new { area = "" });
            }
            else
            {

                if (role.Equals(UserRoleEnum.STAFF.ToString()))
                {
                    PassengerViewModel.IndexViewModel viewModel = new PassengerViewModel.IndexViewModel();
                    viewModel.ItemComponentModelEnumerable = GetItemComponentModels();
                    return View(viewModel);
                }
                else
                {
                    return RedirectToAction("LogIn", "Home", new { area = "" });
                }
            }
        }
        public IActionResult List()
        {
            PassengerViewModel.ListViewModel list = new PassengerViewModel.ListViewModel();
            list.PassengerContextModelEnumerable = _passengerContext.SelectAll();
            return View(list);
        }
        public IActionResult Show(int id)
        {
            PassengerContextModel contextModel = _passengerContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }

            PassengerViewModel.ShowViewModel showViewModel = new PassengerViewModel.ShowViewModel();
            showViewModel.Form = PassengerViewModel.ShowViewModel.FormViewModel.FromContextModel(contextModel);
            return View(showViewModel);
        }
        public IActionResult Edit(int id)
        {
            PassengerContextModel contextModel = _passengerContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            else
            {
                IEnumerable<PassportContextModel> passportContextModelEnumerable = _passportContext.SelectAll();
                PassengerViewModel.EditViewModel editViewModel = new PassengerViewModel.EditViewModel();
                editViewModel.PassportEnumerable = PassengerHelper
                    .FromPassportEnumerable(passportContextModelEnumerable.Where(passport => passport.Status.Equals(Enum.Passport.StatusEnum.ACTIVE.ToString())));
                editViewModel.Form = PassengerViewModel.EditViewModel.FormViewModel.FromContextModel(contextModel);
                return View(editViewModel);
            }
        }
        [HttpPost]
        public IActionResult Edit(PassengerViewModel.EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<PassportContextModel> passportContextModelEnumerable = _passportContext.SelectAll();
                editViewModel.PassportEnumerable = PassengerHelper
                    .FromPassportEnumerable(passportContextModelEnumerable.Where(passport => passport.Status.Equals(Enum.Passport.StatusEnum.ACTIVE.ToString())));
                return View(editViewModel);
            }
            PassengerBuilder builder = new PassengerBuilder();
            PassengerContextModel contextModel = builder
                .SetPassengerId(editViewModel.Form.PassengerId)
                .SetPassportId(editViewModel.Form.PassportId)
                .SetPhone(editViewModel.Form.Phone)
                .Build();
            _passengerContext.Update(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessEdit" });
        }
        public IActionResult Insert()
        {
            IEnumerable<PassportContextModel> passportContextModelEnumerable = _passportContext.SelectAll();
            PassengerViewModel.InsertViewModel insertViewModel = new PassengerViewModel.InsertViewModel();
            insertViewModel.PassportEnumerable = PassengerHelper
                .FromPassportEnumerable(passportContextModelEnumerable.Where(passport => passport.Status.Equals(Enum.Passport.StatusEnum.ACTIVE.ToString())));
            insertViewModel.Form = new PassengerViewModel.InsertViewModel.FormViewModel();
            return View(insertViewModel);
        }
        [HttpPost]
        public IActionResult Insert(PassengerViewModel.InsertViewModel insertViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<PassportContextModel> passportContextModelEnumerable = _passportContext.SelectAll();
                insertViewModel.PassportEnumerable = PassengerHelper
                    .FromPassportEnumerable(passportContextModelEnumerable.Where(passport => passport.Status.Equals(Enum.Passport.StatusEnum.ACTIVE.ToString())));
                return View(insertViewModel);
            }
            IEnumerable<PassengerContextModel> passengerContextModelEnumerable = _passengerContext.SelectAll();
            if (passengerContextModelEnumerable.Any(passenger => passenger.PassportId.Equals(insertViewModel.Form.PassportId)))
            {
                IEnumerable<PassportContextModel> passportContextModelEnumerable = _passportContext.SelectAll();
                insertViewModel.PassportEnumerable = PassengerHelper
                    .FromPassportEnumerable(passportContextModelEnumerable.Where(passport => passport.Status.Equals(Enum.Passport.StatusEnum.ACTIVE.ToString())));
                ModelState.AddModelError("Form.PassportId", "Passport is already added to Passenger");
                return View(insertViewModel);
            }
            PassengerBuilder builder = new PassengerBuilder();
            PassengerContextModel contextModel = builder
                .SetPassportId(insertViewModel.Form.PassportId)
                .SetPhone(insertViewModel.Form.Phone)
                .Build();
            _passengerContext.Insert(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessInsert" });
        }

        public IActionResult Delete(int id)
        {
            PassengerContextModel contextModel = _passengerContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            PassengerViewModel.DeleteViewModel viewModel = new PassengerViewModel.DeleteViewModel();
            viewModel.PassengerContextModel = contextModel;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Delete(PassengerViewModel.DeleteViewModel deleteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(deleteViewModel);
            }
            try
            {
                _passengerContext.Delete(deleteViewModel.PassengerContextModel.PassengerId);
                return RedirectToAction(nameof(List), new { Param = "SuccessDelete" });
            }
            catch
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorConstraint" });
            }
        }
        private IEnumerable<ItemComponentModel> GetItemComponentModels()
        {
            List<ItemComponentModel> itemModelList = new List<ItemComponentModel>();
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Insert",
                Route = new ItemComponentModel.RouteModel() { Controller = "Passenger", Action = "Insert" },
                ImageUrl = "/img/icon/insert.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "Passenger", Action = "List" },
                ImageUrl = "/img/icon/list.jpg"
            });
            return itemModelList;
        }
    }
}