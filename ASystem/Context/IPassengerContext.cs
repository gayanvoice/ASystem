using ASystem.Models.Context;
using System.Collections.Generic;

namespace ASystem.Context
{
    public interface IPassengerContext
    {
        int Delete(int passengerId);
        int Insert(PassengerContextModel passengerContextModel);
        PassengerContextModel Select(int passengerId);
        IEnumerable<PassengerContextModel> SelectAll();
        int Update(PassengerContextModel passengerContextModel);
    }
}