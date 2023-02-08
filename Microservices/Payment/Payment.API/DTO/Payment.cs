//using MongoDB.Bson;
//using MongoDB.Bson.Serialization.Attributes;

namespace Payment.API.DTO
{
    public class Payment
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        //public string Id { get; set; }
        public DateTime Datetime { get; set; }
        public decimal Amount { get; set; }
        public string FromEmail { get; set; }
        public string FromFirstName { get; set; }
        public string FromLastName { get; set; }
        public string FromVendor { get; set; }
        public string ToEmail { get; set; }
    }
}
