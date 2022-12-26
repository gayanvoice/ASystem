using ASystem.Models.Context;
using System;

namespace ASystem.Builder
{
    public class SeatBuilder
    {
        private SeatContextModel _contextModel = new SeatContextModel();
        public SeatBuilder()
        {
            Reset();
        }
        public void Reset()
        {
            _contextModel = new SeatContextModel();
        }
        public void Set(SeatContextModel contextModel)
        {
            _contextModel = contextModel;
        }
        public SeatBuilder SetSeatId(int seatId)
        {
            _contextModel.SeatId = seatId;
            return this;
        }
        public SeatBuilder SetClassId(int classId)
        {
            _contextModel.ClassId = classId;
            return this;
        }
        public SeatBuilder SetSeatNo(int seatNo)
        {
            _contextModel.SeatNo = seatNo;
            return this;
        }
        public SeatContextModel Build()
        {
            SeatContextModel model = _contextModel;
            Reset();
            return model;
        }
    }
}