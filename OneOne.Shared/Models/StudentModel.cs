using OneOne.Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneOne.Shared.Models
{
    public class StudentModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;      
        public string LastName { get; set; } = string.Empty;
        public DateTime Birthday { get; set; }
        public string Email { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public Department Department { get; set; }
        public string? Street { get; set; }
        public string? Barangay { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public string? PostalCode { get; set; }
    }
}
