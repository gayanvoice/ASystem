using ASystem.Models.Component;
using ASystem.Models.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASystem.Models.View
{
    public class PilotViewModel
    {
        public IndexViewModel Index { get; set; }
        public ListViewModel List { get; set; }
        public InsertViewModel Insert { get; set; }
        public DeleteViewModel Delete { get; set; }
        public EditViewModel Edit { get; set; }
        public ShowViewModel Show { get; set; }
        public class IndexViewModel
        {
            public IEnumerable<ItemComponentModel> ItemComponentModelEnumerable { get; set; }
        }
        public class ShowViewModel
        {
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Display(Name = "Pilot Id")]
                public int PilotId { get; set; }

                [Display(Name = "Employee Id")]
                public int EmployeeId { get; set; }

                [Display(Name = "Airplane Model Id")]
                public int AirplaneModelId { get; set; }
 
                [Display(Name = "Ratings")]
                public int Ratings { get; set; }

                public static FormViewModel FromContextModel(PilotContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.PilotId = contextModel.PilotId;
                    formViewModel.EmployeeId = contextModel.EmployeeId;
                    formViewModel.AirplaneModelId = contextModel.AirplaneModelId;
                    formViewModel.Ratings = contextModel.Ratings;
                    return formViewModel;
                }
            }
        }
        public class ListViewModel
        {
            public IEnumerable<PilotContextModel> PilotContextModelEnumerable { get; set; }
        }
        public class DeleteViewModel
        {
            public PilotContextModel PilotContextModel { get; set; }
        }
        public class EditViewModel
        {
            public IEnumerable<SelectListItem> EmployeeEnumerable { get; set; }
            public IEnumerable<SelectListItem> AirplaneModelEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "Pilot Id")]
                public int PilotId { get; set; }

                [Required]
                [Display(Name = "Employee Id")]
                public int EmployeeId { get; set; }

                [Required]
                [Display(Name = "Airplane Model Id")]
                public int AirplaneModelId { get; set; }

                [Required]
                [Display(Name = "Ratings")]
                public int Ratings { get; set; }

                public static FormViewModel FromContextModel(PilotContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.PilotId = contextModel.PilotId;
                    formViewModel.EmployeeId = contextModel.EmployeeId;
                    formViewModel.AirplaneModelId = contextModel.AirplaneModelId;
                    formViewModel.Ratings = contextModel.Ratings;
                    return formViewModel;
                }
            }
        }
        public class InsertViewModel
        {
            public IEnumerable<SelectListItem> EmployeeEnumerable { get; set; }
            public IEnumerable<SelectListItem> AirplaneModelEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "Employee Id")]
                public int EmployeeId { get; set; }

                [Required]
                [Display(Name = "Airplane Model Id")]
                public int AirplaneModelId { get; set; }

                [Required]
                [Display(Name = "Ratings")]
                public int Ratings { get; set; }
            }
        }
    }
}