namespace ASystem.Models.Procedure
{
    public class SchedulePassengerProcedureModel
    {
        public string SchedulePassengerId { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string PassportNo { get; set; }
        public string SeatId { get; set; }
        public string FlightScheduleId { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Airplane { get; set; }
        public string Status { get; set; }
    }
}