using ASystem.Models.Context;
using System;

namespace ASystem.Builder
{
    public class SchedulePassengerBuilder
    {
        private SchedulePassengerContextModel _contextModel = new SchedulePassengerContextModel();
        public SchedulePassengerBuilder()
        {
            Reset();
        }
        public void Reset()
        {
            _contextModel = new SchedulePassengerContextModel();
        }
        public void Set(SchedulePassengerContextModel contextModel)
        {
            _contextModel = contextModel;
        }
        public SchedulePassengerBuilder SetSchedulePassengerId(int schedulePassengerId)
        {
            _contextModel.SchedulePassengerId = schedulePassengerId;
            return this;
        }
        public SchedulePassengerBuilder SetFlightScheduleId(int flightScheduleId)
        {
            _contextModel.FlightScheduleId = flightScheduleId;
            return this;
        }
        public SchedulePassengerBuilder SetPassengerId(int passengerId)
        {
            _contextModel.PassengerId = passengerId;
            return this;
        }
        public SchedulePassengerBuilder SetSeatId(int seatId)
        {
            _contextModel.SeatId = seatId;
            return this;
        }
        public SchedulePassengerBuilder SetType(string type)
        {
            _contextModel.Type = type;
            return this;
        }
        public SchedulePassengerBuilder SetStatus(string status)
        {
            _contextModel.Status = status;
            return this;
        }
        public SchedulePassengerContextModel Build()
        {
            SchedulePassengerContextModel model = _contextModel;
            Reset();
            return model;
        }
    }
}