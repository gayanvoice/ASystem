using ASystem.Models.Context;
using System.Collections.Generic;

namespace ASystem.Context
{
    public interface IAirportContext
    {
        int Delete(int airportId);
        int Insert(AirportContextModel airportContextModel);
        AirportContextModel Select(int airportId);
        IEnumerable<AirportContextModel> SelectAll();
        int Update(AirportContextModel airportContextModel);
    }
}