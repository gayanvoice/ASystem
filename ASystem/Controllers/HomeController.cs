using ASystem.Models;
using ASystem.Models.Component;
using ASystem.Models.View;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ASystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            HomeViewModel.IndexViewModel indexViewModel = new HomeViewModel.IndexViewModel();
            indexViewModel.ItemComponentModelEnumerable = GetItemComponentModels();
            return View(indexViewModel);
        }
        private IEnumerable<ItemComponentModel> GetItemComponentModels()
        {
            List<ItemComponentModel> itemModelList = new List<ItemComponentModel>();
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Airplane",
                Route = new ItemComponentModel.RouteModel() { Controller = "Airplane", Action = "Index" },
                ImageUrl = "/img/pic/airplane.jp"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Airplane Manufacturer",
                Route = new ItemComponentModel.RouteModel() { Controller = "AirplaneManufacturer", Action = "Index" },
                ImageUrl = "/img/pic/airplane_manufacturer.jp"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Airplane Model",
                Route = new ItemComponentModel.RouteModel() { Controller = "AirplaneModel", Action = "Index" },
                ImageUrl = "/img/pic/airplane_model.jp"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Airport",
                Route = new ItemComponentModel.RouteModel() { Controller = "Airport", Action = "Index" },
                ImageUrl = "/img/pic/airport.jp"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Class",
                Route = new ItemComponentModel.RouteModel() { Controller = "Class", Action = "Index" },
                ImageUrl = "/img/pic/class.jp"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Crew",
                Route = new ItemComponentModel.RouteModel() { Controller = "Crew", Action = "Index" },
                ImageUrl = "/img/pic/crew.jp"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Employee",
                Route = new ItemComponentModel.RouteModel() { Controller = "Employee", Action = "Index" },
                ImageUrl = "/img/pic/employee.jp"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Flight Schedule",
                Route = new ItemComponentModel.RouteModel() { Controller = "FlightSchedule", Action = "Index" },
                ImageUrl = "/img/pic/flight_schedule.jp"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Job",
                Route = new ItemComponentModel.RouteModel() { Controller = "Job", Action = "Index" },
                ImageUrl = "/img/pic/job.jp"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Passenger",
                Route = new ItemComponentModel.RouteModel() { Controller = "Passenger", Action = "Index" },
                ImageUrl = "/img/pic/passenger.jp"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Passport",
                Route = new ItemComponentModel.RouteModel() { Controller = "Passport", Action = "Index" },
                ImageUrl = "/img/pic/passport.jp"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Pilot",
                Route = new ItemComponentModel.RouteModel() { Controller = "Pilot", Action = "Index" },
                ImageUrl = "/img/pic/pilot.jp"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Schedule Crew",
                Route = new ItemComponentModel.RouteModel() { Controller = "ScheduleCrew", Action = "Index" },
                ImageUrl = "/img/pic/schedule_crew.jp"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Schedule Passenger",
                Route = new ItemComponentModel.RouteModel() { Controller = "SchedulePassenger", Action = "Index" },
                ImageUrl = "/img/pic/schedule_passenger.jp"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Schedule Pilot",
                Route = new ItemComponentModel.RouteModel() { Controller = "SchedulePilot", Action = "Index" },
                ImageUrl = "/img/pic/schedule_pilot.jp"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Schedule Price",
                Route = new ItemComponentModel.RouteModel() { Controller = "SchedulePrice", Action = "Index" },
                ImageUrl = "/img/pic/schedule_price.jp"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Seat",
                Route = new ItemComponentModel.RouteModel() { Controller = "Seat", Action = "Index" },
                ImageUrl = "/img/pic/seat.jp"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "User",
                Route = new ItemComponentModel.RouteModel() { Controller = "User", Action = "Index" },
                ImageUrl = "/img/pic/user.jp"
            });
            return itemModelList;
        }
    }
}
