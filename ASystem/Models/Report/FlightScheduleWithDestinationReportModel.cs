namespace ASystem.Models.Context
{
    public class FlightScheduleWithDestinationReportModel
    {
        public int FlightScheduleId { get; set; }
        public string FlightName { get; set; }
        public string FlightNumber { get; set; }
        public string DepartureTime { get; set; }
        public string ArriveTime { get; set; }
        public int DurationHours { get; set; }
        public int DurationInMinutes { get; set; }
        //public int DurationInSeconds { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Type { get; set; }
    }
}