using ASystem.Models.Context;
using System.Collections.Generic;

namespace ASystem.Context
{
    public interface IAirplaneContext
    {
        int Delete(int airplaneId);
        int Insert(AirplaneContextModel airplaneContextModel);
        AirplaneContextModel Select(int airplaneId);
        IEnumerable<AirplaneContextModel> SelectAll();
        int Update(AirplaneContextModel airplaneContextModel);
    }
}