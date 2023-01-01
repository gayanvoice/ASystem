namespace ASystem.Models.Context
{
    public class RemainingSeatsOfFlightScheduleByClassReportModel
    {
        public int ClassId { get; set; }
        public string Name { get; set; }
        public int Remaining { get; set; }
        public int Reserve { get; set; }
        public int Total { get; set; }
    }
}