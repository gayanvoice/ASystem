using ASystem.Models.Context;
using System;

namespace ASystem.Builder
{
    public class SchedulePriceBuilder
    {
        private SchedulePriceContextModel _contextModel = new SchedulePriceContextModel();
        public SchedulePriceBuilder()
        {
            Reset();
        }
        public void Reset()
        {
            _contextModel = new SchedulePriceContextModel();
        }
        public void Set(SchedulePriceContextModel contextModel)
        {
            _contextModel = contextModel;
        }
        public SchedulePriceBuilder SetSchedulePriceId(int schedulePriceId)
        {
            _contextModel.SchedulePriceId = schedulePriceId;
            return this;
        }
        public SchedulePriceBuilder SetFlightScheduleId(int flightScheduleId)
        {
            _contextModel.FlightScheduleId = flightScheduleId;
            return this;
        }
        public SchedulePriceBuilder SetClassId(int classId)
        {
            _contextModel.ClassId = classId;
            return this;
        }
        public SchedulePriceBuilder SetPrice(double price)
        {
            _contextModel.Price = price;
            return this;
        }
        public SchedulePriceContextModel Build()
        {
            SchedulePriceContextModel model = _contextModel;
            Reset();
            return model;
        }
    }
}