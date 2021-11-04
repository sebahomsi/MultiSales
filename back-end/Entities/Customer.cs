using System.Collections.Generic;

namespace back_end.Entities
{
    public class Customer : Person
    {
        public List<Sale> Sales { get; set; }
    }
}
