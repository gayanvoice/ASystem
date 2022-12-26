using ASystem.Models.Context;

namespace ASystem.Builder
{
    public class AirplaneModelBuilder
    {
        private AirplaneModelContextModel _contextModel = new AirplaneModelContextModel();
        public AirplaneModelBuilder()
        {
            Reset();
        }
        public void Reset()
        {
            _contextModel = new AirplaneModelContextModel();
        }
        public void Set(AirplaneModelContextModel contextModel)
        {
            _contextModel = contextModel;
        }
        public AirplaneModelBuilder SetAirplaneModelId(int airplaneModelId)
        {
            _contextModel.AirplaneModelId = airplaneModelId;
            return this;
        }
        public AirplaneModelBuilder SetAirplaneManufacturerId(int airplaneManufacturerId)
        {
            _contextModel.AirplaneManufacturerId = airplaneManufacturerId;
            return this;
        }
        public AirplaneModelBuilder SetName(string name)
        {
            _contextModel.Name = name;
            return this;
        }
        public AirplaneModelBuilder SetSubModel(string subModel)
        {
            _contextModel.SubModel = subModel;
            return this;
        }
        public AirplaneModelContextModel Build()
        {
            AirplaneModelContextModel model = _contextModel;
            Reset();
            return model;
        }
    }
}