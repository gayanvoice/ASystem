﻿using ASystem.Builder;
using ASystem.Context;
using ASystem.Enum.SchedulePassenger;
using ASystem.Helper;
using ASystem.Models.Component;
using ASystem.Models.Context;
using ASystem.Models.View;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            SchedulePassengerViewModel.IndexViewModel viewModel = new SchedulePassengerViewModel.IndexViewModel();
            viewModel.ItemComponentModelEnumerable = GetItemComponentModels();
            return View(viewModel);
        }
        public IActionResult List()
        {
            SchedulePassengerViewModel.ListViewModel list = new SchedulePassengerViewModel.ListViewModel();
            list.SchedulePassengerContextModelEnumerable = _schedulePassengerContext.SelectAll();
            return View(list);
        }
        public IActionResult Show(int id)
        {
            SchedulePassengerContextModel contextModel = _schedulePassengerContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List));
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
                return RedirectToAction(nameof(List));
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
                return RedirectToAction(nameof(List));
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
                return RedirectToAction(nameof(List));
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
                return RedirectToAction(nameof(List));
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
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return RedirectToAction("Show", "Error", new { Code = 100, Controller = "SchedulePassenger", Action = "List" });
            }
        }
        private IEnumerable<ItemComponentModel> GetItemComponentModels()
        {
            List<ItemComponentModel> itemModelList = new List<ItemComponentModel>();
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Insert",
                Route = new ItemComponentModel.RouteModel() { Controller = "SchedulePassenger", Action = "Insert" },
                ImageUrl = "/img/icon/insert.png"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "SchedulePassenger", Action = "List" },
                ImageUrl = "/img/icon/list.png"
            });
            return itemModelList;
        }
    }
}