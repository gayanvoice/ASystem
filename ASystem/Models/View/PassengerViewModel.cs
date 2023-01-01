using ASystem.Models.Component;
using ASystem.Models.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASystem.Models.View
{
    public class PassengerViewModel
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
                [Display(Name = "Passenger Id")]
                public int PassengerId { get; set; }

                [Display(Name = "Passport Id")]
                public int PassportId { get; set; }

                [Required]
                [Display(Name = "Phone")]
                public int Phone { get; set; }

                public static FormViewModel FromContextModel(PassengerContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.PassengerId = contextModel.PassengerId;
                    formViewModel.PassportId = contextModel.PassportId;
                    formViewModel.Phone = contextModel.Phone;
                    return formViewModel;
                }
            }
        }
        public class ListViewModel
        {
            public string Status { get; set; }
            public IEnumerable<PassengerContextModel> PassengerContextModelEnumerable { get; set; }
        }
        public class DeleteViewModel
        {
            public PassengerContextModel PassengerContextModel { get; set; }
        }
        public class EditViewModel
        {
            public IEnumerable<SelectListItem> PassportEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "Passenger Id")]
                public int PassengerId { get; set; }

                [Required]
                [Display(Name = "Passport Id")]
                public int PassportId { get; set; }

                [Required]
                [Display(Name = "Phone")]
                public int Phone { get; set; }

                public static FormViewModel FromContextModel(PassengerContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.PassengerId = contextModel.PassengerId;
                    formViewModel.PassportId = contextModel.PassportId;
                    formViewModel.Phone = contextModel.Phone;
                    return formViewModel;
                }
            }
        }
        public class InsertViewModel
        {
            public IEnumerable<SelectListItem> PassportEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "Passport Id")]
                public int PassportId { get; set; }

                [Required]
                [Display(Name = "Phone")]
                public int Phone { get; set; }
            }
        }
    }
}