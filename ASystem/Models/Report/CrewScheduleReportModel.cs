namespace ASystem.Models.Context
{
    public class CrewScheduleReportModel
    {
        public string CrewId { get; set; }
        public string FlightScheduleId { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
    }
}