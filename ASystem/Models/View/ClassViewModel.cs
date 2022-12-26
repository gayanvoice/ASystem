using ASystem.Models.Component;
using ASystem.Models.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASystem.Models.View
{
    public class ClassViewModel
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
                [Display(Name = "Class Id")]
                public int ClassId { get; set; }

                [Display(Name = "Airplane Id")]
                public int AirplaneId { get; set; }

                [Display(Name = "Name")]
                public string Name { get; set; }

                [Display(Name = "Sub Class")]
                public string SubClass { get; set; }

                [Display(Name = "No Of Seats")]
                public int NoOfSeats { get; set; }

                [Display(Name = "Baggage Size")]
                public int BaggageSize { get; set; }

                [Display(Name = "Cabin Baggage Size")]
                public int CabinBaggageSize { get; set; }

                [Display(Name = "Is Seat Selection")]
                public string IsSeatSelection { get; set; }

                [Display(Name = "Is Skywards Miles")]
                public string IsSkywardsMiles { get; set; }

                [Display(Name = "Is Upgrade")]
                public string IsUpgrade { get; set; }

                [Display(Name = "Is Change Fee")]
                public string IsChangeFee { get; set; }

                [Display(Name = "Is Refund Fee")]
                public string IsRefundFee { get; set; }

                public static FormViewModel FromContextModel(ClassContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.ClassId = contextModel.ClassId;
                    formViewModel.AirplaneId = contextModel.AirplaneId;
                    formViewModel.Name = contextModel.Name;
                    formViewModel.SubClass = contextModel.SubClass;
                    formViewModel.NoOfSeats = contextModel.NoOfSeats;
                    formViewModel.BaggageSize = contextModel.BaggageSize;
                    formViewModel.CabinBaggageSize = contextModel.CabinBaggageSize;
                    formViewModel.IsSeatSelection = contextModel.IsSeatSelection;
                    formViewModel.IsSkywardsMiles = contextModel.IsSkywardsMiles;
                    formViewModel.IsUpgrade = contextModel.IsUpgrade;
                    formViewModel.IsChangeFee = contextModel.IsChangeFee;
                    formViewModel.IsRefundFee = contextModel.IsRefundFee;
                    return formViewModel;
                }
            }
        }
        public class ListViewModel
        {
            public IEnumerable<ClassContextModel> ClassContextModelEnumerable { get; set; }
        }
        public class DeleteViewModel
        {
            public ClassContextModel ClassContextModel { get; set; }
        }
        public class EditViewModel
        {
            public IEnumerable<SelectListItem> AirplaneIdEnumerable { get; set; }
            public IEnumerable<SelectListItem> ChangeFeeEnumerable { get; set; }
            public IEnumerable<SelectListItem> RefundFeeEnumerable { get; set; }
            public IEnumerable<SelectListItem> SeatSelectionEnumerable { get; set; }
            public IEnumerable<SelectListItem> SkywardMilesEnumerable { get; set; }
            public IEnumerable<SelectListItem> UpgradeEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "Class Id")]
                public int ClassId { get; set; }

                [Required]
                [Display(Name = "Airplane Id")]
                public int AirplaneId { get; set; }

                [Required]
                [Display(Name = "Name")]
                [StringLength(45)]
                public string Name { get; set; }

                [Required]
                [Display(Name = "Sub Class")]
                [StringLength(45)]
                public string SubClass { get; set; }

                [Required]
                [Display(Name = "No Of Seats")]
                public int NoOfSeats { get; set; }

                [Required]
                [Display(Name = "Baggage Size")]
                public int BaggageSize { get; set; }

                [Required]
                [Display(Name = "Cabin Baggage Size")]
                public int CabinBaggageSize { get; set; }

                [Required]
                [Display(Name = "Is Seat Selection")]
                public string IsSeatSelection { get; set; }

                [Required]
                [Display(Name = "Is Skywards Miles")]
                public string IsSkywardsMiles { get; set; }

                [Required]
                [Display(Name = "Is Upgrade")]
                public string IsUpgrade { get; set; }

                [Required]
                [Display(Name = "Is Change Fee")]
                public string IsChangeFee { get; set; }

                [Required]
                [Display(Name = "Is Refund Fee")]
                public string IsRefundFee { get; set; }

                public static FormViewModel FromContextModel(ClassContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.ClassId = contextModel.ClassId;
                    formViewModel.AirplaneId = contextModel.AirplaneId;
                    formViewModel.Name = contextModel.Name;
                    formViewModel.SubClass = contextModel.SubClass;
                    formViewModel.NoOfSeats = contextModel.NoOfSeats;
                    formViewModel.BaggageSize = contextModel.BaggageSize;
                    formViewModel.CabinBaggageSize = contextModel.CabinBaggageSize;
                    formViewModel.IsSeatSelection = contextModel.IsSeatSelection;
                    formViewModel.IsSkywardsMiles = contextModel.IsSkywardsMiles;
                    formViewModel.IsUpgrade = contextModel.IsUpgrade;
                    formViewModel.IsChangeFee = contextModel.IsChangeFee;
                    formViewModel.IsRefundFee = contextModel.IsRefundFee;
                    return formViewModel;
                }
            }
        }
        public class InsertViewModel
        {
            public IEnumerable<SelectListItem> AirplaneIdEnumerable { get; set; }
            public IEnumerable<SelectListItem> ChangeFeeEnumerable { get; set; }
            public IEnumerable<SelectListItem> RefundFeeEnumerable { get; set; }
            public IEnumerable<SelectListItem> SeatSelectionEnumerable { get; set; }
            public IEnumerable<SelectListItem> SkywardMilesEnumerable { get; set; }
            public IEnumerable<SelectListItem> UpgradeEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "Airplane Id")]
                public int AirplaneId { get; set; }

                [Required]
                [Display(Name = "Name")]
                [StringLength(45)]
                public string Name { get; set; }

                [Required]
                [Display(Name = "Sub Class")]
                [StringLength(45)]
                public string SubClass { get; set; }

                [Required]
                [Display(Name = "No Of Seats")]
                public int NoOfSeats { get; set; }

                [Required]
                [Display(Name = "Baggage Size")]
                public int BaggageSize { get; set; }

                [Required]
                [Display(Name = "Cabin Baggage Size")]
                public int CabinBaggageSize { get; set; }

                [Required]
                [Display(Name = "Is Seat Selection")]
                public string IsSeatSelection { get; set; }

                [Required]
                [Display(Name = "Is Skywards Miles")]
                public string IsSkywardsMiles { get; set; }

                [Required]
                [Display(Name = "Is Upgrade")]
                public string IsUpgrade { get; set; }

                [Required]
                [Display(Name = "Is Change Fee")]
                public string IsChangeFee { get; set; }

                [Required]
                [Display(Name = "Is Refund Fee")]
                public string IsRefundFee { get; set; }
            }
        }
    }
}