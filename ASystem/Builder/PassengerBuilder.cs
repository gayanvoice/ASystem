using ASystem.Models.Context;
using System;

namespace ASystem.Builder
{
    public class PassengerBuilder
    {
        private PassengerContextModel _contextModel = new PassengerContextModel();
        public PassengerBuilder()
        {
            Reset();
        }
        public void Reset()
        {
            _contextModel = new PassengerContextModel();
        }
        public void Set(PassengerContextModel contextModel)
        {
            _contextModel = contextModel;
        }
        public PassengerBuilder SetPassengerId(int passengerId)
        {
            _contextModel.PassengerId = passengerId;
            return this;
        }
        public PassengerBuilder SetPassportId(int passportId)
        {
            _contextModel.PassportId = passportId;
            return this;
        }
        public PassengerBuilder SetPhone(int phone)
        {
            _contextModel.Phone = phone;
            return this;
        }
        public PassengerContextModel Build()
        {
            PassengerContextModel model = _contextModel;
            Reset();
            return model;
        }
    }
}