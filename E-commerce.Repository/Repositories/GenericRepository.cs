using E_commerce.Core.Entities;
using E_commerce.Core.Interfaces;
using E_commerce.Repository.Data;
using E_commerce.Repository.QueryBuilder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _db;

        public GenericRepository(StoreContext storeContext) 
        {
            _db = storeContext;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {    
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllWithSpecsAsync(ISpecification<T> specs)
        {
            return await ApplySpecification(specs).ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {  
            return await _db.Set<T>().FindAsync(id) ;
        }

        public async Task<T?> GetByIdWithSpecsAsync(int id, ISpecification<T> specs)
        {
            return await ApplySpecification(specs).FirstOrDefaultAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> specs) 
        {
            return SpecificationEvaluator<T>.GetQuery(_db.Set<T>(), specs);
        }
    }
}
