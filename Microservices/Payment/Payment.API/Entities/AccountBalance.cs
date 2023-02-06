using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Payment.API.Entities
{
    public class AccountBalance
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public decimal Balance { get; set; }
        public string Email { get; set; }
    }
}
