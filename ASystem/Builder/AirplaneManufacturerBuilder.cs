using ASystem.Enum;
using ASystem.Models.Context;
using ASystem.Singleton;

namespace ASystem.Builder
{
    public class AirplaneManufacturerBuilder
    {
        private AirplaneManufacturerContextModel _airplaneManufacturerContextModel = new AirplaneManufacturerContextModel();
        public AirplaneManufacturerBuilder()
        {
            Reset();
        }
        public void Reset()
        {
            _airplaneManufacturerContextModel = new AirplaneManufacturerContextModel();
        }
        public void Set(AirplaneManufacturerContextModel airplaneManufacturerContextModel)
        {
            _airplaneManufacturerContextModel = airplaneManufacturerContextModel;
        }
        public AirplaneManufacturerBuilder SetAirplaneManufacturerId(int airplaneManufacturerId)
        {
            _airplaneManufacturerContextModel.AirplaneManufacturerId = airplaneManufacturerId;
            return this;
        }
        public AirplaneManufacturerBuilder SetName(string name)
        {
            _airplaneManufacturerContextModel.Name = name;
            return this;
        }
        public AirplaneManufacturerBuilder SetCountry(string country)
        {
            _airplaneManufacturerContextModel.Country = country;
            return this;
        }
        public AirplaneManufacturerContextModel Build()
        {
            AirplaneManufacturerContextModel model = _airplaneManufacturerContextModel;
            Reset();
            return model;
        }
    }
}
