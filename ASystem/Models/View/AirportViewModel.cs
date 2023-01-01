using ASystem.Models.Component;
using ASystem.Models.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASystem.Models.View
{
    public class AirportViewModel
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
                [Display(Name = "Airport Id")]
                public int AirportId { get; set; }
                public string Code { get; set; }
                public string Name { get; set; }
                public string City { get; set; }
                public string Country { get; set; }
                public static FormViewModel FromAirportContextModel(AirportContextModel airportContextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.AirportId = airportContextModel.AirportId;
                    formViewModel.Code = airportContextModel.Code;
                    formViewModel.Name = airportContextModel.Name;
                    formViewModel.City = airportContextModel.City;
                    formViewModel.Country = airportContextModel.Country;
                    return formViewModel;
                }
            }
        }
        public class ListViewModel
        {
            public string Status { get; set; }
            public IEnumerable<AirportContextModel> AirportContextModelEnumerable { get; set; }
        }
        public class DeleteViewModel
        {
            public string Title { get; set; }
            public AirportContextModel AirportContextModel { get; set; }
        }
        public class EditViewModel
        {
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "Airport Id")]
                public int AirportId { get; set; }
                [Required]
                [DataType(DataType.Text)]
                [StringLength(45)]
                public string Code { get; set; }
                [Required]
                [DataType(DataType.Text)]
                [StringLength(45)]
                public string Name { get; set; }
                [Required]
                [DataType(DataType.Text)]
                [StringLength(45)]
                public string City { get; set; }
                [Required]
                [DataType(DataType.Text)]
                [StringLength(45)]
                public string Country{ get; set; }
                public static FormViewModel FromAirportContextModel(AirportContextModel airportContextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.AirportId = airportContextModel.AirportId;
                    formViewModel.Code = airportContextModel.Code;
                    formViewModel.Name = airportContextModel.Name;
                    formViewModel.City = airportContextModel.City;
                    formViewModel.Country = airportContextModel.Country;
                    return formViewModel;
                }
            }
        }
        public class InsertViewModel
        {
            public FormViewModel Form { get; set; }
            
            public class FormViewModel
            {
                [Required]
                [DataType(DataType.Text)]
                [StringLength(45)]
                public string Code { get; set; }
                [Required]
                [DataType(DataType.Text)]
                [StringLength(45)]
                public string Name { get; set; }
                [Required]
                [DataType(DataType.Text)]
                [StringLength(45)]
                public string City { get; set; }
                [Required]
                [DataType(DataType.Text)]
                [StringLength(45)]
                public string Country { get; set; }
            }
        }
    }
}