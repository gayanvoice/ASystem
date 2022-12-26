using ASystem.Models.Context;
using System.Collections.Generic;

namespace ASystem.Context
{
    public interface IAirplaneModelContext
    {
        int Delete(int airplaneModelId);
        int Insert(AirplaneModelContextModel airplaneModelContextModel);
        AirplaneModelContextModel Select(int airplaneModelId);
        IEnumerable<AirplaneModelContextModel> SelectAll();
        int Update(AirplaneModelContextModel airplaneModelContextModel);
    }
}