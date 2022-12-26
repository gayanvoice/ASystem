using ASystem.Models.Context;
using System.Collections.Generic;

namespace ASystem.Context
{
    public interface ISchedulePriceContext
    {
        int Delete(int schedulePriceId);
        int Insert(SchedulePriceContextModel schedulePriceContextModel);
        SchedulePriceContextModel Select(int schedulePriceId);
        IEnumerable<SchedulePriceContextModel> SelectAll();
        int Update(SchedulePriceContextModel schedulePriceContextModel);
    }
}