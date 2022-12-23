using System;

namespace ASystem.Models.Context
{
    public class PassportContextModel
    {
        public int PassportId { get; set; } //11
        public string PassportNo { get; set; } //20
        public string Type { get; set; } // 10
        public string CountryCode { get; set; } // 3
        public string Surname { get; set; } // 20
        public string OtherName { get; set; } // 20
        public string NationalStatus { get; set; } // 20
        public DateTime DateOfBirth { get; set; }
        public string IdNo { get; set; } // 20
        public string Profession { get; set; } // 20
        public string Sex { get; set; } // 10
        public string PlaceOfBirth { get; set; } // 20
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfExpiry { get; set; }
        public string Authority { get; set; } // 20
        public string Status { get; set; } // 20
    }
}