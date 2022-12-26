using ASystem.Models.Component;
using ASystem.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASystem.Models.View
{
    public class FlightScheduleViewModel
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
                [Display(Name = "Flight Schedule Id")]
                public int FlightScheduleId { get; set; }

                [Display(Name = "Airplane Id")]
                public int AirplaneId { get; set; }

                [Display(Name = "Airport Id Origin")]
                public int AirportIdOrigin { get; set; }

                [Display(Name = "Airport Id Destination")]
                public int AirportIdDestination { get; set; }

                [Display(Name = "Type")]
                public string Type { get; set; }

                [Display(Name = "Departure Time")]
                public DateTime DepartureTime { get; set; }

                [Display(Name = "Arrive Time")]
                public DateTime ArriveTime { get; set; }

                [Display(Name = "Status")]
                public string Status { get; set; }

                public static FormViewModel FromContextModel(FlightScheduleContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.FlightScheduleId = contextModel.FlightScheduleId;
                    formViewModel.AirplaneId = contextModel.AirplaneId;
                    formViewModel.AirportIdOrigin = contextModel.AirportIdOrigin;
                    formViewModel.AirportIdDestination = contextModel.AirportIdDestination;
                    formViewModel.Type = contextModel.Type;
                    formViewModel.DepartureTime = contextModel.DepartureTime;
                    formViewModel.ArriveTime = contextModel.ArriveTime;
                    formViewModel.Status = contextModel.Status;
                    return formViewModel;
                }
            }
        }
        public class ListViewModel
        {
            public IEnumerable<FlightScheduleContextModel> FlightScheduleContextModelEnumerable { get; set; }
        }
        public class DeleteViewModel
        {
            public FlightScheduleContextModel FlightScheduleContextModel { get; set; }
        }
        public class EditViewModel
        {
            public IEnumerable<SelectListItem> AirplaneEnumerable { get; set; }
            public IEnumerable<SelectListItem> AirportEnumerable { get; set; }
            public IEnumerable<SelectListItem> TypeEnumerable { get; set; }
            public IEnumerable<SelectListItem> StatusEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "Flight Schedule Id")]
                public int FlightScheduleId { get; set; }

                [Required]
                [Display(Name = "Airplane Id")]
                public int AirplaneId { get; set; }

                [Required]
                [Display(Name = "Airport Id Origin")]
                public int AirportIdOrigin { get; set; }

                [Required]
                [Display(Name = "Airport Id Destination")]
                public int AirportIdDestination { get; set; }

                [Required]
                [Display(Name = "Type")]
                public string Type { get; set; }

                [Required]
                [BindProperty, DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
                [Display(Name = "Departure Time")]
                public DateTime DepartureTime { get; set; }

                [Required]
                [BindProperty, DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
                [Display(Name = "Arrive Time")]
                public DateTime ArriveTime { get; set; }

                [Required]
                [Display(Name = "Status")]
                public string Status { get; set; }

                public static FormViewModel FromContextModel(FlightScheduleContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.FlightScheduleId = contextModel.FlightScheduleId;
                    formViewModel.AirplaneId = contextModel.AirplaneId;
                    formViewModel.AirportIdOrigin = contextModel.AirportIdOrigin;
                    formViewModel.AirportIdDestination = contextModel.AirportIdDestination;
                    formViewModel.Type = contextModel.Type;
                    formViewModel.DepartureTime = contextModel.DepartureTime;
                    formViewModel.ArriveTime = contextModel.ArriveTime;
                    formViewModel.Status = contextModel.Status;
                    return formViewModel;
                }
            }
        }
        public class InsertViewModel
        {
            public IEnumerable<SelectListItem> AirplaneEnumerable { get; set; }
            public IEnumerable<SelectListItem> AirportEnumerable { get; set; }
            public IEnumerable<SelectListItem> TypeEnumerable { get; set; }
            public IEnumerable<SelectListItem> StatusEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "Airplane Id")]
                public int AirplaneId { get; set; }

                [Required]
                [Display(Name = "Airport Id Origin")]
                public int AirportIdOrigin { get; set; }

                [Required]
                [Display(Name = "Airport Id Destination")]
                public int AirportIdDestination { get; set; }

                [Required]
                [Display(Name = "Type")]
                public string Type { get; set; }

                [Required]
                [Display(Name = "Departure Time")]
                [BindProperty, DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
                public DateTime DepartureTime { get; set; }

                [Required]
                [Display(Name = "Arrive Time")]
                [BindProperty, DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
                public DateTime ArriveTime { get; set; }

                [Required]
                [Display(Name = "Status")]
                public string Status { get; set; }
            }
        }
    }
}