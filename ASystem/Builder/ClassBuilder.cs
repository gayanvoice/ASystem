using ASystem.Models.Context;

namespace ASystem.Builder
{
    public class ClassBuilder
    {
        private ClassContextModel _contextModel = new ClassContextModel();
        public ClassBuilder()
        {
            Reset();
        }
        public void Reset()
        {
            _contextModel = new ClassContextModel();
        }
        public void Set(ClassContextModel contextModel)
        {
            _contextModel = contextModel;
        }
        public ClassBuilder SetClassId(int classId)
        {
            _contextModel.ClassId = classId;
            return this;
        }
        public ClassBuilder SetAirplaneId(int airplaneId)
        {
            _contextModel.AirplaneId = airplaneId;
            return this;
        }
        public ClassBuilder SetName(string name)
        {
            _contextModel.Name = name;
            return this;
        }
        public ClassBuilder SetSubClass(string subClass)
        {
            _contextModel.SubClass = subClass;
            return this;
        }
        public ClassBuilder SetNoOfSeats(int noOfSeats)
        {
            _contextModel.NoOfSeats = noOfSeats;
            return this;
        }
        public ClassBuilder SetBaggageSize(int baggageSize)
        {
            _contextModel.BaggageSize = baggageSize;
            return this;
        }
        public ClassBuilder SetCabinBaggageSize(int cabinBaggageSize)
        {
            _contextModel.CabinBaggageSize = cabinBaggageSize;
            return this;
        }
        public ClassBuilder SetIsSeatSelection(int isSeatSelection)
        {
            _contextModel.IsSeatSelection = isSeatSelection;
            return this;
        }
        public ClassBuilder SetIsSkywardsMiles(int isSkywardsMiles)
        {
            _contextModel.IsSkywardsMiles = isSkywardsMiles;
            return this;
        }
        public ClassBuilder SetIsUpgrade(int isUpgrade)
        {
            _contextModel.IsUpgrade = isUpgrade;
            return this;
        }
        public ClassBuilder SetIsChangeFee(int isChangeFee)
        {
            _contextModel.IsChangeFee = isChangeFee;
            return this;
        }
        public ClassBuilder SetIsRefundFee(int isRefundFee)
        {
            _contextModel.IsRefundFee = isRefundFee;
            return this;
        }
        public ClassContextModel Build()
        {
            ClassContextModel model = _contextModel;
            Reset();
            return model;
        }
    }
}