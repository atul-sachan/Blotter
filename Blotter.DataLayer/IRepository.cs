using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blotter.DataLayer
{
    public interface IRepository<T> where T : Entity
    {
        #region FindById
        T Get(string id);
        Task<T> GetAsync(string id);
        #endregion

        #region Insert
        void Insert(T entity);
        Task InsertAsync(T entity); 
        #endregion
    }
}
