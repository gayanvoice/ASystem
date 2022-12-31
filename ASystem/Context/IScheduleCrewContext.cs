using ASystem.Models.Context;
using System.Collections.Generic;

namespace ASystem.Context
{
    public interface IScheduleCrewContext
    {
        int Delete(int scheduleCrewId);
        int Insert(ScheduleCrewContextModel scheduleCrewContextModel);
        ScheduleCrewContextModel Select(int scheduleCrewId);
        IEnumerable<ScheduleCrewContextModel> SelectAll();
        int Update(ScheduleCrewContextModel scheduleCrewContextModel);
    }
}