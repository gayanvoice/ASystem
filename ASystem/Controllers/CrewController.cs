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
    public class CrewController : Controller
    {
        private readonly IEmployeeContext _employeeContext;
        private readonly ICrewContext _crewContext;
        public CrewController(IEmployeeContext employeeContext, ICrewContext crewContext)
        {
            _crewContext = crewContext;
            _employeeContext = employeeContext;
        }
        public IActionResult Index()
        {
            CrewViewModel.IndexViewModel viewModel = new CrewViewModel.IndexViewModel();
            viewModel.ItemComponentModelEnumerable = GetItemComponentModels();
            return View(viewModel);
        }
        public IActionResult List()
        {
            CrewViewModel.ListViewModel list = new CrewViewModel.ListViewModel();
            list.CrewContextModelEnumerable = _crewContext.SelectAll();
            return View(list);
        }
        public IActionResult Show(int id)
        {
            CrewContextModel contextModel = _crewContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List));
            }

            CrewViewModel.ShowViewModel showViewModel = new CrewViewModel.ShowViewModel();
            showViewModel.Form = CrewViewModel.ShowViewModel.FormViewModel.FromContextModel(contextModel);
            return View(showViewModel);
        }
        public IActionResult Edit(int id)
        {
            CrewContextModel contextModel = _crewContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List));
            }
            else
            {
                IEnumerable<EmployeeContextModel> employeeContextModelEnumerable = _employeeContext.SelectAll();
                CrewViewModel.EditViewModel editViewModel = new CrewViewModel.EditViewModel();
                editViewModel.EmployeeEnumerable = CrewHelper.FromEmployeeEnumerable(employeeContextModelEnumerable);
                editViewModel.Form = CrewViewModel.EditViewModel.FormViewModel.FromContextModel(contextModel);
                return View(editViewModel);
            }
        }
        [HttpPost]
        public IActionResult Edit(CrewViewModel.EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<EmployeeContextModel> employeeContextModelEnumerable = _employeeContext.SelectAll();
                editViewModel.EmployeeEnumerable = CrewHelper.FromEmployeeEnumerable(employeeContextModelEnumerable);
                return View(editViewModel);
            }
            CrewBuilder builder = new CrewBuilder();
            CrewContextModel contextModel = builder
                .SetCrewId(editViewModel.Form.CrewId)
                .SetEmployeeId(editViewModel.Form.EmployeeId)
                .Build();
            _crewContext.Update(contextModel);
            return RedirectToAction(nameof(List));
        }
        public IActionResult Insert()
        {
            IEnumerable<EmployeeContextModel> employeeContextModelEnumerable = _employeeContext.SelectAll();
            CrewViewModel.InsertViewModel insertViewModel = new CrewViewModel.InsertViewModel();
            insertViewModel.EmployeeEnumerable = CrewHelper.FromEmployeeEnumerable(employeeContextModelEnumerable);
            insertViewModel.Form = new CrewViewModel.InsertViewModel.FormViewModel();
            return View(insertViewModel);
        }
        [HttpPost]
        public IActionResult Insert(CrewViewModel.InsertViewModel insertViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<EmployeeContextModel> employeeContextModelEnumerable = _employeeContext.SelectAll();
                insertViewModel.EmployeeEnumerable = CrewHelper.FromEmployeeEnumerable(employeeContextModelEnumerable);
                return View(insertViewModel);
            }
            CrewBuilder builder = new CrewBuilder();
            CrewContextModel contextModel = builder
                .SetEmployeeId(insertViewModel.Form.EmployeeId)
                .Build();
            _crewContext.Insert(contextModel);
            return RedirectToAction(nameof(List));
        }

        public IActionResult Delete(int id)
        {
            CrewContextModel contextModel = _crewContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List));
            }
            CrewViewModel.DeleteViewModel viewModel = new CrewViewModel.DeleteViewModel();
            viewModel.CrewContextModel = contextModel;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Delete(CrewViewModel.DeleteViewModel deleteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(deleteViewModel);
            }
            try
            {
                _crewContext.Delete(deleteViewModel.CrewContextModel.CrewId);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return RedirectToAction("Show", "Error", new { Code = 100, Controller = "Crew", Action = "List" });
            }
        }
        private IEnumerable<ItemComponentModel> GetItemComponentModels()
        {
            List<ItemComponentModel> itemModelList = new List<ItemComponentModel>();
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Insert",
                Route = new ItemComponentModel.RouteModel() { Controller = "Crew", Action = "Insert" },
                ImageUrl = "/img/icon/insert.png"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "Crew", Action = "List" },
                ImageUrl = "/img/icon/list.png"
            });
            return itemModelList;
        }
    }
}