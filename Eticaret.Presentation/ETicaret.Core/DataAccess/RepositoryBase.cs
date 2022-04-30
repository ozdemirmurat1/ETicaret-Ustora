using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Eticaret.Core.DataAccess
{
    //crud
    public class RepositoryBase<TTable,TContext> 
        : IRepository<TTable> where TTable : class, IEntity, new() 
        where TContext : DbContext ,new()
    {
        public void Add(TTable entity)
        {
            using (var context = new TContext())
            {
                var add = context.Entry(entity);
                add.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public bool Any(Expression<Func<TTable, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TTable>().Any(filter);
            }
        }

        public void Delete(TTable entity)
        {
            using (var context = new TContext())
            {
                var delete = context.Entry(entity);
                delete.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TTable Get(Expression<Func<TTable, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TTable>().FirstOrDefault(filter);
            }
        }

        public List<TTable> List(Expression<Func<TTable, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? context.Set<TTable>().ToList()
                    : context.Set<TTable>().Where(filter).ToList();
            }
        }

        public IQueryable<TTable> Query(Expression<Func<TTable, bool>> filter)
        {
            var context = new TContext();

            return context.Set<TTable>().Where(filter).AsQueryable();


        }

        public void Update(TTable entity)
        {
            using (var context = new TContext())
            {
                var update = context.Entry(entity);
                update.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
