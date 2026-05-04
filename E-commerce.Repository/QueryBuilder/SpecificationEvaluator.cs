using E_commerce.Core.Entities;
using E_commerce.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Repository.QueryBuilder
{
    public static class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> dbset, ISpecification<TEntity> specs)
        {
            // query = _db.Set<Product>()
            var query = dbset;

            if (specs.Criteria != null)
            {
                // query = _db.Set<Product>().Where(p=>p.Id==id)
                query = query.Where(specs.Criteria);
            }
            // query = _db.Set<Product>().Include(P => P.Category).Include()

            // _db.Set<Product>().Where(p=>p.Id==id).Include(p => p.Category).Include(p => p.Brand)
            query = specs.Includes.Aggregate(query,(currentQuery, includeExpression) => currentQuery.Include(includeExpression));


            return query;


        }
    }
}
