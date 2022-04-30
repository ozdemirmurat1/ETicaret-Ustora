using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Entities
{
    public class CategoryProductsCustomModel : Product
    {
        public int Sort { get; set; }
        public string Image { get; set; }
    }
}
