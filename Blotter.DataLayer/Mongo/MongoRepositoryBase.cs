﻿using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blotter.DataLayer.Mongo
{
    public abstract class MongoRepositoryBase : IDisposable
    {
        private string connectionId;
        private string connectionString;
        IConfigurationRoot configuration;

        public MongoRepositoryBase()
        {

        }

        public MongoRepositoryBase(IConfigurationRoot configuration)
            : this()
        {
            this.connectionId = "MongoConnection";
            this.configuration = configuration;
        }

        public MongoRepositoryBase(IConfigurationRoot configuration, string connectionId)
        {
            this.connectionId = connectionId;
            this.configuration = configuration;
        }

        public virtual string ConnectionId
        {
            get
            {
                return connectionId;
            }
        }

        public MongoRepositoryBase UserConnectionId(string connectionId)
        {
            this.connectionId = connectionId;
            return this;
        }

        public MongoRepositoryBase UserConnectionString(string connectionString)
        {
            this.connectionString = connectionString;
            return this;
        }

        public IMongoDatabase Database
        {
            get
            {

                if (string.IsNullOrEmpty(connectionString))
                {
                    connectionString = configuration.GetSection(ConnectionId).Value;
                }
                var mongoUrl = new MongoUrl(connectionString);
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase(mongoUrl.DatabaseName);
                return database;
            }
        }

        public IMongoCollection<T> GetCollection<T>()
        {
            return Database.GetCollection<T>((typeof(T).Name));
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
