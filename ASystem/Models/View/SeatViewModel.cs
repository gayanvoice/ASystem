using ASystem.Models.Component;
using ASystem.Models.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASystem.Models.View
{
    public class SeatViewModel
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
                [Display(Name = "Seat Id")]
                public int SeatId { get; set; }

                [Display(Name = "Class Id")]
                public int ClassId { get; set; }

                [Display(Name = "Seat No")]
                public int SeatNo { get; set; }

                public static FormViewModel FromContextModel(SeatContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.SeatId = contextModel.SeatId;
                    formViewModel.ClassId = contextModel.ClassId;
                    formViewModel.SeatNo = contextModel.SeatNo;
                    return formViewModel;
                }
            }
        }
        public class ListViewModel
        {
            public string Status { get; set; }
            public IEnumerable<SeatContextModel> SeatContextModelEnumerable { get; set; }
        }
        public class DeleteViewModel
        {
            public SeatContextModel SeatContextModel { get; set; }
        }
        public class EditViewModel
        {
            public IEnumerable<SelectListItem> ClassEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "Seat Id")]
                public int SeatId { get; set; }

                [Required]
                [Display(Name = "Class Id")]
                public int ClassId { get; set; }

                [Required]
                [Display(Name = "Seat No")]
                public int SeatNo { get; set; }

                public static FormViewModel FromContextModel(SeatContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.SeatId = contextModel.SeatId;
                    formViewModel.ClassId = contextModel.ClassId;
                    formViewModel.SeatNo = contextModel.SeatNo;
                    return formViewModel;
                }
            }
        }
        public class InsertViewModel
        {
            public IEnumerable<SelectListItem> ClassEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "Class Id")]
                public int ClassId { get; set; }

                [Required]
                [Display(Name = "Seat No")]
                public int SeatNo { get; set; }
            }
        }
    }
}