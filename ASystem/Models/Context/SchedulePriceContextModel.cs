namespace ASystem.Models.Context
{
    public class SchedulePriceContextModel
    {
        public int SchedulePriceId { get; set; } //11
        public int FlightScheduleId { get; set; } //11
        public int ClassId { get; set; } //11
        public double Price { get; set; }
    }
}