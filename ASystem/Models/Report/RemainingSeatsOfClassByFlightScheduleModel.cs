namespace ASystem.Models.Context
{
    public class RemainingSeatsOfClassByFlightScheduleReportModel
    {
        public int FlightScheduleId { get; }
        public int ClassId { get; set; }
        public string Name { get; set; }
        public int NoOfBookedSeats { get; set; }
        public int NoOfRemainingSeats { get; set; }
        public int TotalSeats { get; set; }
    }
}