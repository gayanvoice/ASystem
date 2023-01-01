namespace ASystem.Models.Context
{
    public class WorkingHoursOfPilotReportModel
    {
        public string PilotId { get; set; }
        public string EmployeeId { get; set; }
        public string Name { get; set; }
        public string Hour { get; set; }
        public string Minute { get; set; }
        public string Second { get; set; }
    }
}