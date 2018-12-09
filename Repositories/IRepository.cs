using System.Collections.Generic;
using MongoDB.Bson;
using SenseFramework.Data.MongoDb.EntityBases;

namespace SenseFramework.Data.MongoDb.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        ICollection<TEntity> GetCollection();
        TEntity FindEntity(ObjectId id);
        TEntity InsertEntity(TEntity entity);
    }
}
