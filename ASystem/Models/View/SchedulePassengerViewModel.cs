using ASystem.Models.Component;
using ASystem.Models.Context;
using ASystem.Models.Procedure;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASystem.Models.View
{
    public class SchedulePassengerViewModel
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
                [Display(Name = "Schedule Passenger Id")]
                public int SchedulePassengerId { get; set; }

                [Display(Name = "Flight Schedule Id")]
                public int FlightScheduleId { get; set; }

                [Display(Name = "Passenger Id")]
                public int PassengerId { get; set; }

                [Display(Name = "Seat Id")]
                public int SeatId { get; set; }

                [Display(Name = "Type")]
                public string Type { get; set; }

                [Display(Name = "Status")]
                public string Status { get; set; }

                public static FormViewModel FromContextModel(SchedulePassengerContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.SchedulePassengerId = contextModel.SchedulePassengerId;
                    formViewModel.FlightScheduleId = contextModel.FlightScheduleId;
                    formViewModel.PassengerId = contextModel.PassengerId;
                    formViewModel.SeatId = contextModel.SeatId;
                    formViewModel.Type = contextModel.Type;
                    formViewModel.Status = contextModel.Status;
                    return formViewModel;
                }
            }
        }
        public class ListViewModel
        {
            public string Status { get; set; }
            public IEnumerable<SchedulePassengerProcedureModel> SchedulePassengerProcedureEnumerable { get; set; }
        }
        public class DeleteViewModel
        {
            public SchedulePassengerContextModel SchedulePassengerContextModel { get; set; }
        }
        public class EditViewModel
        {
            public IEnumerable<SelectListItem> FlightScheduleEnumerable { get; set; }
            public IEnumerable<SelectListItem> PassengerEnumerable { get; set; }
            public IEnumerable<SelectListItem> SeatEnumerable { get; set; }
            public IEnumerable<SelectListItem> TypeEnumerable { get; set; }
            public IEnumerable<SelectListItem> StatusEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "Schedule Passenger Id")]
                public int SchedulePassengerId { get; set; }

                [Required]
                [Display(Name = "Flight Schedule Id")]
                public int FlightScheduleId { get; set; }

                [Required]
                [Display(Name = "Passenger Id")]
                public int PassengerId { get; set; }

                [Required]
                [Display(Name = "Seat Id")]
                public int SeatId { get; set; }

                [Required]
                [Display(Name = "Type")]
                public string Type { get; set; }

                [Required]
                [Display(Name = "Status")]
                public string Status { get; set; }

                public static FormViewModel FromContextModel(SchedulePassengerContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.SchedulePassengerId = contextModel.SchedulePassengerId;
                    formViewModel.FlightScheduleId = contextModel.FlightScheduleId;
                    formViewModel.PassengerId = contextModel.PassengerId;
                    formViewModel.SeatId = contextModel.SeatId;
                    formViewModel.Type = contextModel.Type;
                    formViewModel.Status = contextModel.Status;
                    return formViewModel;
                }
            }
        }
        public class InsertViewModel
        {
            public IEnumerable<SelectListItem> FlightScheduleEnumerable { get; set; }
            public IEnumerable<SelectListItem> PassengerEnumerable { get; set; }
            public IEnumerable<SelectListItem> SeatEnumerable { get; set; }
            public IEnumerable<SelectListItem> TypeEnumerable { get; set; }
            public IEnumerable<SelectListItem> StatusEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "Flight Schedule Id")]
                public int FlightScheduleId { get; set; }

                [Required]
                [Display(Name = "Passenger Id")]
                public int PassengerId { get; set; }

                [Required]
                [Display(Name = "Seat Id")]
                public int SeatId { get; set; }

                [Required]
                [Display(Name = "Type")]
                public string Type { get; set; }

                [Required]
                [Display(Name = "Status")]
                public string Status { get; set; }
            }
        }
    }
}