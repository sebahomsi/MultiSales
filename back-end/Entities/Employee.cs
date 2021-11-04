using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace back_end.Entities
{
    public class Employee : BaseEntity
    {
        [Required]
        [StringLength(maximumLength: 30)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(maximumLength: 30)]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(maximumLength: 30)]
        public string Email { get; set; }
        [Required]
        [StringLength(maximumLength: 30)]
        public int DNI { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Address> Addresses { get; set; }
        public int FileNumber { get; set; }
        public List<Sale> Sales { get; set; }
    }
}
