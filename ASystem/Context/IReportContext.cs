using ASystem.Models.Context;
using System;
using System.Collections.Generic;

namespace ASystem.Context
{
    public interface IReportContext
    {
        IEnumerable<CrewScheduleReportModel> GetCrewScheduleReport(DateTime From, DateTime To);
        IEnumerable<FlightScheduleWithDestinationReportModel> GetFlightScheduleWithDestinationReport();
        IEnumerable<PassengersByFlightScheduleReportModel> GetPassengersByFlightScheduleReport();
        IEnumerable<PayCrewWeeklyReportModel> GetPayCrewWeeklyReport(DateTime From, DateTime To);
        IEnumerable<PayPilotWeeklyReportModel> GetPayPilotWeeklyReport(DateTime From, DateTime To);
        IEnumerable<PilotScheduleReportModel> GetPilotScheduleReport(DateTime From, DateTime To);
        IEnumerable<RemainingSeatsOfFlightScheduleByClassReportModel> GetRemainingSeatsOfFlightScheduleByClassReport();
        IEnumerable<WorkingHoursOfCrewReportModel> GetWorkingHoursOfCrewReport(DateTime From, DateTime To);
        IEnumerable<WorkingHoursOfPilotReportModel> GetWorkingHoursOfPilotReport(DateTime From, DateTime To);
    }
}