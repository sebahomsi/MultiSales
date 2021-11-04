using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace back_end.Entities
{
    public class Sale : BaseEntity
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int StoreId { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Store Store { get; set; }
        List<SaleDetail> SaleDetails { get; set; }
    }
}
