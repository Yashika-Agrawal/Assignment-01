using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ClickMeApi.Models
{
    public class ClickAction
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } // MongoDB generates this automatically

        [BsonElement("utcDateTime")]
        public DateTime UtcDateTime { get; set; }

        [BsonElement("username")]
        public string Username { get; set; }

        [BsonElement("actionName")]
        public string ActionName { get; set; }
    }
}
