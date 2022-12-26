using ASystem.Models.Context;
using System;

namespace ASystem.Builder
{
    public class FlightScheduleBuilder
    {
        private FlightScheduleContextModel _contextModel = new FlightScheduleContextModel();
        public FlightScheduleBuilder()
        {
            Reset();
        }
        public void Reset()
        {
            _contextModel = new FlightScheduleContextModel();
        }
        public void Set(FlightScheduleContextModel contextModel)
        {
            _contextModel = contextModel;
        }
        public FlightScheduleBuilder SetFlightScheduleId(int flightScheduleId)
        {
            _contextModel.FlightScheduleId = flightScheduleId;
            return this;
        }
        public FlightScheduleBuilder SetAirplaneId(int airplaneId)
        {
            _contextModel.AirplaneId = airplaneId;
            return this;
        }
        public FlightScheduleBuilder SetAirportIdOriginId(int airportIdOriginId)
        {
            _contextModel.AirportIdOriginId = airportIdOriginId;
            return this;
        }
        public FlightScheduleBuilder SetAirportIdDestinationId(int airportIdDestinationId)
        {
            _contextModel.AirportIdDestinationId = airportIdDestinationId;
            return this;
        }
        public FlightScheduleBuilder SetType(string type)
        {
            _contextModel.Type = type;
            return this;
        }
        public FlightScheduleBuilder SetDepartureTime(DateTime departureTime)
        {
            _contextModel.DepartureTime = departureTime;
            return this;
        }
        public FlightScheduleBuilder SetArriveTime(DateTime arriveTime)
        {
            _contextModel.ArriveTime = arriveTime;
            return this;
        }
        public FlightScheduleBuilder SetStatus(string status)
        {
            _contextModel.Status = status;
            return this;
        }
        public FlightScheduleContextModel Build()
        {
            FlightScheduleContextModel model = _contextModel;
            Reset();
            return model;
        }
    }
}