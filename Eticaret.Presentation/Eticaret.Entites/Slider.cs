using Eticaret.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Entities
{
    public class Slider : IEntity
    {

        public int Id { get; set; }

        public string Image { get; set; }

        public string Header { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public DateTime? EndDate { get; set; }

        public bool Status { get; set; }

        public int Sort { get; set; }
    }
}
