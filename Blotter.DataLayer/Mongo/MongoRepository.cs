using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blotter.DataLayer.Mongo
{
    public class MongoRepository<T> : IRepository<T> 
        where T : Entity
    {
        public T Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
