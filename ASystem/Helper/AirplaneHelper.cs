using ASystem.Models.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using SASystem.Context;
using System.Collections.Generic;
using System.Linq;

namespace ASystem.Helper
{
    public class AirplaneHelper
    {
        public static IEnumerable<SelectListItem> FromAirplaneModelEnumerable(IEnumerable<AirplaneModelContextModel> enumerable)
        {
            IList<SelectListItem> selectListItemList = new List<SelectListItem>();
            foreach (AirplaneModelContextModel contextModel in enumerable)
            {
                selectListItemList.Add(new SelectListItem() { Text = contextModel.Name + " - " + contextModel.SubModel, Value = contextModel.AirplaneModelId.ToString() });
            }
            return selectListItemList;
        }
    }
}