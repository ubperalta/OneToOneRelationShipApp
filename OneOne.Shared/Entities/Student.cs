using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneOne.Shared.Entities
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required(ErrorMessage ="Required: First Name"), StringLength(35, MinimumLength =2, ErrorMessage ="Must be 2 to 35 characters only!")]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Required: Last Name"), StringLength(35, MinimumLength = 2, ErrorMessage = "Must be 2 to 35 characters only!")]
        public string LastName { get; set; } = string.Empty;
        [Required(ErrorMessage ="Required: Birthday"), DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public Department Department { get; set; }
        public Address Address { get; set; }
    }
}
