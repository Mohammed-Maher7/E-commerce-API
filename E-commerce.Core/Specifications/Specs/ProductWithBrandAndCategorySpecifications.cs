using E_commerce.Core.Entities;
using E_commerce.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Core.Specifications.Specs
{
    public class ProductWithBrandAndCategorySpecifications:BaseSpecification<Product>
    {
        public ProductWithBrandAndCategorySpecifications() : base()
        {
            AddIncludes();
        }
        public ProductWithBrandAndCategorySpecifications(Expression<Func<Product,bool>> criteria) : base(criteria)
        {
            AddIncludes();
        }

        private void AddIncludes() 
        {
            Includes.Add(P => P.Category);
            Includes.Add(P => P.Brand);
        }


    }
}
