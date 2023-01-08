namespace ASystem.Models.Procedure
{
    public class ScheduleCrewProcedureModel
    {
        public string ScheduleCrewId { get; set; }
        public string Name { get; set; }
        public string EmployeeName { get; set; }
        public string FlightScheduleId { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Airplane { get; set; }
        public string Status { get; set; }
    }
}