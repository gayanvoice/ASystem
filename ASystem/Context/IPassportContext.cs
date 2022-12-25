using ASystem.Models.Context;
using System.Collections.Generic;

namespace ASystem.Context
{
    public interface IPassportContext
    {
        int Delete(int passportId);
        int Insert(PassportContextModel passportContextModel);
        PassportContextModel Select(int jobId);
        IEnumerable<PassportContextModel> SelectAll();
        int Update(PassportContextModel passportContextModel);
    }
}