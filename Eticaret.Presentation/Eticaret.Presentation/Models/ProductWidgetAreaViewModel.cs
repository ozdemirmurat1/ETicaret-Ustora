using Eticaret.Entities;
using System.Collections.Generic;

namespace Eticaret.Presentation.Models
{
    //bu class sayesinde Component içerisine aynıda anda 3 adet data göndereceğiz.
    public class ProductWidgetAreaViewModel
    {
        public List<ProductImagesCustomModel> NewProducts { get; set; }
        public List<ProductImagesCustomModel> MostView { get; set; }
    }
}
