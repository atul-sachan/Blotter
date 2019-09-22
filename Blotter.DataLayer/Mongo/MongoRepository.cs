using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blotter.DataLayer.Mongo
{
    public class MongoRepository<T> : MongoRepositoryBase, IRepository<T> 
        where T : Entity
    {

        public MongoRepository(IConfigurationRoot configuration)
            : base(configuration)
        {

        }

        public MongoRepository(IConfigurationRoot configuration, string connectionId)
            : base(configuration, connectionId)
        {

        }

        public IMongoCollection<T> Collection
        {
            get
            {
                return GetCollection<T>();
            }
        }

        public FilterDefinitionBuilder<T> Filter => Builders<T>.Filter;
        public ProjectionDefinitionBuilder<T> Project => Builders<T>.Projection;

        private IFindFluent<T, T> Query(Expression<Func<T, bool>> filter)
        {
            return Collection.Find(filter);
        }

        private IFindFluent<T, T> Query()
        {
            return Collection.Find(Filter.Empty);
        }

        #region Get
        public virtual T Get(string id)
        {
            return Retry(() =>
            {
                return Query(i => i.Id == id).FirstOrDefault();
            });
        }

        public virtual async Task<T> GetAsync(string id)
        {
            return await Retry(async () =>
            {
                return await Query(i => i.Id == id).FirstOrDefaultAsync();
            });
        }
        #endregion

        public virtual void Insert(T entity)
        {
            Retry(() =>
            {
                Collection.InsertOne(entity);
                return true;
            });
        }

        public virtual async Task InsertAsync(T entity)
        {
            await Retry(async () =>
            {
                await Collection.InsertOneAsync(entity);
                return true;
            });
        }

        #region RetryPolicy

        protected virtual TResult Retry<TResult>(Func<TResult> action)
        {
            return RetryPolicy
                .Handle<MongoConnectionException>(i => i.InnerException.GetType() == typeof(IOException))
                .Retry(3)
                .Execute(action);
        }

        #endregion
    }
}
