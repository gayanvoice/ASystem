using ASystem.Models.Context;
using ASystem.Models.Procedure;
using System.Collections.Generic;

namespace ASystem.Context
{
    public interface IScheduleCrewContext
    {
        int Delete(int scheduleCrewId);
        int Insert(ScheduleCrewContextModel scheduleCrewContextModel);
        ScheduleCrewContextModel Select(int scheduleCrewId);
        IEnumerable<ScheduleCrewContextModel> SelectAll();
        IEnumerable<ScheduleCrewProcedureModel> GetAllScheduleCrew();
        int Update(ScheduleCrewContextModel scheduleCrewContextModel);
    }
}