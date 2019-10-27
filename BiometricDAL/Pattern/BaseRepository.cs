using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiometricDAL.Pattern
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoClient _mongoClient;
        protected readonly IMongoDatabase _mongoDatabase;
        protected readonly IMongoCollection<TEntity> _mongoCollection;

        public BaseRepository(string connectionString, string databaseName, string collectionName)
        {
            _mongoClient = new MongoClient(connectionString);
            _mongoDatabase = _mongoClient.GetDatabase(databaseName);
            _mongoCollection = _mongoDatabase.GetCollection<TEntity>(collectionName);
        }

        public virtual void Add(TEntity entity)
        {
            _mongoCollection.InsertOne(entity);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _mongoCollection.Find(new BsonDocument()).ToList();
        }

        public virtual TEntity GetById(Guid id)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", id);
            var result = _mongoCollection.Find(filter).SingleOrDefault();
            return result;
        }

        public virtual IEnumerable<TEntity> GetEntitiesByField(string fieldName, string fieldValue)
        {
            var filter = Builders<TEntity>.Filter.Eq(fieldName, fieldValue);
            var result = _mongoCollection.Find(filter).ToList();
            return result;
        }

        public virtual bool Remove(Guid id)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", id);
            var result = _mongoCollection.DeleteOne(filter);
            return result.DeletedCount != 0;
        }

        public virtual bool Update(Guid id, string fieldName, string fieldValue)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", id);
            var update = Builders<TEntity>.Update.Set(fieldName, fieldValue);
            var result = _mongoCollection.UpdateOne(filter, update);
            return result.ModifiedCount != 0;
        }

        public virtual bool Update(Guid id, TEntity entity)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", id);
            var result = _mongoCollection.ReplaceOne(filter, entity);
            return result.ModifiedCount != 0;
        }
    }
}
