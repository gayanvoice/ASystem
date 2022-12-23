namespace ASystem.Models.Context
{
    public class JobContextModel
    {
        public int JobId { get; set; } //11
        public string Name { get; set; } //45
        public double PayPerHour { get; set; }
        public double PayOverTime{ get; set; }
        public double HoursWeekly { get; set; }
    }
}