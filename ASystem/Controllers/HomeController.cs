using ASystem.Models.Component;
using ASystem.Models.View;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ASystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            HomeViewModel.IndexViewModel indexViewModel = new HomeViewModel.IndexViewModel();
            indexViewModel.ItemComponentModelEnumerable = GetIndexItemComponentModels();
            return View(indexViewModel);
        }
        public IActionResult Manage()
        {
            HomeViewModel.ManageViewModel indexViewModel = new HomeViewModel.ManageViewModel();
            indexViewModel.ItemComponentModelEnumerable = GetManageItemComponentModels();
            return View(indexViewModel);
        }
        public IActionResult Report()
        {
            HomeViewModel.ReportViewModel indexViewModel = new HomeViewModel.ReportViewModel();
            indexViewModel.ItemComponentModelEnumerable = GetReportItemComponentModels();
            return View(indexViewModel);
        }
        private IEnumerable<ItemComponentModel> GetManageItemComponentModels()
        {
            List<ItemComponentModel> itemModelList = new List<ItemComponentModel>();
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Airplane",
                Route = new ItemComponentModel.RouteModel() { Controller = "Airplane", Action = "Index" },
                ImageUrl = "/img/pic/airplane.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Airplane Manufacturer",
                Route = new ItemComponentModel.RouteModel() { Controller = "AirplaneManufacturer", Action = "Index" },
                ImageUrl = "/img/pic/airplane_manufacturer.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Airplane Model",
                Route = new ItemComponentModel.RouteModel() { Controller = "AirplaneModel", Action = "Index" },
                ImageUrl = "/img/pic/airplane_model.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Airport",
                Route = new ItemComponentModel.RouteModel() { Controller = "Airport", Action = "Index" },
                ImageUrl = "/img/pic/airport.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Class",
                Route = new ItemComponentModel.RouteModel() { Controller = "Class", Action = "Index" },
                ImageUrl = "/img/pic/class.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Crew",
                Route = new ItemComponentModel.RouteModel() { Controller = "Crew", Action = "Index" },
                ImageUrl = "/img/pic/crew.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Employee",
                Route = new ItemComponentModel.RouteModel() { Controller = "Employee", Action = "Index" },
                ImageUrl = "/img/pic/employee.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Flight Schedule",
                Route = new ItemComponentModel.RouteModel() { Controller = "FlightSchedule", Action = "Index" },
                ImageUrl = "/img/pic/flight_schedule.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Job",
                Route = new ItemComponentModel.RouteModel() { Controller = "Job", Action = "Index" },
                ImageUrl = "/img/pic/job.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Passenger",
                Route = new ItemComponentModel.RouteModel() { Controller = "Passenger", Action = "Index" },
                ImageUrl = "/img/pic/passenger.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Passport",
                Route = new ItemComponentModel.RouteModel() { Controller = "Passport", Action = "Index" },
                ImageUrl = "/img/pic/passport.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Pilot",
                Route = new ItemComponentModel.RouteModel() { Controller = "Pilot", Action = "Index" },
                ImageUrl = "/img/pic/pilot.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Schedule Crew",
                Route = new ItemComponentModel.RouteModel() { Controller = "ScheduleCrew", Action = "Index" },
                ImageUrl = "/img/pic/schedule_crew.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Schedule Passenger",
                Route = new ItemComponentModel.RouteModel() { Controller = "SchedulePassenger", Action = "Index" },
                ImageUrl = "/img/pic/schedule_passenger.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Schedule Pilot",
                Route = new ItemComponentModel.RouteModel() { Controller = "SchedulePilot", Action = "Index" },
                ImageUrl = "/img/pic/schedule_pilot.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Schedule Price",
                Route = new ItemComponentModel.RouteModel() { Controller = "SchedulePrice", Action = "Index" },
                ImageUrl = "/img/pic/schedule_price.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Seat",
                Route = new ItemComponentModel.RouteModel() { Controller = "Seat", Action = "Index" },
                ImageUrl = "/img/pic/seat.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "User",
                Route = new ItemComponentModel.RouteModel() { Controller = "User", Action = "Index" },
                ImageUrl = "/img/pic/user.jpg"
            });
            return itemModelList;
        }
        private IEnumerable<ItemComponentModel> GetIndexItemComponentModels()
        {
            List<ItemComponentModel> itemModelList = new List<ItemComponentModel>();
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Manage",
                Route = new ItemComponentModel.RouteModel() { Controller = "Home", Action = "Manage" },
                ImageUrl = "/img/icon/manage.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Report",
                Route = new ItemComponentModel.RouteModel() { Controller = "Home", Action = "Report" },
                ImageUrl = "/img/icon/report.jpg"
            });
            return itemModelList;
        }
        private IEnumerable<ItemComponentModel> GetReportItemComponentModels()
        {
            List<ItemComponentModel> itemModelList = new List<ItemComponentModel>();
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Get List of Pilots",
                Route = new ItemComponentModel.RouteModel() { Controller = "Report", Action = "Pilots" },
                ImageUrl = "/img/pic/airplane.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Get List of Passengers",
                Route = new ItemComponentModel.RouteModel() { Controller = "Report", Action = "Passengers" },
                ImageUrl = "/img/pic/airplane_manufacturer.jpg"
            });
            return itemModelList;
        }
    }
}
