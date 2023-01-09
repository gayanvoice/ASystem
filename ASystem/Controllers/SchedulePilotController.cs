using ASystem.Builder;
using ASystem.Context;
using ASystem.Enum.SchedulePilot;
using ASystem.Enum.User;
using ASystem.Enum.FlightSchedule;
using ASystem.Helper;
using ASystem.Models.Component;
using ASystem.Models.Context;
using ASystem.Models.View;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ASystem.Controllers
{
    public class SchedulePilotController : Controller
    {
        private readonly IFlightScheduleContext _flightScheduleContext;
        private readonly IAirplaneContext _airplaneContext;
        private readonly IPilotContext _pilotContext;
        private readonly ISchedulePilotContext _schedulePilotContext;
        public SchedulePilotController(
            IFlightScheduleContext flightScheduleContext,
            IAirplaneContext airplaneContext,
            IPilotContext pilotContext,
            ISchedulePilotContext schedulePilotContext)
        {
            _flightScheduleContext = flightScheduleContext;
            _airplaneContext = airplaneContext;
            _pilotContext = pilotContext;
            _schedulePilotContext = schedulePilotContext;
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
                    SchedulePilotViewModel.IndexViewModel viewModel = new SchedulePilotViewModel.IndexViewModel();
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
            SchedulePilotViewModel.ListViewModel list = new SchedulePilotViewModel.ListViewModel();
            list.Status = param;
            list.SchedulePilotProcedureModelEnumerable = _schedulePilotContext.GetAllSchedulePilot();
            return View(list);
        }
        public IActionResult Show(int id)
        {
            SchedulePilotContextModel contextModel = _schedulePilotContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
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
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            else
            {
                IEnumerable<FlightScheduleContextModel> flightScheduleContextModelEnumerable = _flightScheduleContext.SelectAll()
                    .Where(flightSchedule => flightSchedule.Status.Equals(Enum.FlightSchedule.StatusEnum.ENABLE.ToString()));
                IEnumerable<PilotContextModel> pilotContextModelEnumerable = _pilotContext.SelectAll();
                SchedulePilotViewModel.EditViewModel editViewModel = new SchedulePilotViewModel.EditViewModel();
                editViewModel.FlightScheduleEnumerable = SchedulePilotHelper.FromFlightScheduleEnumerable(flightScheduleContextModelEnumerable);
                editViewModel.PilotEnumerable = SchedulePilotHelper.FromPilotEnumerable(pilotContextModelEnumerable);
                editViewModel.StatusEnumerable = SchedulePilotHelper.GetIEnumerableSelectListItem<Enum.FlightSchedule.StatusEnum>();
                editViewModel.Form = SchedulePilotViewModel.EditViewModel.FormViewModel.FromContextModel(contextModel);
                return View(editViewModel);
            }
        }
        [HttpPost]
        public IActionResult Edit(SchedulePilotViewModel.EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<FlightScheduleContextModel> flightScheduleContextModelEnumerable = _flightScheduleContext.SelectAll()
                      .Where(flightSchedule => flightSchedule.Status.Equals(Enum.FlightSchedule.StatusEnum.ENABLE.ToString()));
                IEnumerable<PilotContextModel> pilotContextModelEnumerable = _pilotContext.SelectAll();
                editViewModel.FlightScheduleEnumerable = SchedulePilotHelper.FromFlightScheduleEnumerable(flightScheduleContextModelEnumerable);
                editViewModel.PilotEnumerable = SchedulePilotHelper.FromPilotEnumerable(pilotContextModelEnumerable);
                editViewModel.StatusEnumerable = SchedulePilotHelper.GetIEnumerableSelectListItem<Enum.FlightSchedule.StatusEnum>();
                return View(editViewModel);
            }
            FlightScheduleContextModel flightScheduleContextModel = _flightScheduleContext.Select(editViewModel.Form.FlightScheduleId);
            AirplaneContextModel airplaneContextModel = _airplaneContext.Select(flightScheduleContextModel.AirplaneId);
            PilotContextModel pilotContextModel = _pilotContext.Select(editViewModel.Form.PilotId);
            if (!(airplaneContextModel.AirplaneModelId.Equals(pilotContextModel.AirplaneModelId)))
            {
                IEnumerable<FlightScheduleContextModel> flightScheduleContextModelEnumerable = _flightScheduleContext.SelectAll()
                    .Where(flightSchedule => flightSchedule.Status.Equals(Enum.FlightSchedule.StatusEnum.ENABLE.ToString()));
                IEnumerable<PilotContextModel> pilotContextModelEnumerable = _pilotContext.SelectAll();
                editViewModel.FlightScheduleEnumerable = SchedulePilotHelper.FromFlightScheduleEnumerable(flightScheduleContextModelEnumerable);
                editViewModel.PilotEnumerable = SchedulePilotHelper.FromPilotEnumerable(pilotContextModelEnumerable);
                editViewModel.StatusEnumerable = SchedulePilotHelper.GetIEnumerableSelectListItem<Enum.FlightSchedule.StatusEnum>();
                ModelState.AddModelError("Form.PilotId", "Pilot ID is not compatible with the Airplane Model Id");
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
            return RedirectToAction(nameof(List), new { Param = "SuccessEdit" });
        }
        public IActionResult Insert()
        {
            IEnumerable<FlightScheduleContextModel> flightScheduleContextModelEnumerable = _flightScheduleContext.SelectAll()
                  .Where(flightSchedule => flightSchedule.Status.Equals(Enum.FlightSchedule.StatusEnum.ENABLE.ToString()));
            IEnumerable<PilotContextModel> pilotContextModelEnumerable = _pilotContext.SelectAll();
            SchedulePilotViewModel.InsertViewModel insertViewModel = new SchedulePilotViewModel.InsertViewModel();
            insertViewModel.FlightScheduleEnumerable = SchedulePilotHelper.FromFlightScheduleEnumerable(flightScheduleContextModelEnumerable);
            insertViewModel.PilotEnumerable = SchedulePilotHelper.FromPilotEnumerable(pilotContextModelEnumerable);
            insertViewModel.StatusEnumerable = SchedulePilotHelper.GetIEnumerableSelectListItem<Enum.FlightSchedule.StatusEnum>();
            insertViewModel.Form = new SchedulePilotViewModel.InsertViewModel.FormViewModel();
            return View(insertViewModel);
        }
        [HttpPost]
        public IActionResult Insert(SchedulePilotViewModel.InsertViewModel insertViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<FlightScheduleContextModel> flightScheduleContextModelEnumerable = _flightScheduleContext.SelectAll()
                      .Where(flightSchedule => flightSchedule.Status.Equals(Enum.FlightSchedule.StatusEnum.ENABLE.ToString()));
                IEnumerable<PilotContextModel> pilotContextModelEnumerable = _pilotContext.SelectAll();
                insertViewModel.FlightScheduleEnumerable = SchedulePilotHelper.FromFlightScheduleEnumerable(flightScheduleContextModelEnumerable);
                insertViewModel.PilotEnumerable = SchedulePilotHelper.FromPilotEnumerable(pilotContextModelEnumerable);
                insertViewModel.StatusEnumerable = SchedulePilotHelper.GetIEnumerableSelectListItem<Enum.FlightSchedule.StatusEnum>();
                return View(insertViewModel);
            }
            FlightScheduleContextModel flightScheduleContextModel = _flightScheduleContext.Select(insertViewModel.Form.FlightScheduleId);
            AirplaneContextModel airplaneContextModel = _airplaneContext.Select(flightScheduleContextModel.AirplaneId);
            PilotContextModel pilotContextModel = _pilotContext.Select(insertViewModel.Form.PilotId);
            if (!(airplaneContextModel.AirplaneModelId.Equals(pilotContextModel.AirplaneModelId)))
            {
                IEnumerable<FlightScheduleContextModel> flightScheduleContextModelEnumerable = _flightScheduleContext.SelectAll()
                    .Where(flightSchedule => flightSchedule.Status.Equals(Enum.FlightSchedule.StatusEnum.ENABLE.ToString()));
                IEnumerable<PilotContextModel> pilotContextModelEnumerable = _pilotContext.SelectAll();
                insertViewModel.FlightScheduleEnumerable = SchedulePilotHelper.FromFlightScheduleEnumerable(flightScheduleContextModelEnumerable);
                insertViewModel.PilotEnumerable = SchedulePilotHelper.FromPilotEnumerable(pilotContextModelEnumerable);
                insertViewModel.StatusEnumerable = SchedulePilotHelper.GetIEnumerableSelectListItem<Enum.FlightSchedule.StatusEnum>();
                ModelState.AddModelError("Form.PilotId", "Pilot ID is not compatible with the Airplane Model Id");
                return View(insertViewModel);
            }
            SchedulePilotBuilder builder = new SchedulePilotBuilder();
            SchedulePilotContextModel contextModel = builder
                .SetFlightScheduleId(insertViewModel.Form.FlightScheduleId)
                .SetPilotId(insertViewModel.Form.PilotId)
                .SetTimeIn(flightScheduleContextModel.DepartureTime.AddMinutes(-30))
                .SetTimeOut(flightScheduleContextModel.ArriveTime.AddMinutes(30))
                .SetStatus(insertViewModel.Form.Status)
                .Build();
            _schedulePilotContext.Insert(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessInsert" });
        }

        public IActionResult Delete(int id)
        {
            SchedulePilotContextModel contextModel = _schedulePilotContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
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
                Route = new ItemComponentModel.RouteModel() { Controller = "SchedulePilot", Action = "Insert" },
                ImageUrl = "/img/icon/insert.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "SchedulePilot", Action = "List" },
                ImageUrl = "/img/icon/list.jpg"
            });
            return itemModelList;
        }
    }
}