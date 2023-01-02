using ASystem.Models.Context;
using ASystem.Models.Procedure;
using System.Collections.Generic;

namespace ASystem.Context
{
    public interface ISchedulePassengerContext
    {
        int Delete(int schedulePassengerId);
        int Insert(SchedulePassengerContextModel schedulePassengerContextModel);
        SchedulePassengerContextModel Select(int schedulePassengerId);
        IEnumerable<SchedulePassengerContextModel> SelectAll();
        IEnumerable<SchedulePassengerProcedureModel> GetAllSchedulePassenger();
        int Update(SchedulePassengerContextModel schedulePassengerContextModel);
    }
}