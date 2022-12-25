using ASystem.Models.View;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASystem.Helper
{
    public class ErrorHelper
    {
        public static IEnumerable<ErrorViewModel> GetIEnumerableErrorViewModel(ErrorViewModel.Url url)
        {
            List<ErrorViewModel> errorViewModelList = new List<ErrorViewModel>();
            errorViewModelList.Add(new ErrorViewModel()
            {
                Code = 100,
                Title = "Can not delete the value",
                Description = "The requested value can not be deleted from the table due to foriegn key constraint",
                PreviousUrl = url
            });
            return errorViewModelList;
            
        }
    }
}