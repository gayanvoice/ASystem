using ASystem.Models.Context;
using ASystem.Models.Procedure;
using System.Collections.Generic;

namespace ASystem.Context
{
    public interface ISchedulePilotContext
    {
        int Delete(int schedulePilotId);
        int Insert(SchedulePilotContextModel schedulePilotContextModel);
        SchedulePilotContextModel Select(int schedulePilotId);
        IEnumerable<SchedulePilotContextModel> SelectAll();
        IEnumerable<SchedulePilotProcedureModel> GetAllSchedulePilot();
        int Update(SchedulePilotContextModel schedulePilotContextModel);
    }
}