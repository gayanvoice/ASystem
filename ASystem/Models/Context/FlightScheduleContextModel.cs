using System;

namespace ASystem.Models.Context
{
    public class FlightScheduleContextModel
    {
        public int FlightScheduleId { get; set; } //11
        public int AirplaneId { get; set; } //11
        public int AirportIdOriginId { get; set; } //11
        public int AirportIdDestinationId { get; set; } //11
        public string Type { get; set; } //20
        public DateTime DepartureTime { get; set; }
        public DateTime ArriveTime { get; set; }
        public string Status { get; set; } //20
    }
}