using ASystem.Models.Component;
using ASystem.Models.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASystem.Models.View
{
    public class SchedulePriceViewModel
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
                [Display(Name = "Schedule Price Id")]
                public int SchedulePriceId { get; set; }

                [Display(Name = "Flight Schedule Id")]
                public int FlightScheduleId { get; set; }

                [Display(Name = "Class Id")]
                public int ClassId { get; set; }

                [Display(Name = "Price")]
                public double Price { get; set; }

                public static FormViewModel FromContextModel(SchedulePriceContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.SchedulePriceId = contextModel.SchedulePriceId;
                    formViewModel.FlightScheduleId = contextModel.FlightScheduleId;
                    formViewModel.ClassId = contextModel.ClassId;
                    formViewModel.Price = contextModel.Price;
                    return formViewModel;
                }
            }
        }
        public class ListViewModel
        {
            public IEnumerable<SchedulePriceContextModel> SchedulePriceContextModelEnumerable { get; set; }
        }
        public class DeleteViewModel
        {
            public SchedulePriceContextModel SchedulePriceContextModel { get; set; }
        }
        public class EditViewModel
        {
            public IEnumerable<SelectListItem> FlightScheduleEnumerable { get; set; }
            public IEnumerable<SelectListItem> ClassEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "Schedule Price Id")]
                public int SchedulePriceId { get; set; }

                [Required]
                [Display(Name = "Flight Schedule Id")]
                public int FlightScheduleId { get; set; }

                [Required]
                [Display(Name = "Class Id")]
                public int ClassId { get; set; }

                [Required]
                [Display(Name = "Price")]
                public double Price { get; set; }

                public static FormViewModel FromContextModel(SchedulePriceContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.SchedulePriceId = contextModel.SchedulePriceId;
                    formViewModel.FlightScheduleId = contextModel.FlightScheduleId;
                    formViewModel.ClassId = contextModel.ClassId;
                    formViewModel.Price = contextModel.Price;
                    return formViewModel;
                }
            }
        }
        public class InsertViewModel
        {
            public IEnumerable<SelectListItem> FlightScheduleEnumerable { get; set; }
            public IEnumerable<SelectListItem> ClassEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "Flight Schedule Id")]
                public int FlightScheduleId { get; set; }

                [Required]
                [Display(Name = "Class Id")]
                public int ClassId { get; set; }

                [Required]
                [Display(Name = "Price")]
                public double Price { get; set; }
            }
        }
    }
}