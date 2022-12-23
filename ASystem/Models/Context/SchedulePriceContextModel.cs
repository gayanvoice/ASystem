namespace ASystem.Models.Context
{
    public class SchedulePriceContextModel
    {
        public int SchedulePilotId { get; set; } //11
        public int FlightScheduleId { get; set; } //11
        public int ClassId { get; set; } //11
        public double Price { get; set; }
    }
}