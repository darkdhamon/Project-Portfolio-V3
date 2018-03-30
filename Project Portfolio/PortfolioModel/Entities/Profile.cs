using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioModel.Entities
{
    public class Profile
    {
        public int ID { get; set; } 
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public string FullName => $"{FirstName} {MiddleName}{(string.IsNullOrWhiteSpace(MiddleName)?"":" ")}{LastName}";
        public Address Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        [NotMapped]
        public int Age => DateTime.Now.Year - DateOfBirth.Year -
                          ((DateTime.Now.Month < DateOfBirth.Month || DateTime.Now.Month == DateOfBirth.Month &&
                            DateTime.Now.Day < DateOfBirth.Day)
                              ? 1
                              : 0);

        public string PersonalAboutMe { get; set; }
        public string Type { get; set; }
    }
}
