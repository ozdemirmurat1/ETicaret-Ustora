using Eticaret.Entities;
using System.Collections.Generic;//using

namespace Eticaret.Presentation.Models
{
    public class ShopViewModel
    {
        public List<CategoryProductsCustomModel> Products { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public string CategoryName { get; set; }
    }
}
