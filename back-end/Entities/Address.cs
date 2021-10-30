namespace back_end.Entities
{
    public class Address : BaseEntity
    {
        public string Country { get; set; }
        public string Pronvice { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public bool IsApartment { get; set; }
        public string Floor { get; set; }
    }
}
