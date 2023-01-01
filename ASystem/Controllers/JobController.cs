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
    public class JobController : Controller
    {
        private readonly IJobContext _jobContext;
        public JobController(IJobContext jobContext)
        {
            _jobContext = jobContext;
        }
        public IActionResult Index()
        {
            JobViewModel.IndexViewModel jobViewModel = new JobViewModel.IndexViewModel();
            jobViewModel.ItemComponentModelEnumerable = GetItemComponentModels();
            return View(jobViewModel);
        }
        public IActionResult List(string param)
        {
            JobViewModel.ListViewModel list = new JobViewModel.ListViewModel();
            list.Status = param;
            list.JobContextModelEnumerable = _jobContext.SelectAll();
            return View(list);
        }
        public IActionResult Show(int id)
        {
            JobContextModel jobContextModel = _jobContext.Select(id);
            if (jobContextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }

            JobViewModel.ShowViewModel showViewModel = new JobViewModel.ShowViewModel();
            showViewModel.Form = JobViewModel.ShowViewModel.FormViewModel.FromJobContextModel(jobContextModel);
            return View(showViewModel);
        }

        public IActionResult Edit(int id)
        {
            JobContextModel jobContextModel = _jobContext.Select(id);
            if (jobContextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            else
            {
                JobViewModel.EditViewModel editViewModel = new JobViewModel.EditViewModel();
                editViewModel.Form = JobViewModel.EditViewModel.FormViewModel.FromJobContextModel(jobContextModel);
                return View(editViewModel);
            }
        }
        [HttpPost]
        public IActionResult Edit(JobViewModel.EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editViewModel);
            }
            JobBuilder builder = new JobBuilder();
            JobContextModel contextModel = builder
                .SetJobId(editViewModel.Form.JobId)
                .SetName(editViewModel.Form.Name)
                .SetPayPerHour(editViewModel.Form.PayPerHour)
                .SetPayOverTime(editViewModel.Form.PayOverTime)
                .SetHoursWeekly(editViewModel.Form.HoursWeekly)
                .Build();
            _jobContext.Update(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessEdit" });
        }
        public IActionResult Insert()
        {
            JobViewModel.InsertViewModel insertViewModel = new JobViewModel.InsertViewModel();
            insertViewModel.Form = new JobViewModel.InsertViewModel.FormViewModel();
            return View(insertViewModel);
        }
        [HttpPost]
        public IActionResult Insert(JobViewModel.InsertViewModel insertViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(insertViewModel);
            }
            JobBuilder builder = new JobBuilder();
            JobContextModel contextModel = builder
                .SetName(insertViewModel.Form.Name)
                .SetPayPerHour(insertViewModel.Form.PayPerHour)
                .SetPayOverTime(insertViewModel.Form.PayOverTime)
                .SetHoursWeekly(insertViewModel.Form.HoursWeekly)
                .Build();
            _jobContext.Insert(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessInsert" });
        }

        public IActionResult Delete(int id)
        {
            JobContextModel contextModel = _jobContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            JobViewModel.DeleteViewModel viewModel = new JobViewModel.DeleteViewModel();
            viewModel.JobContextModel = contextModel;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Delete(JobViewModel.DeleteViewModel deleteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(deleteViewModel);
            }
            try
            {
                _jobContext.Delete(deleteViewModel.JobContextModel.JobId);
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
                Route = new ItemComponentModel.RouteModel() { Controller = "Job", Action = "Insert" },
                ImageUrl = "/img/icon/insert.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "Job", Action = "List" },
                ImageUrl = "/img/icon/list.jpg"
            });
            return itemModelList;
        }
    }
}