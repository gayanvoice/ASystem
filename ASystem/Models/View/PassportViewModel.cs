using ASystem.Models.Component;
using ASystem.Models.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASystem.Models.View
{
    public class PassportViewModel
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
                [Display(Name = "Passport Id")]
                public int PassportId { get; set; }
                [Display(Name = "Passport No")]
                public string PassportNo { get; set; }
                [Display(Name = "Type")]
                public string Type { get; set; }
                [Display(Name = "Country Code")]
                public string CountryCode { get; set; }
                [Display(Name = "Surname")]
                public string Surname { get; set; }
                [Display(Name = "Other Name")]
                public string OtherName { get; set; }
                [Display(Name = "National Status")]
                public string NationalStatus { get; set; }
                [Display(Name = "Date Of Birth")]
                public DateTime DateOfBirth { get; set; }
                [Display(Name = "Id No")]
                public string IdNo { get; set; }
                [Display(Name = "Profession")]
                public string Profession { get; set; }
                [Display(Name = "Sex")]
                public string Sex { get; set; }
                [Display(Name = "Place Of Birth")]
                public string PlaceOfBirth { get; set; }
                [Display(Name = "Date Of Issue")]
                public DateTime DateOfIssue { get; set; }
                [Display(Name = "Date Of Expiry")]
                public DateTime DateOfExpiry { get; set; }
                [Display(Name = "Authority")]
                public string Authority { get; set; }
                [Display(Name = "Status")]
                public string Status { get; set; }
                public static FormViewModel FromContextModel(PassportContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.PassportId = contextModel.PassportId;
                    formViewModel.PassportNo = contextModel.PassportNo;
                    formViewModel.Type = contextModel.Type;
                    formViewModel.CountryCode = contextModel.CountryCode;
                    formViewModel.Surname = contextModel.Surname;
                    formViewModel.OtherName = contextModel.OtherName;
                    formViewModel.NationalStatus = contextModel.NationalStatus;
                    formViewModel.DateOfBirth = contextModel.DateOfBirth.Date;
                    formViewModel.IdNo = contextModel.IdNo;
                    formViewModel.Profession = contextModel.Profession;
                    formViewModel.Sex = contextModel.Sex;
                    formViewModel.PlaceOfBirth = contextModel.PlaceOfBirth;
                    formViewModel.DateOfIssue = contextModel.DateOfIssue.Date;
                    formViewModel.DateOfExpiry = contextModel.DateOfExpiry.Date;
                    formViewModel.Authority = contextModel.Authority;
                    formViewModel.Status = contextModel.Status;
                    return formViewModel;
                }
            }
        }
        public class ListViewModel
        {
            public string Status { get; set; }
            public IEnumerable<PassportContextModel> PassportContextModelEnumerable { get; set; }
        }
        public class DeleteViewModel
        {
            public PassportContextModel PassportContextModel { get; set; }
        }
        public class EditViewModel
        {
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "Passport Id")]
                public int PassportId { get; set; }
                [Required]
                [Display(Name = "Passport No")]
                [DataType(DataType.Text)]
                [StringLength(20)]
                public string PassportNo { get; set; }
                [Required]
                [Display(Name = "Type")]
                [DataType(DataType.Text)]
                [StringLength(10)]
                public string Type { get; set; }
                [Required]
                [Display(Name = "Country Code")]
                [DataType(DataType.Text)]
                [StringLength(3)]
                public string CountryCode { get; set; }
                [Required]
                [Display(Name = "Surname")]
                [DataType(DataType.Text)]
                [StringLength(20)]
                public string Surname { get; set; }
                [Required]
                [Display(Name = "Other Name")]
                [DataType(DataType.Text)]
                [StringLength(20)]
                public string OtherName { get; set; }
                [Required]
                [Display(Name = "National Status")]
                [DataType(DataType.Text)]
                [StringLength(20)]
                public string NationalStatus { get; set; }
                [Required]
                [Display(Name = "Date Of Birth")]
                public DateTime DateOfBirth { get; set; }
                [Required]
                [Display(Name = "Id No")]
                [DataType(DataType.Text)]
                [StringLength(20)]
                public string IdNo { get; set; }
                [Required]
                [Display(Name = "Profession")]
                [DataType(DataType.Text)]
                [StringLength(20)]
                public string Profession { get; set; }
                [Required]
                [Display(Name = "Sex")]
                [DataType(DataType.Text)]
                [StringLength(20)]
                public string Sex { get; set; }
                [Required]
                [Display(Name = "Place Of Birth")]
                [DataType(DataType.Text)]
                [StringLength(20)]
                public string PlaceOfBirth { get; set; }
                [Required]
                [Display(Name = "Date Of Issue")]
                public DateTime DateOfIssue { get; set; }
                [Required]
                [Display(Name = "Date Of Expiry")]
                public DateTime DateOfExpiry { get; set; }
                [Required]
                [Display(Name = "Authority")]
                [DataType(DataType.Text)]
                [StringLength(20)]
                public string Authority { get; set; }
                [Required]
                [Display(Name = "Status")]
                [DataType(DataType.Text)]
                [StringLength(20)]
                public string Status { get; set; }
                public static FormViewModel FromContextModel(PassportContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.PassportId = contextModel.PassportId;
                    formViewModel.PassportNo = contextModel.PassportNo;
                    formViewModel.Type = contextModel.Type;
                    formViewModel.CountryCode = contextModel.CountryCode;
                    formViewModel.Surname = contextModel.Surname;
                    formViewModel.OtherName = contextModel.OtherName;
                    formViewModel.NationalStatus = contextModel.NationalStatus;
                    formViewModel.DateOfBirth = contextModel.DateOfBirth.Date;
                    formViewModel.IdNo = contextModel.IdNo;
                    formViewModel.Profession = contextModel.Profession;
                    formViewModel.Sex = contextModel.Sex;
                    formViewModel.PlaceOfBirth = contextModel.PlaceOfBirth;
                    formViewModel.DateOfIssue = contextModel.DateOfIssue.Date;
                    formViewModel.DateOfExpiry = contextModel.DateOfExpiry.Date;
                    formViewModel.Authority = contextModel.Authority;
                    formViewModel.Status = contextModel.Status;
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
                [Display(Name = "Passport No")]
                [DataType(DataType.Text)]
                [StringLength(20)]
                public string PassportNo { get; set; }
                [Required]
                [Display(Name = "Type")]
                [DataType(DataType.Text)]
                [StringLength(10)]
                public string Type { get; set; }
                [Required]
                [Display(Name = "Country Code")]
                [DataType(DataType.Text)]
                [StringLength(3)]
                public string CountryCode { get; set; }
                [Required]
                [Display(Name = "Surname")]
                [DataType(DataType.Text)]
                [StringLength(20)]
                public string Surname { get; set; }
                [Required]
                [Display(Name = "Other Name")]
                [DataType(DataType.Text)]
                [StringLength(20)]
                public string OtherName { get; set; }
                [Required]
                [Display(Name = "National Status")]
                [DataType(DataType.Text)]
                [StringLength(20)]
                public string NationalStatus { get; set; }
                [Required]
                [Display(Name = "Date Of Birth")]
                public DateTime DateOfBirth { get; set; }
                [Required]
                [Display(Name = "Id No")]
                [DataType(DataType.Text)]
                [StringLength(20)]
                public string IdNo { get; set; }
                [Required]
                [Display(Name = "Profession")]
                [DataType(DataType.Text)]
                [StringLength(20)]
                public string Profession { get; set; }
                [Required]
                [Display(Name = "Sex")]
                [DataType(DataType.Text)]
                [StringLength(20)]
                public string Sex { get; set; }
                [Required]
                [Display(Name = "Place Of Birth")]
                [DataType(DataType.Text)]
                [StringLength(20)]
                public string PlaceOfBirth { get; set; }
                [Required]
                [Display(Name = "Date Of Issue")]
                public DateTime DateOfIssue { get; set; }
                [Required]
                [Display(Name = "Date Of Expiry")]
                public DateTime DateOfExpiry { get; set; }
                [Required]
                [Display(Name = "Authority")]
                [DataType(DataType.Text)]
                [StringLength(20)]
                public string Authority { get; set; }
                [Required]
                [Display(Name = "Status")]
                [DataType(DataType.Text)]
                [StringLength(20)]
                public string Status { get; set; }
            }
        }
    }
}