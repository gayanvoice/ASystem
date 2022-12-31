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
    public class EmployeeController : Controller
    {
        private readonly IJobContext _jobContext;
        private readonly IEmployeeContext _employeeContext;
        public EmployeeController(IJobContext jobContext,
            IEmployeeContext employeeContext)
        {
            _jobContext = jobContext;
            _employeeContext = employeeContext;
        }
        public IActionResult Index()
        {
            EmployeeViewModel.IndexViewModel viewModel = new EmployeeViewModel.IndexViewModel();
            viewModel.ItemComponentModelEnumerable = GetItemComponentModels();
            return View(viewModel);
        }
        public IActionResult List()
        {
            EmployeeViewModel.ListViewModel list = new EmployeeViewModel.ListViewModel();
            list.EmployeeContextModelEnumerable = _employeeContext.SelectAll();
            return View(list);
        }
        public IActionResult Show(int id)
        {
            EmployeeContextModel contextModel = _employeeContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List));
            }

            EmployeeViewModel.ShowViewModel showViewModel = new EmployeeViewModel.ShowViewModel();
            showViewModel.Form = EmployeeViewModel.ShowViewModel.FormViewModel.FromContextModel(contextModel);
            return View(showViewModel);
        }
        public IActionResult Edit(int id)
        {
            EmployeeContextModel contextModel = _employeeContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List));
            }
            else
            {
                IEnumerable<JobContextModel> jobContextModelEnumerable = _jobContext.SelectAll();
                EmployeeViewModel.EditViewModel editViewModel = new EmployeeViewModel.EditViewModel();
                editViewModel.JobEnumerable = EmployeeHelper.FromJobEnumerable(jobContextModelEnumerable);
                editViewModel.StatusEnumerable = ClassHelper.GetIEnumerableSelectListItem<Enum.FlightSchedule.StatusEnum>();
                editViewModel.Form = EmployeeViewModel.EditViewModel.FormViewModel.FromContextModel(contextModel);
                return View(editViewModel);
            }
        }
        [HttpPost]
        public IActionResult Edit(EmployeeViewModel.EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<JobContextModel> jobContextModelEnumerable = _jobContext.SelectAll();
                editViewModel.JobEnumerable = EmployeeHelper.FromJobEnumerable(jobContextModelEnumerable);
                editViewModel.StatusEnumerable = FlightScheduleHelper.GetIEnumerableSelectListItem<Enum.FlightSchedule.StatusEnum>();
                return View(editViewModel);
            }
            EmployeeBuilder builder = new EmployeeBuilder();
            EmployeeContextModel contextModel = builder
                .SetEmployeeId(editViewModel.Form.EmployeeId)
                .SetJobId(editViewModel.Form.JobId)
                .SetSurname(editViewModel.Form.Surname)
                .SetOtherName(editViewModel.Form.OtherName)
                .SetDateOfBirth(editViewModel.Form.DateOfBirth)
                .SetAddress(editViewModel.Form.Address)
                .SetPhone(editViewModel.Form.Phone)
                .SetStatus(editViewModel.Form.Status)
                .Build();
            _employeeContext.Update(contextModel);
            return RedirectToAction(nameof(List));
        }
        public IActionResult Insert()
        {
            IEnumerable<JobContextModel> jobContextModelEnumerable = _jobContext.SelectAll();
            EmployeeViewModel.InsertViewModel insertViewModel = new EmployeeViewModel.InsertViewModel();
            insertViewModel.JobEnumerable = EmployeeHelper.FromJobEnumerable(jobContextModelEnumerable);
            insertViewModel.StatusEnumerable = FlightScheduleHelper.GetIEnumerableSelectListItem<Enum.FlightSchedule.StatusEnum>();
            insertViewModel.Form = new EmployeeViewModel.InsertViewModel.FormViewModel();
            return View(insertViewModel);
        }
        [HttpPost]
        public IActionResult Insert(EmployeeViewModel.InsertViewModel insertViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<JobContextModel> jobContextModelEnumerable = _jobContext.SelectAll();
                insertViewModel.JobEnumerable = EmployeeHelper.FromJobEnumerable(jobContextModelEnumerable);
                insertViewModel.StatusEnumerable = EmployeeHelper.FromEnumerableSelectListItem<Enum.FlightSchedule.StatusEnum>();
                return View(insertViewModel);
            }
            EmployeeBuilder builder = new EmployeeBuilder();
            EmployeeContextModel contextModel = builder
                .SetJobId(insertViewModel.Form.JobId)
                .SetSurname(insertViewModel.Form.Surname)
                .SetOtherName(insertViewModel.Form.OtherName)
                .SetDateOfBirth(insertViewModel.Form.DateOfBirth)
                .SetAddress(insertViewModel.Form.Address)
                .SetPhone(insertViewModel.Form.Phone)
                .SetStatus(insertViewModel.Form.Status)
                .Build();
            _employeeContext.Insert(contextModel);
            return RedirectToAction(nameof(List));
        }

        public IActionResult Delete(int id)
        {
            EmployeeContextModel contextModel = _employeeContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List));
            }
            EmployeeViewModel.DeleteViewModel viewModel = new EmployeeViewModel.DeleteViewModel();
            viewModel.EmployeeContextModel = contextModel;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Delete(EmployeeViewModel.DeleteViewModel deleteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(deleteViewModel);
            }
            try
            {
                _employeeContext.Delete(deleteViewModel.EmployeeContextModel.EmployeeId);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return RedirectToAction("Show", "Error", new { Code = 100, Controller = "Employee", Action = "List" });
            }
        }
        private IEnumerable<ItemComponentModel> GetItemComponentModels()
        {
            List<ItemComponentModel> itemModelList = new List<ItemComponentModel>();
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Insert",
                Route = new ItemComponentModel.RouteModel() { Controller = "Employee", Action = "Insert" },
                ImageUrl = "/img/icon/insert.png"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "Employee", Action = "List" },
                ImageUrl = "/img/icon/list.png"
            });
            return itemModelList;
        }
    }
}