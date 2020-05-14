using System;
using System.ComponentModel.DataAnnotations;
namespace RepositoryPattern.Models
{
    public partial class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        [StringLength(15)]
        public string Country { get; set; }

        [StringLength(24)]
        public string PhoneNumber { get; set; }

        [StringLength(255)]
        public string PhotoPath { get; set; }
    }
}
