using ASystem.Builder;
using ASystem.Context;
using ASystem.Enum.SchedulePilot;
using ASystem.Helper;
using ASystem.Models.Component;
using ASystem.Models.Context;
using ASystem.Models.View;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ASystem.Controllers
{
    public class SchedulePriceController : Controller
    {
        private readonly IFlightScheduleContext _flightScheduleContext;
        private readonly IClassContext _classContext;
        private readonly ISchedulePriceContext _schedulePriceContext;
        public SchedulePriceController(
            IFlightScheduleContext flightScheduleContext,
            IClassContext classContext,
            ISchedulePriceContext schedulePriceContext)
        {
            _flightScheduleContext = flightScheduleContext;
            _classContext = classContext;
            _schedulePriceContext = schedulePriceContext;
        }
        public IActionResult Index()
        {
            SchedulePriceViewModel.IndexViewModel viewModel = new SchedulePriceViewModel.IndexViewModel();
            viewModel.ItemComponentModelEnumerable = GetItemComponentModels();
            return View(viewModel);
        }
        public IActionResult List(string param)
        {
            SchedulePriceViewModel.ListViewModel list = new SchedulePriceViewModel.ListViewModel();
            list.Status = param;
            list.SchedulePriceContextModelEnumerable = _schedulePriceContext.SelectAll();
            return View(list);
        }
        public IActionResult Show(int id)
        {
            SchedulePriceContextModel contextModel = _schedulePriceContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }

            SchedulePriceViewModel.ShowViewModel showViewModel = new SchedulePriceViewModel.ShowViewModel();
            showViewModel.Form = SchedulePriceViewModel.ShowViewModel.FormViewModel.FromContextModel(contextModel);
            return View(showViewModel);
        }
        public IActionResult Edit(int id)
        {
            SchedulePriceContextModel contextModel = _schedulePriceContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            else
            {
                IEnumerable<FlightScheduleContextModel> flightScheduleContextModelEnumerable = _flightScheduleContext.SelectAll();
                IEnumerable<ClassContextModel> classContextModelEnumerable = _classContext.SelectAll();
                SchedulePriceViewModel.EditViewModel editViewModel = new SchedulePriceViewModel.EditViewModel();
                editViewModel.FlightScheduleEnumerable = SchedulePriceHelper.FromFlightScheduleEnumerable(flightScheduleContextModelEnumerable);
                editViewModel.ClassEnumerable = SchedulePriceHelper.FromClassEnumerable(classContextModelEnumerable);
                editViewModel.Form = SchedulePriceViewModel.EditViewModel.FormViewModel.FromContextModel(contextModel);
                return View(editViewModel);
            }
        }
        [HttpPost]
        public IActionResult Edit(SchedulePriceViewModel.EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<FlightScheduleContextModel> flightScheduleContextModelEnumerable = _flightScheduleContext.SelectAll();
                IEnumerable<ClassContextModel> classContextModelEnumerable = _classContext.SelectAll();
                editViewModel.FlightScheduleEnumerable = SchedulePriceHelper.FromFlightScheduleEnumerable(flightScheduleContextModelEnumerable);
                editViewModel.ClassEnumerable = SchedulePriceHelper.FromClassEnumerable(classContextModelEnumerable);
                return View(editViewModel);
            }
            SchedulePriceBuilder builder = new SchedulePriceBuilder();
            SchedulePriceContextModel contextModel = builder
                .SetSchedulePriceId(editViewModel.Form.SchedulePriceId)
                .SetFlightScheduleId(editViewModel.Form.FlightScheduleId)
                .SetClassId(editViewModel.Form.ClassId)
                .SetPrice(editViewModel.Form.Price)
                .Build();
            _schedulePriceContext.Update(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessEdit" });
        }
        public IActionResult Insert()
        {
            IEnumerable<FlightScheduleContextModel> flightScheduleContextModelEnumerable = _flightScheduleContext.SelectAll();
            IEnumerable<ClassContextModel> classContextModelEnumerable = _classContext.SelectAll();
            SchedulePriceViewModel.InsertViewModel insertViewModel = new SchedulePriceViewModel.InsertViewModel();
            insertViewModel.FlightScheduleEnumerable = SchedulePriceHelper.FromFlightScheduleEnumerable(flightScheduleContextModelEnumerable);
            insertViewModel.ClassEnumerable = SchedulePriceHelper.FromClassEnumerable(classContextModelEnumerable);
            insertViewModel.Form = new SchedulePriceViewModel.InsertViewModel.FormViewModel();
            return View(insertViewModel);
        }
        [HttpPost]
        public IActionResult Insert(SchedulePriceViewModel.InsertViewModel insertViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<FlightScheduleContextModel> flightScheduleContextModelEnumerable = _flightScheduleContext.SelectAll();
                IEnumerable<ClassContextModel> classContextModelEnumerable = _classContext.SelectAll();
                insertViewModel.FlightScheduleEnumerable = SchedulePriceHelper.FromFlightScheduleEnumerable(flightScheduleContextModelEnumerable);
                insertViewModel.ClassEnumerable = SchedulePriceHelper.FromClassEnumerable(classContextModelEnumerable);
                return View(insertViewModel);
            }
            SchedulePriceBuilder builder = new SchedulePriceBuilder();
            SchedulePriceContextModel contextModel = builder
                .SetFlightScheduleId(insertViewModel.Form.FlightScheduleId)
                .SetClassId(insertViewModel.Form.ClassId)
                .SetPrice(insertViewModel.Form.Price)
                .Build();
            _schedulePriceContext.Insert(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessInsert" });
        }

        public IActionResult Delete(int id)
        {
            SchedulePriceContextModel contextModel = _schedulePriceContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            SchedulePriceViewModel.DeleteViewModel viewModel = new SchedulePriceViewModel.DeleteViewModel();
            viewModel.SchedulePriceContextModel = contextModel;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Delete(SchedulePriceViewModel.DeleteViewModel deleteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(deleteViewModel);
            }
            try
            {
                _schedulePriceContext.Delete(deleteViewModel.SchedulePriceContextModel.SchedulePriceId);
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
                Route = new ItemComponentModel.RouteModel() { Controller = "SchedulePrice", Action = "Insert" },
                ImageUrl = "/img/icon/insert.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "SchedulePrice", Action = "List" },
                ImageUrl = "/img/icon/list.jpg"
            });
            return itemModelList;
        }
    }
}