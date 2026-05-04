//using E_commerce.Core.Entities;
//using E_commerce.Core.Interfaces;
//using E_commerce.Repository.Data;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace E_commerce.Repository.Repositories
//{
//    public class UnitOfWork<T> : IUnitOfWork<T> where T : BaseEntity
//    {
//        private StoreContext _db;

//        public UnitOfWork(StoreContext storeContext)
//        {
//            _db = storeContext;
//        }
//        public Task<T> GetById(int id)
//        {
//           var item= _db.Set<T>().Find(id);
//            return item;
//        }
//        public Task<ICollection<T>> GetAll()
//        {
//            throw new NotImplementedException();
//        }
//        public void Add(T item)
//        {
//            throw new NotImplementedException();
//        }

//        public void Delete(int itemId)
//        {
//            throw new NotImplementedException();
//        }

//        public void Update(T item)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
