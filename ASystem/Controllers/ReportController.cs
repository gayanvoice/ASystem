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
        public IActionResult FlightScheduleWithDestinationReport()
        {
            ReportViewModel.FlightScheduleWithDestinationReportViewModel reportViewModel = new ReportViewModel.FlightScheduleWithDestinationReportViewModel();
            reportViewModel.Enumerable = _reportContext.GetFlightScheduleWithDestinationReport();
            return View(reportViewModel);
        }
    }
}
