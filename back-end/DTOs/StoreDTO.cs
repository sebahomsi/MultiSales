using System.Collections.Generic;

namespace back_end.DTOs
{
    public class StoreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Town { get; set; }
        public int PostalCode { get; set; }
        public List<SaleDTO> Sales { get; set; }

    }
}
