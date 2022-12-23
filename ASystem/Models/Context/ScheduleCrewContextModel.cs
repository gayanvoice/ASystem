using System;

namespace ASystem.Models.Context
{
    public class ScheduleCrewContextModel
    {
        public int ScheduleCrewId { get; set; } //11
        public int FlightScheduleId { get; set; } //11
        public int CrewId { get; set; } //11
        public DateTime TimeIn{ get; set; }
        public DateTime TimeOut{ get; set; }
    }
}