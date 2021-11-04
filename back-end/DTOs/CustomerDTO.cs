using System;

namespace back_end.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int DNI { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
