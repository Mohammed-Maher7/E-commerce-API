using E_commerce.Core.Entities;
using E_commerce.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Core.Specifications
{
    public class BaseSpecification<TEntity> : ISpecification<TEntity> where TEntity : BaseEntity
    {
        public Expression<Func<TEntity, bool>> Criteria { get; set; }
        public List<Expression<Func<TEntity, object>>> Includes { get; set; } =
                                                                             new List<Expression<Func<TEntity, object>>>();

       
        public BaseSpecification() 
        {
            //Criteria null
        }
        public BaseSpecification(Expression<Func<TEntity,bool>> criteria) 
        {
            Criteria = criteria;
        }
    }
}
