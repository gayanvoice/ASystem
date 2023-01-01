using ASystem.Enum;
using ASystem.Models.Component;
using ASystem.Models.Context;
using System.Collections.Generic;

namespace ASystem.Models.View
{
    public class ReportViewModel
    {
        public CrewScheduleReportViewModel CrewScheduleReport { get; set; }
        public FlightScheduleWithDestinationReportViewModel FlightScheduleWithDestinationReport { get; set; }
        public PassengersByFlightScheduleReportViewModel PassengersByFlightScheduleReport { get; set; }
        public PayCrewWeeklyReportViewModel PayCrewWeeklyReport { get; set; }
        public PayPilotWeeklyReportViewModel PayPilotWeeklyReport { get; set; }
        public PilotScheduleReportViewModel PilotScheduleReport { get; set; }
        public RemainingSeatsOfFlightScheduleByClassReportViewModel RemainingSeatsOfFlightScheduleByClassReport { get; set; }
        public WorkingHoursOfCrewReportViewModel WorkingHoursOfCrewReport { get; set; }
        public WorkingHoursOfPilotReportModelViewModel WorkingHoursOfPilotReport { get; set; }
        public class CrewScheduleReportViewModel
        {
            public IEnumerable<CrewScheduleReportModel> Enumerable { get; set; }
        }
        public class FlightScheduleWithDestinationReportViewModel
        {
            public IEnumerable<FlightScheduleWithDestinationReportModel> Enumerable { get; set; }
        }
        public class PassengersByFlightScheduleReportViewModel
        {
            public IEnumerable<PassengersByFlightScheduleReportModel> Enumerable { get; set; }
        }
        public class PayCrewWeeklyReportViewModel
        {
            public IEnumerable<PayCrewWeeklyReportModel> Enumerable { get; set; }
        }
        public class PayPilotWeeklyReportViewModel
        {
            public IEnumerable<PayPilotWeeklyReportModel> Enumerable { get; set; }
        }
        public class PilotScheduleReportViewModel
        {
            public IEnumerable<PilotScheduleReportModel> Enumerable { get; set; }
        }
        public class RemainingSeatsOfFlightScheduleByClassReportViewModel
        {
            public IEnumerable<RemainingSeatsOfFlightScheduleByClassReportModel> Enumerable { get; set; }
        }
        public class WorkingHoursOfCrewReportViewModel
        {
            public IEnumerable<WorkingHoursOfCrewReportModel> Enumerable { get; set; }
        }
        public class WorkingHoursOfPilotReportModelViewModel
        {
            public IEnumerable<WorkingHoursOfPilotReportModel> Enumerable { get; set; }
        }
    }
}