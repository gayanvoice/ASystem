using ASystem.Models.Component;
using ASystem.Models.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASystem.Models.View
{
    public class AirplaneModelViewModel
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
                [Display(Name = "Airplane Model Id")]
                public int AirplaneModelId { get; set; }
                [Display(Name = "Airplane Manufacturer Id")]
                public int AirplaneManufacturerId { get; set; }
                [Display(Name = "Name")]
                public string Name { get; set; }
                [Display(Name = "Sub Model")]
                public string SubModel { get; set; }
                public static FormViewModel FromContextModel(AirplaneModelContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.AirplaneModelId = contextModel.AirplaneModelId;
                    formViewModel.AirplaneManufacturerId = contextModel.AirplaneManufacturerId;
                    formViewModel.Name = contextModel.Name;
                    formViewModel.SubModel = contextModel.SubModel;
                    return formViewModel;
                }
            }
        }
        public class ListViewModel
        {
            public IEnumerable<AirplaneModelContextModel> AirplaneModelContextModelEnumerable { get; set; }
        }
        public class DeleteViewModel
        {
            public AirplaneModelContextModel AirplaneContextModel { get; set; }
        }
        public class EditViewModel
        {
            public IEnumerable<SelectListItem> AirplaneManufacturerIdEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "Airplane Model Id")]
                public int AirplaneModelId { get; set; }
                [Required]
                [Display(Name = "Airplane Manufacturer Id")]
                public int AirplaneManufacturerId { get; set; }
                [Required]
                [Display(Name = "Name")]
                [DataType(DataType.Text)]
                [StringLength(20)]
                public string Name { get; set; }
                [Required]
                [Display(Name = "Sub Model")]
                [DataType(DataType.Text)]
                [StringLength(20)]
                public string SubModel { get; set; }
                public static FormViewModel FromContextModel(AirplaneModelContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.AirplaneModelId = contextModel.AirplaneModelId;
                    formViewModel.AirplaneManufacturerId = contextModel.AirplaneManufacturerId;
                    formViewModel.Name = contextModel.Name;
                    formViewModel.SubModel = contextModel.SubModel;
                    return formViewModel;
                }
            }
        }
        public class InsertViewModel
        {
            public IEnumerable<SelectListItem> AirplaneManufacturerIdEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            
            public class FormViewModel
            {
                [Required]
                [Display(Name = "Airplane Manufacturer Id")]
                public int AirplaneManufacturerId { get; set; }
                [Required]
                [Display(Name = "Name")]
                [DataType(DataType.Text)]
                [StringLength(20)]
                public string Name { get; set; }
                [Required]
                [Display(Name = "Sub Model")]
                [DataType(DataType.Text)]
                [StringLength(20)]
                public string SubModel { get; set; }
            }
        }
    }
}