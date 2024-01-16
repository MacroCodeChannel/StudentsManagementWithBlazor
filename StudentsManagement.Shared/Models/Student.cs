using System.ComponentModel.DataAnnotations;

namespace StudentsManagement.Shared.Models  
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string RegistrationNo { get; set; }
        public  string FirstName { get; set; }
        public  string MiddleName { get; set; }
        public  string LastName { get; set; }

        public string FullName => $"{FirstName} {MiddleName} {LastName}";
        public  string EmailAddress { get; set; }
        public  string Address { get; set; }
        public   string PhoneNumber { get; set; }
        public int CountryId { get; set; }
  
        public Country Country { get; set; }
        public int GenderId { get; set; }
        public SystemCodeDetail Gender { get; set; }
        public DateTime DOB { get; set; }
    }
}
