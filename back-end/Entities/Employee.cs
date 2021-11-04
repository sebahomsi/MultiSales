using System.Collections.Generic;

namespace back_end.Entities
{
    public class Employee : Person
    {
        public int FileNumber { get; set; }
        public List<Sale> Sales { get; set; }
    }
}
