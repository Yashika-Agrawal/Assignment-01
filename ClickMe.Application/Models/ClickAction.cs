using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace ClickMe.Application.Models 
{
    public class ClickAction : IClickAction
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } // MongoDB generates this automatically

        [BsonElement("utcDateTime")]
        [Required]
        public DateTime UtcDateTime { get; set; }

        [BsonElement("username")]
        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [BsonElement("actionName")]
        [Required]
        [StringLength(100)]
        public string ActionName { get; set; }
    }
}
