using Location.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace Location.Entities
{
    public class City
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public Region Region { get; set; }
    }
}