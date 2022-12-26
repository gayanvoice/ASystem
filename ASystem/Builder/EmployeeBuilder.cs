using ASystem.Models.Context;
using System;

namespace ASystem.Builder
{
    public class EmployeeBuilder
    {
        private EmployeeContextModel _contextModel = new EmployeeContextModel();
        public EmployeeBuilder()
        {
            Reset();
        }
        public void Reset()
        {
            _contextModel = new EmployeeContextModel();
        }
        public void Set(EmployeeContextModel contextModel)
        {
            _contextModel = contextModel;
        }
        public EmployeeBuilder SetEmployeeId(int employeeId)
        {
            _contextModel.EmployeeId = employeeId;
            return this;
        }
        public EmployeeBuilder SetJobId(int jobId)
        {
            _contextModel.JobId = jobId;
            return this;
        }
        public EmployeeBuilder SetSurname(string surname)
        {
            _contextModel.Surname = surname;
            return this;
        }
        public EmployeeBuilder SetOtherName(string otherName)
        {
            _contextModel.OtherName = otherName;
            return this;
        }
        public EmployeeBuilder SetDateOfBirth(DateTime dateOfBirth)
        {
            _contextModel.DateOfBirth = dateOfBirth;
            return this;
        }
        public EmployeeBuilder SetAddress(string address)
        {
            _contextModel.Address = address;
            return this;
        }
        public EmployeeBuilder SetPhone(int phone)
        {
            _contextModel.Phone = phone;
            return this;
        }
        public EmployeeBuilder SetStatus(string status)
        {
            _contextModel.Status = status;
            return this;
        }
        public EmployeeContextModel Build()
        {
            EmployeeContextModel model = _contextModel;
            Reset();
            return model;
        }
    }
}