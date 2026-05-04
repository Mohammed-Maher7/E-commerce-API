using E_commerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public Task<T?> GetByIdAsync(int id);
        public Task<IEnumerable<T>> GetAllAsync();

        //using Specific design pattern
        public Task<T?> GetByIdWithSpecsAsync(int id, ISpecification<T> specs);
        public Task<IEnumerable<T>> GetAllWithSpecsAsync(ISpecification<T> specs);
    }
}
