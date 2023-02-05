using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TransactionHistory.API.Entities
{
    public class TransactionHistory
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public DateTime Datetime { get; set; }
        public decimal Amount { get; set; }
        public string Email { get; set; }
        public string FromFirstName { get; set; }
        public string FromLastName { get; set; }
        public string FromVendor { get; set; }
    }
}
