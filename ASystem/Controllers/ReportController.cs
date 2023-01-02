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
    public class ReportController : Controller
    {
        private readonly IReportContext _reportContext;
        public ReportController(IReportContext reportContext)
        {
            _reportContext = reportContext;
        }
       
        public IActionResult CrewScheduleReport()
        {
            ReportViewModel.CrewScheduleReportViewModel reportViewModel = new ReportViewModel.CrewScheduleReportViewModel();
            reportViewModel.Enumerable = _reportContext.GetCrewScheduleReport(DateTime.Parse("2022-10-01"), DateTime.Parse("2022-10-31"));
            return View(reportViewModel);
        }
        [HttpPost]
        public IActionResult CrewScheduleReport(ReportViewModel.CrewScheduleReportViewModel reportViewModel)
        {
            if (!ModelState.IsValid)
            {
                reportViewModel.Enumerable = _reportContext.GetCrewScheduleReport(DateTime.Parse("2022-10-01"), DateTime.Parse("2022-10-31"));
                return View(reportViewModel);
            }
            reportViewModel.Enumerable = _reportContext.GetCrewScheduleReport(reportViewModel.Form.From, reportViewModel.Form.To);
            return View(reportViewModel);
        }
        public IActionResult FlightScheduleWithDestinationReport()
        {
            ReportViewModel.FlightScheduleWithDestinationReportViewModel reportViewModel = new ReportViewModel.FlightScheduleWithDestinationReportViewModel();
            reportViewModel.Enumerable = _reportContext.GetFlightScheduleWithDestinationReport();
            return View(reportViewModel);
        }
        public IActionResult PassengersByFlightScheduleReport()
        {
            ReportViewModel.PassengersByFlightScheduleReportViewModel reportViewModel = new ReportViewModel.PassengersByFlightScheduleReportViewModel();
            reportViewModel.Enumerable = _reportContext.GetPassengersByFlightScheduleReport();
            return View(reportViewModel);
        }
        public IActionResult PayCrewWeeklyReport()
        {
            ReportViewModel.PayCrewWeeklyReportViewModel reportViewModel = new ReportViewModel.PayCrewWeeklyReportViewModel();
            reportViewModel.Enumerable = _reportContext.GetPayCrewWeeklyReport(DateTime.Parse("2022-10-01"), DateTime.Parse("2022-10-07"));
            return View(reportViewModel);
        }
        [HttpPost]
        public IActionResult PayCrewWeeklyReport(ReportViewModel.PayCrewWeeklyReportViewModel reportViewModel)
        {
            if (!ModelState.IsValid)
            {
                reportViewModel.Enumerable = _reportContext.GetPayCrewWeeklyReport(DateTime.Parse("2022-10-01"), DateTime.Parse("2022-10-31"));
                return View(reportViewModel);
            }
            reportViewModel.Enumerable = _reportContext.GetPayCrewWeeklyReport(reportViewModel.Form.From, reportViewModel.Form.From.AddDays(7));
            return View(reportViewModel);
        }
        public IActionResult PayPilotWeeklyReport()
        {
            ReportViewModel.PayPilotWeeklyReportViewModel reportViewModel = new ReportViewModel.PayPilotWeeklyReportViewModel();
            reportViewModel.Enumerable = _reportContext.GetPayPilotWeeklyReport(DateTime.Parse("2022-10-01"), DateTime.Parse("2022-10-07"));
            return View(reportViewModel);
        }
        [HttpPost]
        public IActionResult PayPilotWeeklyReport(ReportViewModel.PayPilotWeeklyReportViewModel reportViewModel)
        {
            if (!ModelState.IsValid)
            {
                reportViewModel.Enumerable = _reportContext.GetPayPilotWeeklyReport(DateTime.Parse("2022-10-01"), DateTime.Parse("2022-10-31"));
                return View(reportViewModel);
            }
            reportViewModel.Enumerable = _reportContext.GetPayPilotWeeklyReport(reportViewModel.Form.From, reportViewModel.Form.From.AddDays(7));
            return View(reportViewModel);
        }
        public IActionResult PilotScheduleReport()
        {
            ReportViewModel.PilotScheduleReportViewModel reportViewModel = new ReportViewModel.PilotScheduleReportViewModel();
            reportViewModel.Enumerable = _reportContext.GetPilotScheduleReport(DateTime.Parse("2022-10-01"), DateTime.Parse("2022-10-07"));
            return View(reportViewModel);
        }
        [HttpPost]
        public IActionResult PilotScheduleReport(ReportViewModel.PilotScheduleReportViewModel reportViewModel)
        {
            if (!ModelState.IsValid)
            {
                reportViewModel.Enumerable = _reportContext.GetPilotScheduleReport(DateTime.Parse("2022-10-01"), DateTime.Parse("2022-10-31"));
                return View(reportViewModel);
            }
            reportViewModel.Enumerable = _reportContext.GetPilotScheduleReport(reportViewModel.Form.From, reportViewModel.Form.To);
            return View(reportViewModel);
        }
        public IActionResult RemainingSeatsOfEachFlightScheduleByClassReport()
        {
            ReportViewModel.RemainingSeatsOfFlightScheduleByClassReportViewModel reportViewModel = new ReportViewModel.RemainingSeatsOfFlightScheduleByClassReportViewModel();
            reportViewModel.Enumerable = _reportContext.GetRemainingSeatsOfFlightScheduleByClassReport();
            return View(reportViewModel);
        }
        public IActionResult WorkingHoursOfCrewReport()
        {
            ReportViewModel.WorkingHoursOfCrewReportViewModel reportViewModel = new ReportViewModel.WorkingHoursOfCrewReportViewModel();
            reportViewModel.Enumerable = _reportContext.GetWorkingHoursOfCrewReport(DateTime.Parse("2022-10-01"), DateTime.Parse("2022-10-07"));
            return View(reportViewModel);
        }
        [HttpPost]
        public IActionResult WorkingHoursOfCrewReport(ReportViewModel.WorkingHoursOfCrewReportViewModel reportViewModel)
        {
            if (!ModelState.IsValid)
            {
                reportViewModel.Enumerable = _reportContext.GetWorkingHoursOfCrewReport(DateTime.Parse("2022-10-01"), DateTime.Parse("2022-10-31"));
                return View(reportViewModel);
            }
            reportViewModel.Enumerable = _reportContext.GetWorkingHoursOfCrewReport(reportViewModel.Form.From, reportViewModel.Form.To);
            return View(reportViewModel);
        }
        public IActionResult WorkingHoursOfPilotReport()
        {
            ReportViewModel.WorkingHoursOfPilotReportModelViewModel reportViewModel = new ReportViewModel.WorkingHoursOfPilotReportModelViewModel();
            reportViewModel.Enumerable = _reportContext.GetWorkingHoursOfPilotReport(DateTime.Parse("2022-10-01"), DateTime.Parse("2022-10-07"));
            return View(reportViewModel);
        }
        [HttpPost]
        public IActionResult WorkingHoursOfPilotReport(ReportViewModel.WorkingHoursOfPilotReportModelViewModel reportViewModel)
        {
            if (!ModelState.IsValid)
            {
                reportViewModel.Enumerable = _reportContext.GetWorkingHoursOfPilotReport(DateTime.Parse("2022-10-01"), DateTime.Parse("2022-10-31"));
                return View(reportViewModel);
            }
            reportViewModel.Enumerable = _reportContext.GetWorkingHoursOfPilotReport(reportViewModel.Form.From, reportViewModel.Form.To);
            return View(reportViewModel);
        }
    }
}
