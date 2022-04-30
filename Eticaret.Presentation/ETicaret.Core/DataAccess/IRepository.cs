using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Core.DataAccess
{
    
    public interface IRepository<TTablo> where TTablo : class, IEntity, new()
    {
        TTablo Get(Expression<Func<TTablo, bool>> predicate);
        List<TTablo> List(Expression<Func<TTablo, bool>> filter = null);
        IQueryable<TTablo> Query(Expression<Func<TTablo, bool>> filter);
        void Add(TTablo entity);
        void Update(TTablo entity);
        void Delete(TTablo entity);
        bool Any(Expression<Func<TTablo, bool>> filter);
    }
}
