using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace back_end.Entities
{
    public class Store : BaseEntity
    {
        [Required]
        [StringLength(maximumLength: 70)]
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Address { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Town { get; set; }
        public int PostalCode { get; set; }
        public List<Sale> Sales { get; set; }
        
    }
}
