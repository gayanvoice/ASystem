using ASystem.Models.Context;
using ASystem.Models.Procedure;
using System.Collections.Generic;

namespace ASystem.Context
{
    public interface ISchedulePriceContext
    {
        int Delete(int schedulePriceId);
        int Insert(SchedulePriceContextModel schedulePriceContextModel);
        SchedulePriceContextModel Select(int schedulePriceId);
        IEnumerable<SchedulePriceContextModel> SelectAll();
        IEnumerable<SchedulePriceProcedureModel> GetAllSchedulePrice();
        int Update(SchedulePriceContextModel schedulePriceContextModel);
    }
}