using System;

namespace back_end.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public int FileNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int DNI { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
