using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace back_end.Entities
{
    public class Product : BaseEntity
    {
        [Required]
        [StringLength(maximumLength: 70)]
        public string Name { get; set; }
        [StringLength(maximumLength: 300)]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Stock { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public List<SaleDetail> SaleDetails { get; set; }

    }
}
