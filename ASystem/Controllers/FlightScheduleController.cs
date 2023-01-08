using ASystem.Builder;
using ASystem.Context;
using ASystem.Enum;
using ASystem.Enum.Airplane;
using ASystem.Enum.Class;
using ASystem.Enum.FlightSchedule;
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
    public class FlightScheduleController : Controller
    {
        private readonly IAirplaneContext _airplaneContext;
        private readonly IAirportContext _airportContext;
        private readonly IFlightScheduleContext _flightScheduleContext;
        public FlightScheduleController(IAirplaneContext airplaneContext,
            IAirportContext airportContext,
            IFlightScheduleContext flightScheduleContext)
        {
            _airportContext = airportContext;
            _airplaneContext = airplaneContext;
            _flightScheduleContext = flightScheduleContext;
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
                    FlightScheduleViewModel.IndexViewModel viewModel = new FlightScheduleViewModel.IndexViewModel();
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
            FlightScheduleViewModel.ListViewModel list = new FlightScheduleViewModel.ListViewModel();
            list.Status = param;
            list.FlightScheduleContextModelEnumerable = _flightScheduleContext.SelectAll();
            return View(list);
        }
        public IActionResult Show(int id)
        {
            FlightScheduleContextModel contextModel = _flightScheduleContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }

            FlightScheduleViewModel.ShowViewModel showViewModel = new FlightScheduleViewModel.ShowViewModel();
            showViewModel.Form = FlightScheduleViewModel.ShowViewModel.FormViewModel.FromContextModel(contextModel);
            return View(showViewModel);
        }
        public IActionResult Edit(int id)
        {
            FlightScheduleContextModel contextModel = _flightScheduleContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            else
            {
                IEnumerable<AirplaneContextModel> airplaneContextModelEnumerable = _airplaneContext.SelectAll();
                IEnumerable<AirportContextModel> airportContextModelEnumerable = _airportContext.SelectAll();
                FlightScheduleViewModel.EditViewModel editViewModel = new FlightScheduleViewModel.EditViewModel();
                editViewModel.AirplaneEnumerable = FlightScheduleHelper.FromAirplaneEnumerable(airplaneContextModelEnumerable
                    .Where(airplane => airplane.Status.Equals(AirplaneStatusEnum.ACTIVE.ToString())));
                editViewModel.AirportEnumerable = FlightScheduleHelper.FromAirportEnumerable(airportContextModelEnumerable);
                editViewModel.TypeEnumerable = ClassHelper.GetIEnumerableSelectListItem<TypeEnum>();
                editViewModel.StatusEnumerable = ClassHelper.GetIEnumerableSelectListItem<Enum.FlightSchedule.StatusEnum>();
                editViewModel.Form = FlightScheduleViewModel.EditViewModel.FormViewModel.FromContextModel(contextModel);
                return View(editViewModel);
            }
        }
        [HttpPost]
        public IActionResult Edit(FlightScheduleViewModel.EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<AirplaneContextModel> airplaneContextModelEnumerable = _airplaneContext.SelectAll();
                IEnumerable<AirportContextModel> airportContextModelEnumerable = _airportContext.SelectAll();
                editViewModel.AirplaneEnumerable = FlightScheduleHelper.FromAirplaneEnumerable(airplaneContextModelEnumerable
                    .Where(airplane => airplane.Status.Equals(AirplaneStatusEnum.ACTIVE.ToString())));
                editViewModel.AirportEnumerable = FlightScheduleHelper.FromAirportEnumerable(airportContextModelEnumerable);
                editViewModel.TypeEnumerable = ClassHelper.GetIEnumerableSelectListItem<TypeEnum>();
                editViewModel.StatusEnumerable = ClassHelper.GetIEnumerableSelectListItem<Enum.FlightSchedule.StatusEnum>();
                return View(editViewModel);
            }
            FlightScheduleBuilder builder = new FlightScheduleBuilder();
            FlightScheduleContextModel contextModel = builder
                .SetFlightScheduleId(editViewModel.Form.FlightScheduleId)
                .SetAirplaneId(editViewModel.Form.AirplaneId)
                .SetAirportIdOriginId(editViewModel.Form.AirportIdOrigin)
                .SetAirportIdDestinationId(editViewModel.Form.AirportIdDestination)
                .SetType(editViewModel.Form.Type)
                .SetArriveTime(editViewModel.Form.ArriveTime)
                .SetDepartureTime(editViewModel.Form.DepartureTime)
                .SetStatus(editViewModel.Form.Status)
                .Build();
            _flightScheduleContext.Update(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessEdit" });
        }
        public IActionResult Insert()
        {
            IEnumerable<AirplaneContextModel> airplaneContextModelEnumerable = _airplaneContext.SelectAll();
            IEnumerable<AirportContextModel> airportContextModelEnumerable = _airportContext.SelectAll();
            FlightScheduleViewModel.InsertViewModel insertViewModel = new FlightScheduleViewModel.InsertViewModel();
            insertViewModel.AirplaneEnumerable = FlightScheduleHelper.FromAirplaneEnumerable(airplaneContextModelEnumerable
                    .Where(airplane => airplane.Status.Equals(AirplaneStatusEnum.ACTIVE.ToString())));
            insertViewModel.AirportEnumerable = FlightScheduleHelper.FromAirportEnumerable(airportContextModelEnumerable);
            insertViewModel.TypeEnumerable = ClassHelper.GetIEnumerableSelectListItem<TypeEnum>();
            insertViewModel.StatusEnumerable = ClassHelper.GetIEnumerableSelectListItem<StatusEnum>();
            insertViewModel.Form = new FlightScheduleViewModel.InsertViewModel.FormViewModel();
            return View(insertViewModel);
        }
        [HttpPost]
        public IActionResult Insert(FlightScheduleViewModel.InsertViewModel insertViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<AirplaneContextModel> airplaneContextModelEnumerable = _airplaneContext.SelectAll();
                IEnumerable<AirportContextModel> airportContextModelEnumerable = _airportContext.SelectAll();
                insertViewModel.AirplaneEnumerable = FlightScheduleHelper.FromAirplaneEnumerable(airplaneContextModelEnumerable
                    .Where(airplane => airplane.Status.Equals(AirplaneStatusEnum.ACTIVE.ToString())));
                insertViewModel.AirportEnumerable = FlightScheduleHelper.FromAirportEnumerable(airportContextModelEnumerable);
                insertViewModel.TypeEnumerable = ClassHelper.GetIEnumerableSelectListItem<TypeEnum>();
                insertViewModel.StatusEnumerable = ClassHelper.GetIEnumerableSelectListItem<StatusEnum>();
                return View(insertViewModel);
            }
            FlightScheduleBuilder builder = new FlightScheduleBuilder();
            FlightScheduleContextModel contextModel = builder
                .SetAirplaneId(insertViewModel.Form.AirplaneId)
                .SetAirportIdOriginId(insertViewModel.Form.AirportIdOrigin)
                .SetAirportIdDestinationId(insertViewModel.Form.AirportIdDestination)
                .SetType(insertViewModel.Form.Type)
                .SetArriveTime(insertViewModel.Form.ArriveTime)
                .SetDepartureTime(insertViewModel.Form.DepartureTime)
                .SetStatus(insertViewModel.Form.Status)
                .Build();
            _flightScheduleContext.Insert(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessInsert" });
        }

        public IActionResult Delete(int id)
        {
            FlightScheduleContextModel contextModel = _flightScheduleContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            FlightScheduleViewModel.DeleteViewModel viewModel = new FlightScheduleViewModel.DeleteViewModel();
            viewModel.FlightScheduleContextModel = contextModel;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Delete(FlightScheduleViewModel.DeleteViewModel deleteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(deleteViewModel);
            }
            try
            {
                _flightScheduleContext.Delete(deleteViewModel.FlightScheduleContextModel.FlightScheduleId);
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
                Route = new ItemComponentModel.RouteModel() { Controller = "FlightSchedule", Action = "Insert" },
                ImageUrl = "/img/icon/insert.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "FlightSchedule", Action = "List" },
                ImageUrl = "/img/icon/list.jpg"
            });
            return itemModelList;
        }
    }
}