using ASystem.Models.Context;
using System.Collections.Generic;

namespace ASystem.Context
{
    public interface IAirplaneManufacturerContext
    {
        int Delete(int airplaneManufacturerId);
        int Insert(AirplaneManufacturerContextModel airplaneManufacturerContextModel);
        AirplaneManufacturerContextModel Select(int airplaneManufacturerId);
        IEnumerable<AirplaneManufacturerContextModel> SelectAll();
        int Update(AirplaneManufacturerContextModel airplaneManufacturerContextModel);

    }
}