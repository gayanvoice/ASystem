using ASystem.Models.Context;

namespace ASystem.Builder
{
    public class CrewBuilder
    {
        private CrewContextModel _contextModel = new CrewContextModel();
        public CrewBuilder()
        {
            Reset();
        }
        public void Reset()
        {
            _contextModel = new CrewContextModel();
        }
        public void Set(CrewContextModel contextModel)
        {
            _contextModel = contextModel;
        }
        public CrewBuilder SetCrewId(int crewId)
        {
            _contextModel.CrewId = crewId;
            return this;
        }
        public CrewBuilder SetEmployeeId(int employeeId)
        {
            _contextModel.EmployeeId = employeeId;
            return this;
        }
        public CrewContextModel Build()
        {
            CrewContextModel model = _contextModel;
            Reset();
            return model;
        }
    }
}