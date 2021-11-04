using System.ComponentModel.DataAnnotations;

namespace back_end.Entities
{
    public class Address : BaseEntity
    {
        [Required]
        [StringLength(maximumLength: 30)]
        public string Country { get; set; }
        [Required]
        [StringLength(maximumLength: 30)]
        public string Pronvice { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string City { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Street { get; set; }
        [Required]
        public int StreetNumber { get; set; }
        public bool IsApartment { get; set; }
        public string Floor { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
