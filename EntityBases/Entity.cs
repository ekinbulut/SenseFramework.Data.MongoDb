using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace SenseFramework.Data.MongoDb.EntityBases
{
    [BsonSerializer]
    public abstract class Entity
    {
        //public Guid Id { get; set; }
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
