using ASystem.Models.Component;
using ASystem.Models.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASystem.Models.View
{
    public class CrewViewModel
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
                [Display(Name = "Crew Id")]
                public int CrewId { get; set; }

                [Display(Name = "Employee Id")]
                public int EmployeeId { get; set; }

                public static FormViewModel FromContextModel(CrewContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.CrewId = contextModel.CrewId;
                    formViewModel.EmployeeId = contextModel.EmployeeId;
                    return formViewModel;
                }
            }
        }
        public class ListViewModel
        {
            public string Status { get; set; }
            public IEnumerable<CrewContextModel> CrewContextModelEnumerable { get; set; }
        }
        public class DeleteViewModel
        {
            public CrewContextModel CrewContextModel { get; set; }
        }
        public class EditViewModel
        {
            public IEnumerable<SelectListItem> EmployeeEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "Crew Id")]
                public int CrewId { get; set; }

                [Required]
                [Display(Name = "Employee Id")]
                public int EmployeeId { get; set; }

                public static FormViewModel FromContextModel(CrewContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.CrewId = contextModel.CrewId;
                    formViewModel.EmployeeId = contextModel.EmployeeId;
                    return formViewModel;
                }
            }
        }
        public class InsertViewModel
        {
            public IEnumerable<SelectListItem> EmployeeEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "Employee Id")]
                public int EmployeeId { get; set; }
            }
        }
    }
}