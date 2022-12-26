using ASystem.Models.Context;

namespace ASystem.Builder
{
    public class AirplaneBuilder
    {
        private AirplaneContextModel _contextModel = new AirplaneContextModel();
        public AirplaneBuilder()
        {
            Reset();
        }
        public void Reset()
        {
            _contextModel = new AirplaneContextModel();
        }
        public void Set(AirplaneContextModel contextModel)
        {
            _contextModel = contextModel;
        }
        public AirplaneBuilder SetAirplaneId(int airplaneId)
        {
            _contextModel.AirplaneId = airplaneId;
            return this;
        }
        public AirplaneBuilder SetAirplaneModelId(int airplaneModelId)
        {
            _contextModel.AirplaneModelId = airplaneModelId;
            return this;
        }
        public AirplaneBuilder SetFlightNumber(string flightNumber)
        {
            _contextModel.FlightNumber = flightNumber;
            return this;
        }
        public AirplaneBuilder SetStatus(int status)
        {
            _contextModel.Status = status;
            return this;
        }
        public AirplaneContextModel Build()
        {
            AirplaneContextModel model = _contextModel;
            Reset();
            return model;
        }
    }
}