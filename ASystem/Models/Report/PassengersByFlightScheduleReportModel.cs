namespace ASystem.Models.Context
{
    public class PassengersByFlightScheduleReportModel
    {
        public int FlightScheduleId { get; set; }
        public int Count { get; set; }
        public string Airplane { get; set; }
        public string FlightNumber { get; set; }
    }
}