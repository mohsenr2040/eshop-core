using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using System.Collections.Generic;

namespace eshop.Domain.Entities.MongoDb
{
    public class Comment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string UserId { get; set; }
        public string user { get; set; }
        public string text { get; set; }
        public List<Reply> Replies { get; set; }
    }
    public class Reply
    {
        public string UserId { get; set; }
        public string user { get; set; }
        public string text { get; set; }
    }
}
