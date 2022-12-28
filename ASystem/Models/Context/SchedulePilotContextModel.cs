using System;

namespace ASystem.Models.Context
{
    public class SchedulePilotContextModel
    {
        public int SchedulePilotId { get; set; } //11
        public int FlightScheduleId { get; set; } //11
        public int PilotId { get; set; } //11
        public DateTime TimeIn{ get; set; }
        public DateTime TimeOut{ get; set; }
        public string Status { get; set; } // 20
    }
}