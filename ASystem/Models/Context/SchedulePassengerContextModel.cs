namespace ASystem.Models.Context
{
    public class SchedulePassengerContextModel
    {
        public int SchedulePassengerId { get; set; } //11
        public int FlightScheduleId { get; set; } //11
        public int PassengerId { get; set; } //11
        public int SeatId { get; set; } //11
        public string Type { get; set; } // 20
        public string Status { get; set; } // 20
    }
}