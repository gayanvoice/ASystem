using ASystem.Models.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using SASystem.Context;
using System.Collections.Generic;
using System.Linq;

namespace ASystem.Helper
{
    public class AirplaneModelHelper
    {
        public static IEnumerable<SelectListItem> FromAirplaneManufacturerEnumerable(IEnumerable<AirplaneManufacturerContextModel> enumerable)
        {
            IList<SelectListItem> selectListItemList = new List<SelectListItem>();
            foreach (AirplaneManufacturerContextModel contextModel in enumerable)
            {
                selectListItemList.Add(new SelectListItem() { Text = contextModel.Name + " - " + contextModel.Country, Value = contextModel.AirplaneManufacturerId.ToString() });
            }
            return selectListItemList;
        }
    }
}