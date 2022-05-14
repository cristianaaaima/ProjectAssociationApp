using Microsoft.EntityFrameworkCore;
using SEProjectApp.Abstractions.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SEProjectApp.DataAccess
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected AssociationContext AssociationContext { get; set; }

        public BaseRepository(AssociationContext associationContext)
        {
            this.AssociationContext = associationContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.AssociationContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.AssociationContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.AssociationContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.AssociationContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.AssociationContext.Set<T>().Remove(entity);
        }
    }
}
