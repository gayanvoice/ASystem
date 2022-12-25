using ASystem.Models.Context;
using System;

namespace ASystem.Builder
{
    public class PassportBuilder
    {
        private PassportContextModel _passportContextModel = new PassportContextModel();
        public PassportBuilder()
        {
            Reset();
        }
        public void Reset()
        {
            _passportContextModel = new PassportContextModel();
        }
        public void Set(PassportContextModel passportContextModel)
        {
            _passportContextModel = passportContextModel;
        }
        public PassportBuilder SetPassportId(int passportId)
        {
            _passportContextModel.PassportId = passportId;
            return this;
        }
        public PassportBuilder SetPassportNo(string passportNo)
        {
            _passportContextModel.PassportNo = passportNo;
            return this;
        }
        public PassportBuilder SetType(string type)
        {
            _passportContextModel.Type = type;
            return this;
        }
        public PassportBuilder SetCountryCode(string countryCode)
        {
            _passportContextModel.CountryCode = countryCode;
            return this;
        }
        public PassportBuilder SetSurname(string surname)
        {
            _passportContextModel.Surname = surname;
            return this;
        }
        public PassportBuilder SetOtherName(string otherName)
        {
            _passportContextModel.OtherName = otherName;
            return this;
        }
        public PassportBuilder SetNationalStatus(string nationalStatus)
        {
            _passportContextModel.NationalStatus = nationalStatus;
            return this;
        }
        public PassportBuilder SetDateOfBirth(DateTime dateOfBirth)
        {
            _passportContextModel.DateOfBirth = dateOfBirth.Date;
            return this;
        }
        public PassportBuilder SetIdNo(string idNo)
        {
            _passportContextModel.IdNo = idNo;
            return this;
        }
        public PassportBuilder SetProfession(string profession)
        {
            _passportContextModel.Profession = profession;
            return this;
        }
        public PassportBuilder SetSex(string sex)
        {
            _passportContextModel.Sex = sex;
            return this;
        }
        public PassportBuilder SetPlaceOfBirth(string placeOfBirth)
        {
            _passportContextModel.PlaceOfBirth = placeOfBirth;
            return this;
        }
        public PassportBuilder SetDateOfIssue(DateTime dateOfIssue)
        {
            _passportContextModel.DateOfIssue = dateOfIssue.Date;
            return this;
        }
        public PassportBuilder SetDateOfExpiry(DateTime dateOfExpiry)
        {
            _passportContextModel.DateOfExpiry = dateOfExpiry.Date;
            return this;
        }
        public PassportBuilder SetAuthority(string authority)
        {
            _passportContextModel.Authority = authority;
            return this;
        }
        public PassportBuilder SetStatus(string status)
        {
            _passportContextModel.Status = status;
            return this;
        }
        public PassportContextModel Build()
        {
            PassportContextModel model = _passportContextModel;
            Reset();
            return model;
        }
    }
}