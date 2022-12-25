using ASystem.Models.Context;

namespace ASystem.Builder
{
    public class AirportBuilder
    {
        private AirportContextModel _airportContextModel = new AirportContextModel();
        public AirportBuilder()
        {
            Reset();
        }
        public void Reset()
        {
            _airportContextModel = new AirportContextModel();
        }
        public void Set(AirportContextModel airportContextModel)
        {
            _airportContextModel = airportContextModel;
        }
        public AirportBuilder SetAirportId(int airportId)
        {
            _airportContextModel.AirportId = airportId;
            return this;
        }
        public AirportBuilder SetCode(string code)
        {
            _airportContextModel.Code = code;
            return this;
        }
        public AirportBuilder SetName(string name)
        {
            _airportContextModel.Name = name;
            return this;
        }
        public AirportBuilder SetCity(string city)
        {
            _airportContextModel.City = city;
            return this;
        }
        public AirportBuilder SetCountry(string country)
        {
            _airportContextModel.Country = country;
            return this;
        }
        public AirportContextModel Build()
        {
            AirportContextModel model = _airportContextModel;
            Reset();
            return model;
        }
    }
}