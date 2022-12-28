using ASystem.Builder;
using ASystem.Context;
using ASystem.Enum;
using ASystem.Enum.Class;
using ASystem.Enum.FlightSchedule;
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
            PilotViewModel.IndexViewModel viewModel = new PilotViewModel.IndexViewModel();
            viewModel.ItemComponentModelEnumerable = GetItemComponentModels();
            return View(viewModel);
        }
        public IActionResult List()
        {
            PilotViewModel.ListViewModel list = new PilotViewModel.ListViewModel();
            list.PilotContextModelEnumerable = _pilotContext.SelectAll();
            return View(list);
        }
        public IActionResult Show(int id)
        {
            PilotContextModel contextModel = _pilotContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List));
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
                return RedirectToAction(nameof(List));
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
            return RedirectToAction(nameof(List));
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
            return RedirectToAction(nameof(List));
        }

        public IActionResult Delete(int id)
        {
            PilotContextModel contextModel = _pilotContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List));
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
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return RedirectToAction("Show", "Error", new { Code = 100, Controller = "Pilot", Action = "List" });
            }
        }
        private IEnumerable<ItemComponentModel> GetItemComponentModels()
        {
            List<ItemComponentModel> itemModelList = new List<ItemComponentModel>();
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Insert",
                Route = new ItemComponentModel.RouteModel() { Controller = "Pilot", Action = "Insert" },
                ImageUrl = "/img/icon/insert.png"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "Pilot", Action = "List" },
                ImageUrl = "/img/icon/list.png"
            });
            return itemModelList;
        }
    }
}