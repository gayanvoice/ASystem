using ASystem.Builder;
using ASystem.Context;
using ASystem.Enum.ScheduleCrew;
using ASystem.Helper;
using ASystem.Models.Component;
using ASystem.Models.Context;
using ASystem.Models.View;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ASystem.Controllers
{
    public class ScheduleCrewController : Controller
    {
        private readonly IFlightScheduleContext _flightScheduleContext;
        private readonly ICrewContext _crewContext;
        private readonly IScheduleCrewContext _scheduleCrewContext;
        public ScheduleCrewController(IFlightScheduleContext flightScheduleContext, ICrewContext crewContext, IScheduleCrewContext scheduleCrewContext)
        {
            _flightScheduleContext = flightScheduleContext;
            _crewContext = crewContext;
            _scheduleCrewContext = scheduleCrewContext;
        }
        public IActionResult Index()
        {
            ScheduleCrewViewModel.IndexViewModel viewModel = new ScheduleCrewViewModel.IndexViewModel();
            viewModel.ItemComponentModelEnumerable = GetItemComponentModels();
            return View(viewModel);
        }
        public IActionResult List(string param)
        {
            ScheduleCrewViewModel.ListViewModel list = new ScheduleCrewViewModel.ListViewModel();
            list.Status = param;
            list.ScheduleCrewContextModelEnumerable = _scheduleCrewContext.SelectAll();
            return View(list);
        }
        public IActionResult Show(int id)
        {
            ScheduleCrewContextModel contextModel = _scheduleCrewContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }

            ScheduleCrewViewModel.ShowViewModel showViewModel = new ScheduleCrewViewModel.ShowViewModel();
            showViewModel.Form = ScheduleCrewViewModel.ShowViewModel.FormViewModel.FromContextModel(contextModel);
            return View(showViewModel);
        }
        public IActionResult Edit(int id)
        {
            ScheduleCrewContextModel contextModel = _scheduleCrewContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            else
            {
                IEnumerable <FlightScheduleContextModel> flightScheduleContextModelEnumerable = _flightScheduleContext.SelectAll();
                IEnumerable<CrewContextModel> crewsContextModelEnumerable = _crewContext.SelectAll();
                ScheduleCrewViewModel.EditViewModel editViewModel = new ScheduleCrewViewModel.EditViewModel();
                editViewModel.FlightScheduleEnumerable = ScheduleCrewHelper.FromFlightScheduleEnumerable(flightScheduleContextModelEnumerable);
                editViewModel.CrewEnumerable = ScheduleCrewHelper.FromCrewEnumerable(crewsContextModelEnumerable);
                editViewModel.StatusEnumerable = ScheduleCrewHelper.GetIEnumerableSelectListItem<StatusEnum>();
                editViewModel.Form = ScheduleCrewViewModel.EditViewModel.FormViewModel.FromContextModel(contextModel);
                return View(editViewModel);
            }
        }
        [HttpPost]
        public IActionResult Edit(ScheduleCrewViewModel.EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<FlightScheduleContextModel> flightScheduleContextModelEnumerable = _flightScheduleContext.SelectAll();
                IEnumerable<CrewContextModel> crewsContextModelEnumerable = _crewContext.SelectAll();
                editViewModel.FlightScheduleEnumerable = ScheduleCrewHelper.FromFlightScheduleEnumerable(flightScheduleContextModelEnumerable);
                editViewModel.CrewEnumerable = ScheduleCrewHelper.FromCrewEnumerable(crewsContextModelEnumerable);
                editViewModel.StatusEnumerable = ScheduleCrewHelper.GetIEnumerableSelectListItem<StatusEnum>();
                return View(editViewModel);
            }
            ScheduleCrewBuilder builder = new ScheduleCrewBuilder();
            ScheduleCrewContextModel contextModel = builder
                .SetScheduleCrewId(editViewModel.Form.ScheduleCrewId)
                .SetFlightScheduleId(editViewModel.Form.FlightScheduleId)
                .SetCrewId(editViewModel.Form.CrewId)
                .SetTimeIn(editViewModel.Form.TimeIn)
                .SetTimeOut(editViewModel.Form.TimeOut)
                .SetStatus(editViewModel.Form.Status)
                .Build();
            _scheduleCrewContext.Update(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessEdit" });
        }
        public IActionResult Insert()
        {
            IEnumerable<FlightScheduleContextModel> flightScheduleContextModelEnumerable = _flightScheduleContext.SelectAll();
            IEnumerable<CrewContextModel> crewsContextModelEnumerable = _crewContext.SelectAll();
            ScheduleCrewViewModel.InsertViewModel insertViewModel = new ScheduleCrewViewModel.InsertViewModel();
            insertViewModel.FlightScheduleEnumerable = ScheduleCrewHelper.FromFlightScheduleEnumerable(flightScheduleContextModelEnumerable);
            insertViewModel.CrewEnumerable = ScheduleCrewHelper.FromCrewEnumerable(crewsContextModelEnumerable);
            insertViewModel.StatusEnumerable = ScheduleCrewHelper.GetIEnumerableSelectListItem<StatusEnum>();
            insertViewModel.Form = new ScheduleCrewViewModel.InsertViewModel.FormViewModel();
            return View(insertViewModel);
        }
        [HttpPost]
        public IActionResult Insert(ScheduleCrewViewModel.InsertViewModel insertViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<FlightScheduleContextModel> flightScheduleContextModelEnumerable = _flightScheduleContext.SelectAll();
                IEnumerable<CrewContextModel> crewsContextModelEnumerable = _crewContext.SelectAll();
                insertViewModel.FlightScheduleEnumerable = ScheduleCrewHelper.FromFlightScheduleEnumerable(flightScheduleContextModelEnumerable);
                insertViewModel.CrewEnumerable = ScheduleCrewHelper.FromCrewEnumerable(crewsContextModelEnumerable);
                insertViewModel.StatusEnumerable = ScheduleCrewHelper.GetIEnumerableSelectListItem<StatusEnum>();
                return View(insertViewModel);
            }
            ScheduleCrewBuilder builder = new ScheduleCrewBuilder();
            ScheduleCrewContextModel contextModel = builder
                .SetFlightScheduleId(insertViewModel.Form.FlightScheduleId)
                .SetCrewId(insertViewModel.Form.CrewId)
                .SetTimeIn(insertViewModel.Form.TimeIn)
                .SetTimeOut(insertViewModel.Form.TimeOut)
                .SetStatus(insertViewModel.Form.Status)
                .Build();
            _scheduleCrewContext.Insert(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessInsert" });
        }

        public IActionResult Delete(int id)
        {
            ScheduleCrewContextModel contextModel = _scheduleCrewContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            ScheduleCrewViewModel.DeleteViewModel viewModel = new ScheduleCrewViewModel.DeleteViewModel();
            viewModel.ScheduleCrewContextModel = contextModel;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Delete(ScheduleCrewViewModel.DeleteViewModel deleteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(deleteViewModel);
            }
            try
            {
                _scheduleCrewContext.Delete(deleteViewModel.ScheduleCrewContextModel.ScheduleCrewId);
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
                Route = new ItemComponentModel.RouteModel() { Controller = "ScheduleCrew", Action = "Insert" },
                ImageUrl = "/img/icon/insert.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "ScheduleCrew", Action = "List" },
                ImageUrl = "/img/icon/list.jpg"
            });
            return itemModelList;
        }
    }
}