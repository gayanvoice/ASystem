using ASystem.Models.Context;
using System;

namespace ASystem.Builder
{
    public class ScheduleCrewBuilder
    {
        private ScheduleCrewContextModel _contextModel = new ScheduleCrewContextModel();
        public ScheduleCrewBuilder()
        {
            Reset();
        }
        public void Reset()
        {
            _contextModel = new ScheduleCrewContextModel();
        }
        public void Set(ScheduleCrewContextModel contextModel)
        {
            _contextModel = contextModel;
        }
        public ScheduleCrewBuilder SetScheduleCrewId(int scheduleCrewId)
        {
            _contextModel.ScheduleCrewId = scheduleCrewId;
            return this;
        }
        public ScheduleCrewBuilder SetFlightScheduleId(int flightScheduleId)
        {
            _contextModel.FlightScheduleId = flightScheduleId;
            return this;
        }
        public ScheduleCrewBuilder SetCrewId(int crewId)
        {
            _contextModel.CrewId = crewId;
            return this;
        }
        public ScheduleCrewBuilder SetTimeIn(DateTime timeIn)
        {
            _contextModel.TimeIn = timeIn;
            return this;
        }
        public ScheduleCrewBuilder SetTimeOut(DateTime timeOut)
        {
            _contextModel.TimeOut = timeOut;
            return this;
        }
        public ScheduleCrewContextModel Build()
        {
            ScheduleCrewContextModel model = _contextModel;
            Reset();
            return model;
        }
    }
}