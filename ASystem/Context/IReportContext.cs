using ASystem.Models.Context;
using System;
using System.Collections.Generic;

namespace ASystem.Context
{
    public interface IReportContext
    {
        IEnumerable<CrewScheduleReportModel> GetCrewScheduleReport(DateTime From, DateTime To);
        IEnumerable<FlightScheduleWithDestinationReportModel> GetFlightScheduleWithDestinationReport();
    }
}