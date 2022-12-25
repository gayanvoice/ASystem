using ASystem.Models.Component;
using ASystem.Models.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASystem.Models.View
{
    public class AirplaneManufacturerViewModel
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
            public IEnumerable<SelectListItem> StatusOption { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Display(Name = "Airplane Manufacturer Id")]
                public int AirplaneManufacturerId { get; set; }
                public string Name { get; set; }
                public string Country { get; set; }
                public static FormViewModel FromUserContextModel(AirplaneManufacturerContextModel airplaneManufacturerContextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.AirplaneManufacturerId = airplaneManufacturerContextModel.AirplaneManufacturerId;
                    formViewModel.Name = airplaneManufacturerContextModel.Name;
                    formViewModel.Country = airplaneManufacturerContextModel.Country;
                    return formViewModel;
                }
            }
        }
        public class ListViewModel
        {
            public IEnumerable<AirplaneManufacturerContextModel> AirplaneManufacturerContextModelEnumerable { get; set; }
        }
        public class DeleteViewModel
        {
            public string Title { get; set; }
            public AirplaneManufacturerContextModel AirplaneManufacturerContextModel { get; set; }
        }
        public class EditViewModel
        {
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "Airplane Manufacturer Id")]
                public int AirplaneManufacturerId { get; set; }
                [Required]
                [DataType(DataType.Text)]
                [StringLength(45)]
                public string Name { get; set; }
                [Required]
                [DataType(DataType.Text)]
                [StringLength(45)]
                public string Country{ get; set; }
                public static FormViewModel FromUserContextModel(AirplaneManufacturerContextModel airplaneManufacturerContextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.AirplaneManufacturerId = airplaneManufacturerContextModel.AirplaneManufacturerId;
                    formViewModel.Name = airplaneManufacturerContextModel.Name;
                    formViewModel.Country = airplaneManufacturerContextModel.Country;
                    return formViewModel;
                }
            }
        }
        public class InsertViewModel
        {
            public IEnumerable<SelectListItem> StatusOption { get; set; }
            public FormViewModel Form { get; set; }
            
            public class FormViewModel
            {
                [Required]
                [DataType(DataType.Text)]
                [StringLength(45)]
                public string Name { get; set; }
                [Required]
                [DataType(DataType.Text)]
                [StringLength(45)]
                public string Country { get; set; }
            }
        }
    }
}