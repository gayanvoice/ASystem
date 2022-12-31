using ASystem.Models.Context;
using System.Collections.Generic;

namespace ASystem.Context
{
    public interface IPilotContext
    {
        int Delete(int pilotId);
        int Insert(PilotContextModel pilotContextModel);
        PilotContextModel Select(int pilotId);
        IEnumerable<PilotContextModel> SelectAll();
        int Update(PilotContextModel pilotContextModel);
    }
}