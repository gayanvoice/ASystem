using ASystem.Context;
using ASystem.Models.Context;
using ASystem.Singleton;
using System.Collections.Generic;

namespace SASystem.Context
{
    public class PassportContext : IPassportContext
    {
        public int Delete(int passportId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "DELETE FROM Passport WHERE PassportId IN (@PassportId)";
            object param = new { PassportId = passportId };
            return mySqlSingleton.Delete(query, param);
        }
        public int Insert(PassportContextModel passportContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "INSERT INTO Passport (PassportNo, Type, CountryCode, Surname, OtherName, NationalStatus, DateOfBirth, IdNo, Profession, Sex, PlaceOfBirth, DateOfIssue, DateOfExpiry, Authority, Status)" +
                " values (@PassportNo, @Type, @CountryCode, @Surname, @OtherName, @NationalStatus, @DateOfBirth, @IdNo, @Profession, @Sex, @PlaceOfBirth, @DateOfIssue, @DateOfExpiry, @Authority, @Status)";
            return mySqlSingleton.Insert(query, passportContextModel);
        }
        public PassportContextModel Select(int passportId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "SELECT * FROM Passport WHERE PassportId IN (@PassportId)";
            object param = new { PassportId = passportId };
            return mySqlSingleton.Select<PassportContextModel>(query, param);
        }
        public IEnumerable<PassportContextModel> SelectAll()
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "SELECT * FROM Passport";
            return mySqlSingleton.SelectAll<PassportContextModel>(query);
        }
        public int Update(PassportContextModel passportContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = "UPDATE Passport SET PassportNo = @PassportNo, Type = @Type, CountryCode =  @CountryCode, Surname = @Surname, OtherName = @OtherName, NationalStatus = @NationalStatus, DateOfBirth = @DateOfBirth, IdNo = @IdNo," +
                " Profession = @Profession, Sex = @Sex, PlaceOfBirth = @PlaceOfBirth, DateOfIssue = @DateOfIssue, DateOfExpiry = @DateOfExpiry, Authority = @Authority, Status = @Status WHERE PassportId IN (@PassportId)";
            return mySqlSingleton.Update(query, passportContextModel);
        }
    }
}