using ASystem.Builder;
using ASystem.Context;
using ASystem.Enum.SchedulePassenger;
using ASystem.Enum.User;
using ASystem.Helper;
using ASystem.Models.Component;
using ASystem.Models.Context;
using ASystem.Models.View;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ASystem.Controllers
{
    public class SchedulePassengerController : Controller
    {
        private readonly IFlightScheduleContext _flightScheduleContext;
        private readonly IPassengerContext _passengerContext;
        private readonly ISeatContext _seatContext;
        private readonly IClassContext _classContext;
        private readonly ISchedulePassengerContext _schedulePassengerContext;
        public SchedulePassengerController(
            IFlightScheduleContext flightScheduleContext,
            IPassengerContext passengerContext,
            ISeatContext seatContext,
            IClassContext classContext,
            ISchedulePassengerContext scheduleCrewContext)
        {
            _flightScheduleContext = flightScheduleContext;
            _passengerContext = passengerContext;
            _seatContext = seatContext;
            _classContext = classContext;
            _schedulePassengerContext = scheduleCrewContext;
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
                    SchedulePassengerViewModel.IndexViewModel viewModel = new SchedulePassengerViewModel.IndexViewModel();
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
            SchedulePassengerViewModel.ListViewModel list = new SchedulePassengerViewModel.ListViewModel();
            list.Status = param;
            list.SchedulePassengerProcedureEnumerable = _schedulePassengerContext.GetAllSchedulePassenger();
            return View(list);
        }
        [HttpPost]
        public IActionResult List(SchedulePassengerViewModel.ListViewModel list)
        {
            list.SchedulePassengerProcedureEnumerable = _schedulePassengerContext.GetAllSchedulePassenger()
                .Where(s => s.Name.Contains(list.Form.Name));
            return View(list);
        }
        public IActionResult Show(int id)
        {
            SchedulePassengerContextModel contextModel = _schedulePassengerContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }

            SchedulePassengerViewModel.ShowViewModel showViewModel = new SchedulePassengerViewModel.ShowViewModel();
            showViewModel.Form = SchedulePassengerViewModel.ShowViewModel.FormViewModel.FromContextModel(contextModel);
            return View(showViewModel);
        }
        public IActionResult Edit(int id)
        {
            SchedulePassengerContextModel contextModel = _schedulePassengerContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            else
            {
                SchedulePassengerViewModel.EditViewModel editViewModel = new SchedulePassengerViewModel.EditViewModel();
                editViewModel = FormatEditViewModel(editViewModel);
                editViewModel.Form = SchedulePassengerViewModel.EditViewModel.FormViewModel.FromContextModel(contextModel);
                return View(editViewModel);
            }
        }
        [HttpPost]
        public IActionResult Edit(SchedulePassengerViewModel.EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                editViewModel = FormatEditViewModel(editViewModel);
                return View(editViewModel);
            }
            FlightScheduleContextModel flightScheduleContextModel = _flightScheduleContext.Select(editViewModel.Form.FlightScheduleId);
            SeatContextModel seatContextModel = _seatContext.Select(editViewModel.Form.SeatId);
            ClassContextModel classContextModel = _classContext.Select(seatContextModel.ClassId);
            if (flightScheduleContextModel.AirplaneId.Equals(classContextModel.AirplaneId))
            {
                SchedulePassengerBuilder builder = new SchedulePassengerBuilder();
                SchedulePassengerContextModel contextModel = builder
                    .SetSchedulePassengerId(editViewModel.Form.SchedulePassengerId)
                    .SetFlightScheduleId(editViewModel.Form.FlightScheduleId)
                    .SetPassengerId(editViewModel.Form.PassengerId)
                    .SetSeatId(editViewModel.Form.SeatId)
                    .SetType(editViewModel.Form.Type)
                    .SetStatus(editViewModel.Form.Status)
                    .Build();
                _schedulePassengerContext.Update(contextModel);
                return RedirectToAction(nameof(List), new { Param = "SuccessEdit" });
            }
            else
            {
                editViewModel = FormatEditViewModel(editViewModel);
                ModelState.AddModelError("Form.SeatId", "Airplane in Flight Schedule and Seat is different");
                return View(editViewModel);
            }
        }
        private SchedulePassengerViewModel.EditViewModel FormatEditViewModel(SchedulePassengerViewModel.EditViewModel editViewModel)
        {
            IEnumerable<FlightScheduleContextModel> flightScheduleContextModelEnumerable = _flightScheduleContext.SelectAll();
            IEnumerable<PassengerContextModel> passengerContextModelEnumerable = _passengerContext.SelectAll();
            IEnumerable<SeatContextModel> seatContextModelEnumerable = _seatContext.SelectAll();
            editViewModel.FlightScheduleEnumerable = SchedulePassengerHelper.FromFlightScheduleEnumerable(flightScheduleContextModelEnumerable);
            editViewModel.PassengerEnumerable = SchedulePassengerHelper.FromPassengerEnumerable(passengerContextModelEnumerable);
            editViewModel.SeatEnumerable = SchedulePassengerHelper.FromSeatEnumerable(seatContextModelEnumerable);
            editViewModel.TypeEnumerable = SchedulePassengerHelper.GetIEnumerableSelectListItem<TypeEnum>();
            editViewModel.StatusEnumerable = SchedulePassengerHelper.GetIEnumerableSelectListItem<StatusEnum>();
            return editViewModel;
        }
        public IActionResult Insert()
        {
            SchedulePassengerViewModel.InsertViewModel insertViewModel = new SchedulePassengerViewModel.InsertViewModel();
            insertViewModel = FormatInsertViewModel(insertViewModel);
            insertViewModel.Form = new SchedulePassengerViewModel.InsertViewModel.FormViewModel();
            return View(insertViewModel);
        }

        [HttpPost]
        public IActionResult Insert(SchedulePassengerViewModel.InsertViewModel insertViewModel)
        {
            if (!ModelState.IsValid)
            {
                insertViewModel = FormatInsertViewModel(insertViewModel);
                return View(insertViewModel);
            }
            FlightScheduleContextModel flightScheduleContextModel = _flightScheduleContext.Select(insertViewModel.Form.FlightScheduleId);
            SeatContextModel seatContextModel = _seatContext.Select(insertViewModel.Form.SeatId);
            ClassContextModel classContextModel = _classContext.Select(seatContextModel.ClassId);
            if (flightScheduleContextModel.AirplaneId.Equals(classContextModel.AirplaneId))
            {
                SchedulePassengerBuilder builder = new SchedulePassengerBuilder();
                SchedulePassengerContextModel contextModel = builder
                    .SetFlightScheduleId(insertViewModel.Form.FlightScheduleId)
                    .SetPassengerId(insertViewModel.Form.PassengerId)
                    .SetSeatId(insertViewModel.Form.SeatId)
                    .SetType(insertViewModel.Form.Type)
                    .SetStatus(insertViewModel.Form.Status)
                    .Build();
                _schedulePassengerContext.Insert(contextModel);
                return RedirectToAction(nameof(List), new { Param = "SuccessInsert" });
            }
            else
            {
                insertViewModel = FormatInsertViewModel(insertViewModel);
                ModelState.AddModelError("Form.SeatId", "Airplane in Flight Schedule and Seat is different");
                return View(insertViewModel);
            }
        }
        private SchedulePassengerViewModel.InsertViewModel FormatInsertViewModel(SchedulePassengerViewModel.InsertViewModel insertViewModel)
        {
            IEnumerable<FlightScheduleContextModel> flightScheduleContextModelEnumerable = _flightScheduleContext.SelectAll();
            IEnumerable<PassengerContextModel> passengerContextModelEnumerable = _passengerContext.SelectAll();
            IEnumerable<SeatContextModel> seatContextModelEnumerable = _seatContext.SelectAll();
            insertViewModel.FlightScheduleEnumerable = SchedulePassengerHelper.FromFlightScheduleEnumerable(flightScheduleContextModelEnumerable);
            insertViewModel.PassengerEnumerable = SchedulePassengerHelper.FromPassengerEnumerable(passengerContextModelEnumerable);
            insertViewModel.SeatEnumerable = SchedulePassengerHelper.FromSeatEnumerable(seatContextModelEnumerable);
            insertViewModel.TypeEnumerable = SchedulePassengerHelper.GetIEnumerableSelectListItem<TypeEnum>();
            insertViewModel.StatusEnumerable = SchedulePassengerHelper.GetIEnumerableSelectListItem<StatusEnum>();
            return insertViewModel;
        }
        public IActionResult Delete(int id)
        {
            SchedulePassengerContextModel contextModel = _schedulePassengerContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            SchedulePassengerViewModel.DeleteViewModel viewModel = new SchedulePassengerViewModel.DeleteViewModel();
            viewModel.SchedulePassengerContextModel = contextModel;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Delete(SchedulePassengerViewModel.DeleteViewModel deleteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(deleteViewModel);
            }
            try
            {
                _schedulePassengerContext.Delete(deleteViewModel.SchedulePassengerContextModel.SchedulePassengerId);
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
                Route = new ItemComponentModel.RouteModel() { Controller = "SchedulePassenger", Action = "Insert" },
                ImageUrl = "/img/icon/insert.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "SchedulePassenger", Action = "List" },
                ImageUrl = "/img/icon/list.jpg"
            });
            return itemModelList;
        }
    }
}