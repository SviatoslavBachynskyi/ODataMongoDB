using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ODataMongoDB
{
	public class TestEntity
	{
		public const string COLLECTION_NAME = "test";

		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		public int IntValue { get; set; }

		public int? NullableIntValue { get; set; }
	}
}
