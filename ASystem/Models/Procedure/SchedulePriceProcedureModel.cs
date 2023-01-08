namespace ASystem.Models.Procedure
{
    public class SchedulePriceProcedureModel
    {
        public string SchedulePriceId { get; set; }
        public string FlightScheduleId { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Airplane { get; set; }
    }
}