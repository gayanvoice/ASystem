using ASystem.Models.Component;
using ASystem.Models.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASystem.Models.View
{
    public class AirplaneViewModel
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
                [Display(Name = "Airplane Id")]
                public int AirplaneId { get; set; }
                [Display(Name = "Airplane Model Id")]
                public int AirplaneModelId { get; set; }
                [Display(Name = "Flight Number")]
                public string FlightNumber { get; set; }
                [Display(Name = "Status")]
                public int Status { get; set; }
                public static FormViewModel FromContextModel(AirplaneContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.AirplaneId = contextModel.AirplaneId;
                    formViewModel.AirplaneModelId = contextModel.AirplaneModelId;
                    formViewModel.FlightNumber = contextModel.FlightNumber;
                    formViewModel.Status = contextModel.Status;
                    return formViewModel;
                }
            }
        }
        public class ListViewModel
        {
            public IEnumerable<AirplaneContextModel> AirplaneContextModelEnumerable { get; set; }
        }
        public class DeleteViewModel
        {
            public AirplaneContextModel AirplaneContextModel { get; set; }
        }
        public class EditViewModel
        {
            public IEnumerable<SelectListItem> AirplaneModelIdEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "Airplane Id")]
                public int AirplaneId { get; set; }

                [Required]
                [Display(Name = "Airplane Model Id")]
                public int AirplaneModelId { get; set; }

                [Required]
                [Display(Name = "Flight Number")]
                [DataType(DataType.Text)]
                [StringLength(20)]
                public string FlightNumber { get; set; }
                [Required]
                [Display(Name = "Status")]
                public int Status { get; set; }
                public static FormViewModel FromContextModel(AirplaneContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.AirplaneId = contextModel.AirplaneId;
                    formViewModel.AirplaneModelId = contextModel.AirplaneModelId;
                    formViewModel.FlightNumber = contextModel.FlightNumber;
                    formViewModel.Status = contextModel.Status;
                    return formViewModel;
                }
            }
        }
        public class InsertViewModel
        {
            public IEnumerable<SelectListItem> AirplaneModelIdEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            
            public class FormViewModel
            {

                [Required]
                [Display(Name = "Airplane Model Id")]
                public int AirplaneModelId { get; set; }

                [Required]
                [Display(Name = "Flight Number")]
                [DataType(DataType.Text)]
                [StringLength(20)]
                public string FlightNumber { get; set; }
                [Required]
                [Display(Name = "Status")]
                public int Status { get; set; }
            }
        }
    }
}