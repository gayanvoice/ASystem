using ASystem.Models.Context;
using System.Collections.Generic;

namespace ASystem.Context
{
    public interface ISeatContext
    {
        int Delete(int seatId);
        int Insert(SeatContextModel seatContextModel);
        SeatContextModel Select(int seatId);
        IEnumerable<SeatContextModel> SelectAll();
        int Update(SeatContextModel seatContextModel);
    }
}