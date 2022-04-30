using Eticaret.Core.DataAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Entities
{
    public class ProductImage : IEntity
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string Name { get; set; }

        public int Sort { get; set; }

        public bool? Status { get; set; }

        public string AltText { get; set; }

   
    }
}
