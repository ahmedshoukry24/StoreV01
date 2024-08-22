using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class VariationDto
    {
        public Guid ID { get; set; }
        public string Serial { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }
        public string Weight { get; set; }
        public string Description { get; set; }
        public string Memory { get; set; }
        public string RAM { get; set; }
        public string CPU { get; set; }
        public string Style { get; set; }
        public string Model { get; set; }
        public string SpecialFeatures { get; set; }
        public string GraphicsDescription { get; set; }
        public string SKU { get; set; }
        public int StockQuantity { get; set; }
        public Guid ProductId { get; set; }
    }
}
