using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Linq;

namespace ODataMongoDB.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TestController : ControllerBase
	{
		private readonly IMongoCollection<TestEntity> _testEntityCollection;

		public TestController(IOptions<MongoDatabaseSettings> mongoDatabaseSettings)
		{
			var mongoClient = new MongoClient(
				mongoDatabaseSettings.Value.ConnectionString);

			var mongoDatabase = mongoClient.GetDatabase(
				mongoDatabaseSettings.Value.DatabaseName);

			_testEntityCollection = mongoDatabase.GetCollection<TestEntity>(TestEntity.COLLECTION_NAME);
		}

		//Call it with ?'$filter=nullableIntValue eq 3" to see exception
		//"?$filter=intValue eq 3" works fine
		[HttpGet]
		[EnableQuery]
		public IQueryable<TestEntity> GetTestEntities()
		{
			return _testEntityCollection.AsQueryable();
		}
	}
}
