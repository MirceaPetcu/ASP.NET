﻿using ProiectV1.Models.Enums;

namespace ProiectV1.Models.DTOs
{
    public class ProductDTO
    {
        public double Price { get; set; }
        public string Name { get; set; }
        public ProductCategory Category { get; set; }
    }
}
