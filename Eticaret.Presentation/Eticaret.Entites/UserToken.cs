using Eticaret.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Entities
{
    public class UserToken : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string TokenKey { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
    }
}
