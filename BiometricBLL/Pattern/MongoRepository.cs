using BiometricBLL.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace BiometricBLL.Pattern
{
    public abstract class MongoRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly IMongoClient _mongoClient;
        protected readonly IMongoDatabase _mongoDatabase;
        protected readonly IMongoCollection<TEntity> _mongoCollection;

        public MongoRepository(string connectionString, string databaseName, string collectionName)
        {
            _mongoClient = new MongoClient(connectionString);
            _mongoDatabase = _mongoClient.GetDatabase(databaseName);
            _mongoCollection = _mongoDatabase.GetCollection<TEntity>(collectionName);
        }

        public virtual TEntity Add(TEntity entity)
        {
            entity.ModifiedDate = DateTime.Now;
            _mongoCollection.InsertOne(entity);
            return entity;
        }

        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _mongoCollection.Find(new BsonDocument()).ToList();
        }

        public virtual TEntity GetById(ObjectId id)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", id);
            var result = _mongoCollection.Find(filter).SingleOrDefault();
            return result;
        }

        public virtual bool Remove(ObjectId id)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", id);
            var result = _mongoCollection.DeleteOne(filter);
            return result.DeletedCount != 0;
        }

        public virtual bool Update(TEntity entity)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", entity.Id);
            entity.ModifiedDate = DateTime.Now;
            var result = _mongoCollection.ReplaceOne(filter, entity);
            return result.ModifiedCount != 0;
        }
    }
}
