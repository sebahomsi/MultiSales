﻿using System.Collections.Generic;

namespace back_end.DTOs
{
    public class BrandDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductDTO> Products { get; set; }

    }
}
