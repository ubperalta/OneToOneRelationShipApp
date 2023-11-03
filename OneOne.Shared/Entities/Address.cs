using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneOne.Shared.Entities
{
    public class Address
    {
        [ForeignKey("Student")]
        public Guid AddressId { get; set; }
        public string? Street { get; set; }
        public string? Barangay { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public string? PostalCode { get; set; }
        
        public Student? Student { get; set; }
    }
}
