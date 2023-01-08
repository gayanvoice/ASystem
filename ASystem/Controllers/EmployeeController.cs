using ASystem.Builder;
using ASystem.Context;
using ASystem.Enum;
using ASystem.Enum.Class;
using ASystem.Enum.FlightSchedule;
using ASystem.Enum.User;
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
                    EmployeeViewModel.IndexViewModel viewModel = new EmployeeViewModel.IndexViewModel();
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
            EmployeeViewModel.ListViewModel list = new EmployeeViewModel.ListViewModel();
            list.Status = param;
            list.EmployeeContextModelEnumerable = _employeeContext.SelectAll();
            return View(list);
        }
        public IActionResult Show(int id)
        {
            EmployeeContextModel contextModel = _employeeContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
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
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            else
            {
                IEnumerable<JobContextModel> jobContextModelEnumerable = _jobContext.SelectAll();
                EmployeeViewModel.EditViewModel editViewModel = new EmployeeViewModel.EditViewModel();
                editViewModel.JobEnumerable = EmployeeHelper.FromJobEnumerable(jobContextModelEnumerable);
                editViewModel.StatusEnumerable = ClassHelper.GetIEnumerableSelectListItem<StatusEnum>();
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
            return RedirectToAction(nameof(List), new { Param = "SuccessEdit" });
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
            return RedirectToAction(nameof(List), new { Param = "SuccessInsert" });
        }

        public IActionResult Delete(int id)
        {
            EmployeeContextModel contextModel = _employeeContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
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
                Route = new ItemComponentModel.RouteModel() { Controller = "Employee", Action = "Insert" },
                ImageUrl = "/img/icon/insert.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "Employee", Action = "List" },
                ImageUrl = "/img/icon/list.jpg"
            });
            return itemModelList;
        }
    }
}