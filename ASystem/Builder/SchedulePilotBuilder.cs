using ASystem.Models.Context;
using System;

namespace ASystem.Builder
{
    public class SchedulePilotBuilder
    {
        private SchedulePilotContextModel _contextModel = new SchedulePilotContextModel();
        public SchedulePilotBuilder()
        {
            Reset();
        }
        public void Reset()
        {
            _contextModel = new SchedulePilotContextModel();
        }
        public void Set(SchedulePilotContextModel contextModel)
        {
            _contextModel = contextModel;
        }
        public SchedulePilotBuilder SetSchedulePilotId(int schedulePilotId)
        {
            _contextModel.SchedulePilotId = schedulePilotId;
            return this;
        }
        public SchedulePilotBuilder SetFlightScheduleId(int flightScheduleId)
        {
            _contextModel.FlightScheduleId = flightScheduleId;
            return this;
        }
        public SchedulePilotBuilder SetPilotId(int pilotId)
        {
            _contextModel.PilotId = pilotId;
            return this;
        }
        public SchedulePilotBuilder SetTimeIn(DateTime timeIn)
        {
            _contextModel.TimeIn = timeIn;
            return this;
        }
        public SchedulePilotBuilder SetTimeOut(DateTime timeOut)
        {
            _contextModel.TimeOut = timeOut;
            return this;
        }
        public SchedulePilotBuilder SetStatus(string status)
        {
            _contextModel.Status = status;
            return this;
        }
        public SchedulePilotContextModel Build()
        {
            SchedulePilotContextModel model = _contextModel;
            Reset();
            return model;
        }
    }
}