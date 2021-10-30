using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace back_end.Entities
{
    public class Brand : BaseEntity
    {
        [Required]
        [StringLength(maximumLength: 70)]
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
