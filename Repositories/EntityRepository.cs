using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using SenseFramework.Data.MongoDb.Configuration;
using SenseFramework.Data.MongoDb.EntityBases;

namespace SenseFramework.Data.MongoDb.Repositories
{
    public abstract class EntityRepository<TEntity> : IRepository<TEntity> where TEntity:Entity
    {

        private readonly IMongoDatabase _mongoDatabase;

        protected EntityRepository(IMongoClient mongoClient)
        {
            _mongoDatabase = mongoClient.GetDatabase(MongoConfigurationManager.Database);
        }


        public ICollection<TEntity> GetCollection()
        {
            var collection = _mongoDatabase.GetCollection<TEntity>(typeof (TEntity).Name.ToLower() + "s");

            return collection.AsQueryable().ToList();
        }

        public TEntity FindEntity(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public TEntity InsertEntity(TEntity entity)
        {
            //entity.Id = Guid.NewGuid();
            entity.CreationDate= DateTime.Now;

            var collection = _mongoDatabase.GetCollection<TEntity>(typeof (TEntity).Name.ToLower() + "s");

            collection.InsertOne(entity);

            return entity;
        }
    }
}
