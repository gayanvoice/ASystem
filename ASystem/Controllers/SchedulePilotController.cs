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
    public class SchedulePilotController : Controller
    {
        private readonly IFlightScheduleContext _flightScheduleContext;
        private readonly IPilotContext _pilotContext;
        private readonly ISchedulePilotContext _schedulePilotContext;
        public SchedulePilotController(
            IFlightScheduleContext flightScheduleContext,
            IPilotContext pilotContext,
            ISchedulePilotContext schedulePilotContext)
        {
            _flightScheduleContext = flightScheduleContext;
            _pilotContext = pilotContext;
            _schedulePilotContext = schedulePilotContext;
        }
        public IActionResult Index()
        {
            SchedulePilotViewModel.IndexViewModel viewModel = new SchedulePilotViewModel.IndexViewModel();
            viewModel.ItemComponentModelEnumerable = GetItemComponentModels();
            return View(viewModel);
        }
        public IActionResult List()
        {
            SchedulePilotViewModel.ListViewModel list = new SchedulePilotViewModel.ListViewModel();
            list.SchedulePilotContextModelEnumerable = _schedulePilotContext.SelectAll();
            return View(list);
        }
        public IActionResult Show(int id)
        {
            SchedulePilotContextModel contextModel = _schedulePilotContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List));
            }

            SchedulePilotViewModel.ShowViewModel showViewModel = new SchedulePilotViewModel.ShowViewModel();
            showViewModel.Form = SchedulePilotViewModel.ShowViewModel.FormViewModel.FromContextModel(contextModel);
            return View(showViewModel);
        }
        public IActionResult Edit(int id)
        {
            SchedulePilotContextModel contextModel = _schedulePilotContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List));
            }
            else
            {
                IEnumerable<FlightScheduleContextModel> flightScheduleContextModelEnumerable = _flightScheduleContext.SelectAll();
                IEnumerable<PilotContextModel> pilotContextModelEnumerable = _pilotContext.SelectAll();
                SchedulePilotViewModel.EditViewModel editViewModel = new SchedulePilotViewModel.EditViewModel();
                editViewModel.FlightScheduleEnumerable = SchedulePilotHelper.FromFlightScheduleEnumerable(flightScheduleContextModelEnumerable);
                editViewModel.PilotEnumerable = SchedulePilotHelper.FromPilotEnumerable(pilotContextModelEnumerable);
                editViewModel.StatusEnumerable = SchedulePilotHelper.GetIEnumerableSelectListItem<StatusEnum>();
                editViewModel.Form = SchedulePilotViewModel.EditViewModel.FormViewModel.FromContextModel(contextModel);
                return View(editViewModel);
            }
        }
        [HttpPost]
        public IActionResult Edit(SchedulePilotViewModel.EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<FlightScheduleContextModel> flightScheduleContextModelEnumerable = _flightScheduleContext.SelectAll();
                IEnumerable<PilotContextModel> pilotContextModelEnumerable = _pilotContext.SelectAll();
                editViewModel.FlightScheduleEnumerable = SchedulePilotHelper.FromFlightScheduleEnumerable(flightScheduleContextModelEnumerable);
                editViewModel.PilotEnumerable = SchedulePilotHelper.FromPilotEnumerable(pilotContextModelEnumerable);
                editViewModel.StatusEnumerable = SchedulePilotHelper.GetIEnumerableSelectListItem<StatusEnum>();
                return View(editViewModel);
            }
            SchedulePilotBuilder builder = new SchedulePilotBuilder();
            SchedulePilotContextModel contextModel = builder
                .SetSchedulePilotId(editViewModel.Form.SchedulePilotId)
                .SetFlightScheduleId(editViewModel.Form.FlightScheduleId)
                .SetPilotId(editViewModel.Form.PilotId)
                .SetTimeIn(editViewModel.Form.TimeIn)
                .SetTimeOut(editViewModel.Form.TimeOut)
                .SetStatus(editViewModel.Form.Status)
                .Build();
            _schedulePilotContext.Update(contextModel);
            return RedirectToAction(nameof(List));
        }
        public IActionResult Insert()
        {
            IEnumerable<FlightScheduleContextModel> flightScheduleContextModelEnumerable = _flightScheduleContext.SelectAll();
            IEnumerable<PilotContextModel> pilotContextModelEnumerable = _pilotContext.SelectAll();
            SchedulePilotViewModel.InsertViewModel insertViewModel = new SchedulePilotViewModel.InsertViewModel();
            insertViewModel.FlightScheduleEnumerable = SchedulePilotHelper.FromFlightScheduleEnumerable(flightScheduleContextModelEnumerable);
            insertViewModel.PilotEnumerable = SchedulePilotHelper.FromPilotEnumerable(pilotContextModelEnumerable);
            insertViewModel.StatusEnumerable = SchedulePilotHelper.GetIEnumerableSelectListItem<StatusEnum>();
            insertViewModel.Form = new SchedulePilotViewModel.InsertViewModel.FormViewModel();
            return View(insertViewModel);
        }
        [HttpPost]
        public IActionResult Insert(SchedulePilotViewModel.InsertViewModel insertViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<FlightScheduleContextModel> flightScheduleContextModelEnumerable = _flightScheduleContext.SelectAll();
                IEnumerable<PilotContextModel> pilotContextModelEnumerable = _pilotContext.SelectAll();
                insertViewModel.FlightScheduleEnumerable = SchedulePilotHelper.FromFlightScheduleEnumerable(flightScheduleContextModelEnumerable);
                insertViewModel.PilotEnumerable = SchedulePilotHelper.FromPilotEnumerable(pilotContextModelEnumerable);
                insertViewModel.StatusEnumerable = SchedulePilotHelper.GetIEnumerableSelectListItem<StatusEnum>();
                return View(insertViewModel);
            }
            SchedulePilotBuilder builder = new SchedulePilotBuilder();
            SchedulePilotContextModel contextModel = builder
                .SetFlightScheduleId(insertViewModel.Form.FlightScheduleId)
                .SetPilotId(insertViewModel.Form.PilotId)
                .SetTimeIn(insertViewModel.Form.TimeIn)
                .SetTimeOut(insertViewModel.Form.TimeOut)
                .SetStatus(insertViewModel.Form.Status)
                .Build();
            _schedulePilotContext.Insert(contextModel);
            return RedirectToAction(nameof(List));
        }

        public IActionResult Delete(int id)
        {
            SchedulePilotContextModel contextModel = _schedulePilotContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List));
            }
            SchedulePilotViewModel.DeleteViewModel viewModel = new SchedulePilotViewModel.DeleteViewModel();
            viewModel.SchedulePilotContextModel = contextModel;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Delete(SchedulePilotViewModel.DeleteViewModel deleteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(deleteViewModel);
            }
            try
            {
                _schedulePilotContext.Delete(deleteViewModel.SchedulePilotContextModel.SchedulePilotId);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return RedirectToAction("Show", "Error", new { Code = 100, Controller = "SchedulePilot", Action = "List" });
            }
        }
        private IEnumerable<ItemComponentModel> GetItemComponentModels()
        {
            List<ItemComponentModel> itemModelList = new List<ItemComponentModel>();
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Insert",
                Route = new ItemComponentModel.RouteModel() { Controller = "SchedulePilot", Action = "Insert" },
                ImageUrl = "/img/icon/insert.png"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "SchedulePilot", Action = "List" },
                ImageUrl = "/img/icon/list.png"
            });
            return itemModelList;
        }
    }
}