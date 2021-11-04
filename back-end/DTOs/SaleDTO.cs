using System;
using System.Collections.Generic;

namespace back_end.DTOs
{
    public class SaleDTO
    {
        public DateTime Date { get; set; }
        public int StoreId { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeDTO Employee { get; set; }
        public int CustomerId { get; set; }
        public CustomerDTO Customer { get; set; }
        public StoreDTO Store { get; set; }
        List<SaleDetailDTO> SaleDetails { get; set; }
    }
}