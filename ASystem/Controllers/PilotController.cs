using ASystem.Builder;
using ASystem.Context;
using ASystem.Enum.User;
using ASystem.Helper;
using ASystem.Models.Component;
using ASystem.Models.Context;
using ASystem.Models.View;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ASystem.Controllers
{
    public class PilotController : Controller
    {
        private readonly IEmployeeContext _employeeContext;
        private readonly IAirplaneModelContext _airplaneModelContext;
        private readonly IPilotContext _pilotContext;
        public PilotController(IEmployeeContext employeeContext, 
            IAirplaneModelContext airplaneModelContext,
            IPilotContext pilotContext)
        {
            _employeeContext = employeeContext;
            _airplaneModelContext = airplaneModelContext;
            _pilotContext = pilotContext;
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
                    PilotViewModel.IndexViewModel viewModel = new PilotViewModel.IndexViewModel();
                    viewModel.ItemComponentModelEnumerable = GetItemComponentModels();
                    return View(viewModel);
                }
                else
                {
                    return RedirectToAction("LogIn", "Home", new { area = "" });
                }
            }
        }
        public IActionResult List(string param)
        {
            PilotViewModel.ListViewModel list = new PilotViewModel.ListViewModel();
            list.Status = param;
            list.PilotContextModelEnumerable = _pilotContext.SelectAll();
            return View(list);
        }
        public IActionResult Show(int id)
        {
            PilotContextModel contextModel = _pilotContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }

            PilotViewModel.ShowViewModel showViewModel = new PilotViewModel.ShowViewModel();
            showViewModel.Form = PilotViewModel.ShowViewModel.FormViewModel.FromContextModel(contextModel);
            return View(showViewModel);
        }
        public IActionResult Edit(int id)
        {
            PilotContextModel contextModel = _pilotContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            else
            {
                IEnumerable<EmployeeContextModel> employeeContextModelEnumerable = _employeeContext.SelectAll();
                IEnumerable<AirplaneModelContextModel> airplaneModelContextModelEnumerable = _airplaneModelContext.SelectAll();
                PilotViewModel.EditViewModel editViewModel = new PilotViewModel.EditViewModel();
                editViewModel.EmployeeEnumerable = PilotHelper.FromEmployeeEnumerable(employeeContextModelEnumerable);
                editViewModel.AirplaneModelEnumerable = PilotHelper.FromAirplaneModelEnumerable(airplaneModelContextModelEnumerable);
                editViewModel.Form = PilotViewModel.EditViewModel.FormViewModel.FromContextModel(contextModel);
                return View(editViewModel);
            }
        }
        [HttpPost]
        public IActionResult Edit(PilotViewModel.EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<EmployeeContextModel> employeeContextModelEnumerable = _employeeContext.SelectAll();
                IEnumerable<AirplaneModelContextModel> airplaneModelContextModelEnumerable = _airplaneModelContext.SelectAll();
                editViewModel.EmployeeEnumerable = PilotHelper.FromEmployeeEnumerable(employeeContextModelEnumerable);
                editViewModel.AirplaneModelEnumerable = PilotHelper.FromAirplaneModelEnumerable(airplaneModelContextModelEnumerable);
                return View(editViewModel);
            }
            PilotBuilder builder = new PilotBuilder();
            PilotContextModel contextModel = builder
                .SetPilotId(editViewModel.Form.PilotId)
                .SetEmployeeId(editViewModel.Form.EmployeeId)
                .SetAirplaneModelId(editViewModel.Form.AirplaneModelId)
                .SetRatings(editViewModel.Form.Ratings)
                .Build();
            _pilotContext.Update(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessEdit" });
        }
        public IActionResult Insert()
        {
            IEnumerable<EmployeeContextModel> employeeContextModelEnumerable = _employeeContext.SelectAll();
            IEnumerable<AirplaneModelContextModel> airplaneModelContextModelEnumerable = _airplaneModelContext.SelectAll();
            PilotViewModel.InsertViewModel insertViewModel = new PilotViewModel.InsertViewModel();
            insertViewModel.EmployeeEnumerable = PilotHelper.FromEmployeeEnumerable(employeeContextModelEnumerable);
            insertViewModel.AirplaneModelEnumerable = PilotHelper.FromAirplaneModelEnumerable(airplaneModelContextModelEnumerable);
            insertViewModel.Form = new PilotViewModel.InsertViewModel.FormViewModel();
            return View(insertViewModel);
        }
        [HttpPost]
        public IActionResult Insert(PilotViewModel.InsertViewModel insertViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<EmployeeContextModel> employeeContextModelEnumerable = _employeeContext.SelectAll();
                IEnumerable<AirplaneModelContextModel> airplaneModelContextModelEnumerable = _airplaneModelContext.SelectAll();
                insertViewModel.EmployeeEnumerable = PilotHelper.FromEmployeeEnumerable(employeeContextModelEnumerable);
                insertViewModel.AirplaneModelEnumerable = PilotHelper.FromAirplaneModelEnumerable(airplaneModelContextModelEnumerable);
                return View(insertViewModel);
            }
            PilotBuilder builder = new PilotBuilder();
            PilotContextModel contextModel = builder
                .SetEmployeeId(insertViewModel.Form.EmployeeId)
                .SetAirplaneModelId(insertViewModel.Form.AirplaneModelId)
                .SetRatings(insertViewModel.Form.Ratings)
                .Build();
            _pilotContext.Insert(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessInsert" });
        }

        public IActionResult Delete(int id)
        {
            PilotContextModel contextModel = _pilotContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            PilotViewModel.DeleteViewModel viewModel = new PilotViewModel.DeleteViewModel();
            viewModel.PilotContextModel = contextModel;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Delete(PilotViewModel.DeleteViewModel deleteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(deleteViewModel);
            }
            try
            {
                _pilotContext.Delete(deleteViewModel.PilotContextModel.PilotId);
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
                Route = new ItemComponentModel.RouteModel() { Controller = "Pilot", Action = "Insert" },
                ImageUrl = "/img/icon/insert.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "Pilot", Action = "List" },
                ImageUrl = "/img/icon/list.jpg"
            });
            return itemModelList;
        }
    }
}