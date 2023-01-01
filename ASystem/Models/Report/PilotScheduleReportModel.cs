namespace ASystem.Models.Context
{
    public class PilotScheduleReportModel
    {
        public string PilotId { get; set; }
        public string FlightScheduleId { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
    }
}