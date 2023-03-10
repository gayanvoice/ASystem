namespace ASystem.Models.Context
{
    public class PayPilotWeeklyReportModel
    {
        public string PilotId { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Pay { get; set; }
        public string Duration { get; set; }
        public string HoursWeekly { get; set; }
        public string PayPerHour { get; set; }
        public string PayOvertime { get; set; }
    }
}