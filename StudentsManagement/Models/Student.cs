using System.ComponentModel.DataAnnotations;

namespace StudentsManagement.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Country { get; set; }
    }
}
