using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blotter.DataLayer.Mongo.Mapping
{
    public static class MongoClassMap
    {
        public static void Instance()
        {
            if (BsonClassMap.IsClassMapRegistered(typeof(Entity)) == false)
            {
                BsonClassMap.RegisterClassMap<Entity>(map =>
                {
                    map.AutoMap();
                    map.SetIgnoreExtraElements(true);
                    map.MapIdMember(c => c.Id)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId))
                    .SetIdGenerator(StringObjectIdGenerator.Instance);

                });
            }
        }
    }
}
