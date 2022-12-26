using ASystem.Models.Context;
using System;

namespace ASystem.Builder
{
    public class PilotBuilder
    {
        private PilotContextModel _contextModel = new PilotContextModel();
        public PilotBuilder()
        {
            Reset();
        }
        public void Reset()
        {
            _contextModel = new PilotContextModel();
        }
        public void Set(PilotContextModel contextModel)
        {
            _contextModel = contextModel;
        }
        public PilotBuilder SetPilotId(int pilotId)
        {
            _contextModel.PilotId = pilotId;
            return this;
        }
        public PilotBuilder SetEmployeeId(int employeeId)
        {
            _contextModel.EmployeeId = employeeId;
            return this;
        }
        public PilotBuilder SetAirplaneModelId(int airplaneModelId)
        {
            _contextModel.AirplaneModelId = airplaneModelId;
            return this;
        }
        public PilotBuilder SetRatings(int ratings)
        {
            _contextModel.Ratings = ratings;
            return this;
        }
        public PilotContextModel Build()
        {
            PilotContextModel model = _contextModel;
            Reset();
            return model;
        }
    }
}