using ASystem.Models.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ASystem.Helper
{
    public class SeatHelper
    {
        public static IEnumerable<SelectListItem> FromClassEnumerable(IEnumerable<ClassContextModel> enumerable)
        {
            IList<SelectListItem> selectListItemList = new List<SelectListItem>();
            foreach (ClassContextModel contextModel in enumerable)
            {
                selectListItemList.Add(new SelectListItem() { Text = contextModel.Name + " " + contextModel.SubClass + " -NoOfSeats " + contextModel.NoOfSeats,
                    Value = contextModel.ClassId.ToString() });
            }
            return selectListItemList;
        }
    }
}