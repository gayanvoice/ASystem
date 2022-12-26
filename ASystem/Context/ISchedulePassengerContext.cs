using ASystem.Models.Context;
using System.Collections.Generic;

namespace ASystem.Context
{
    public interface ISchedulePassengerContext
    {
        int Delete(int schedulePassengerId);
        int Insert(SchedulePassengerContextModel schedulePassengerContextModel);
        SchedulePassengerContextModel Select(int schedulePassengerId);
        IEnumerable<SchedulePassengerContextModel> SelectAll();
        int Update(SchedulePassengerContextModel schedulePassengerContextModel);
    }
}