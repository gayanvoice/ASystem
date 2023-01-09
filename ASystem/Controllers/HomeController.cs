using ASystem.Context;
using ASystem.Enum.User;
using ASystem.Models.Component;
using ASystem.Models.Context;
using ASystem.Models.View;
using ASystem.Singleton;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ASystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserContext _userContext;
        public HomeController(IUserContext userContext)
        {
            _userContext = userContext;
        }

        public IActionResult Login()
        {
            string username = Request.Cookies[UserCookieEnum.A_SYSTEM_USERNAME.ToString()];
            if (username is null)
            {
                LoginViewModel loginViewModel = new LoginViewModel();
                return View(loginViewModel);
            }
            else
            {
                return RedirectToAction(nameof(Index), new { Param = "AlreadyLogin" });
            }
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            UserContextModel userContextModel = _userContext.Select(loginViewModel.Username);
            if (userContextModel is null)
            {
                ModelState.AddModelError("Username", "Username does not exist");
                return View(loginViewModel);
            }
            else
            {
                CipherSingleton cipherSingleton = CipherSingleton.Instance;
                if (cipherSingleton.Decrypt(userContextModel.Password).Equals(loginViewModel.Password))
                {
                    if (userContextModel.Status.Equals(UserStatusEnum.ACTIVE.ToString()))
                    {
                        var remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress;
                        var cookieOptions = new CookieOptions
                        {
                            Secure = true,
                            HttpOnly = true,
                            SameSite = SameSiteMode.None,
                            Expires = DateTime.Now.AddDays(1)
                        };
                        Response.Cookies.Append(UserCookieEnum.A_SYSTEM_USERNAME.ToString(), userContextModel.Username, cookieOptions);
                        Response.Cookies.Append(UserCookieEnum.A_SYSTEM_ROLE.ToString(), userContextModel.Role, cookieOptions);
                        return RedirectToAction(nameof(Index), new { Param = "SuccessLogin" });
                    }
                    else
                    {
                        ModelState.AddModelError("Username", "User status is deactive");
                        return View(loginViewModel);
                    }
                }
                else
                {
                    ModelState.AddModelError("Password", "Incorrect password");
                    return View(loginViewModel);
                }
            }
        }
        public IActionResult LogOut()
        {
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            return RedirectToAction(nameof(Login), new { Param = "SuccessLogout" });
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
                HomeViewModel.IndexViewModel indexViewModel = new HomeViewModel.IndexViewModel();
                indexViewModel.ItemComponentModelEnumerable = GetIndexItemComponentModels(role);
                return View(indexViewModel);
            }
        }
        public IActionResult Manage()
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
                    HomeViewModel.ManageViewModel indexViewModel = new HomeViewModel.ManageViewModel();
                    indexViewModel.ItemComponentModelEnumerable = GetManageItemComponentModels();
                    return View(indexViewModel);
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
        }
        public IActionResult Report()
        {
            string username = Request.Cookies[UserCookieEnum.A_SYSTEM_USERNAME.ToString()];
            string role = Request.Cookies[UserCookieEnum.A_SYSTEM_ROLE.ToString()];
            if (username is null)
            {
                return RedirectToAction("LogIn", "Home", new { area = "" });
            }
            else
            {
                if (role.Equals(UserRoleEnum.MANAGEMENT.ToString()))
                {
                    HomeViewModel.ReportViewModel indexViewModel = new HomeViewModel.ReportViewModel();
                    indexViewModel.ItemComponentModelEnumerable = GetReportItemComponentModels();
                    return View(indexViewModel);
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
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
            return itemModelList;
        }
        private IEnumerable<ItemComponentModel> GetIndexItemComponentModels(string role)
        {
            List<ItemComponentModel> itemModelList = new List<ItemComponentModel>();
            if (role.Equals(UserRoleEnum.ADMIN.ToString()))
            {
                itemModelList.Add(new ItemComponentModel()
                {
                    Name = "User",
                    Route = new ItemComponentModel.RouteModel() { Controller = "User", Action = "Index" },
                    ImageUrl = "/img/pic/user.jpg"
                });
            }
            else if (role.Equals(UserRoleEnum.STAFF.ToString()))
            {
                itemModelList.Add(new ItemComponentModel()
                {
                    Name = "Manage",
                    Route = new ItemComponentModel.RouteModel() { Controller = "Home", Action = "Manage" },
                    ImageUrl = "/img/icon/manage.jpg"
                });
            }
            else if (role.Equals(UserRoleEnum.MANAGEMENT.ToString()))
            {
                itemModelList.Add(new ItemComponentModel()
                {
                    Name = "Report",
                    Route = new ItemComponentModel.RouteModel() { Controller = "Home", Action = "Report" },
                    ImageUrl = "/img/icon/report.jpg"
                });
            }
            return itemModelList;
        }
        private IEnumerable<ItemComponentModel> GetReportItemComponentModels()
        {
            List<ItemComponentModel> itemModelList = new List<ItemComponentModel>();
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Crew Schedule Report",
                Route = new ItemComponentModel.RouteModel() { Controller = "Report", Action = "CrewScheduleReport" },
                ImageUrl = "/img/report/crew-schedule.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Flight Schedule With Destination",
                Route = new ItemComponentModel.RouteModel() { Controller = "Report", Action = "FlightScheduleWithDestinationReport" },
                ImageUrl = "/img/report/flight-schedule-with-destination.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Passengers By Flight Schedule Report",
                Route = new ItemComponentModel.RouteModel() { Controller = "Report", Action = "PassengersByFlightScheduleReport" },
                ImageUrl = "/img/report/passengers-by-flight.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Pay Crew Weekly Report",
                Route = new ItemComponentModel.RouteModel() { Controller = "Report", Action = "PayCrewWeeklyReport" },
                ImageUrl = "/img/report/pay-crew-weekly.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Pay Pilot Weekly Report",
                Route = new ItemComponentModel.RouteModel() { Controller = "Report", Action = "PayPilotWeeklyReport" },
                ImageUrl = "/img/report/pay-pilot-weekly.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Pilot Schedule Report",
                Route = new ItemComponentModel.RouteModel() { Controller = "Report", Action = "PilotScheduleReport" },
                ImageUrl = "/img/report/pilot-schedule.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Remaining Seats Of Class BY Flight Schedule Report",
                Route = new ItemComponentModel.RouteModel() { Controller = "Report", Action = "RemainingSeatsOfClassByFlightScheduleReport" },
                ImageUrl = "/img/report/remaining-seats-of-flight-schedule.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Working Hours Of Crew Report",
                Route = new ItemComponentModel.RouteModel() { Controller = "Report", Action = "WorkingHoursOfCrewReport" },
                ImageUrl = "/img/report/working-hours-of-crew.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Working Hours Of Pilot Report",
                Route = new ItemComponentModel.RouteModel() { Controller = "Report", Action = "WorkingHoursOfPilotReport" },
                ImageUrl = "/img/report/working-hours-of-pilot.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Revenue By Flight Schedule",
                Route = new ItemComponentModel.RouteModel() { Controller = "Report", Action = "RevenueByFlightScheduleReport" },
                ImageUrl = "/img/report/revenue-by-flight-schedule.jpg"
            });
            return itemModelList;
        }
    }
}
