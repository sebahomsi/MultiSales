using System.ComponentModel.DataAnnotations;

namespace back_end.Entities
{
    public class SaleDetail : BaseEntity
    {
        public int Code { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int ProductId { get; set; }
        public int SaleId { get; set; }
        public Product Product { get; set; }
        public Sale Sale { get; set; }

    }
}
