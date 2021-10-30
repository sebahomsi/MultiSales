using System;
using System.Collections.Generic;

namespace back_end.Entities
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int DNI { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
