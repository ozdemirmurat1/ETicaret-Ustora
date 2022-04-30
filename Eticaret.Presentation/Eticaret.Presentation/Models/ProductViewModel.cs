using Eticaret.Entities;
using System.Collections.Generic;

namespace Eticaret.Presentation.Models
{
    public class ProductViewModel
    {
        public Product ProductDetail { get; set; }
        public List<ProductImage> Images { get; set; }
    }
}
