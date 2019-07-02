using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempDataService.Models.Configs;
using MongoDB.Driver;

namespace TempDataService.Models.Repositories
{
	public partial interface ITestBooksRepository : IBaseRepository<TestBooks, String>
	{
	}
	
	public partial class TestBooksRepository : BaseRepository<TestBooks, String>, ITestBooksRepository
	{
		public TestBooksRepository(IMongoDbSettings settings) : base(settings)
		{
		}
		
		#region CRUD area
		
		public override TestBooks FindById(String id)
		{
			var entity = _collection.Find(
				e => e.Id == id).FirstOrDefault();
			return entity;
		}
		
		public override async Task<TestBooks> FindByIdAsync(String id)
		{
			var entity = await (await _collection.FindAsync(
				e => e.Id == id)).FirstOrDefaultAsync();
			return entity;
		}
		
		public override DeleteResult Remove(String id)
		{
			return _collection.DeleteOne(
				e => e.Id == id);
		}
		
		public override DeleteResult Remove(IClientSessionHandle handle, String id)
		{
			return _collection.DeleteOne(handle,
				e => e.Id == id);
		}
		
		public override async Task<DeleteResult> RemoveAsync(String id)
		{
			return await _collection.DeleteOneAsync(
				e => e.Id == id);
		}
		
		public override async Task<DeleteResult> RemoveAsync(IClientSessionHandle handle, String id)
		{
			return await _collection.DeleteOneAsync(handle,
				e => e.Id == id);
		}
		
		public override ReplaceOneResult Replace(TestBooks entity)
		{
			var id = entity.Id;
			return _collection.ReplaceOne(
				e => e.Id == id, entity);
		}
		
		public override async Task<ReplaceOneResult> ReplaceAsync(TestBooks entity)
		{
			var id = entity.Id;
			return await _collection.ReplaceOneAsync(
				e => e.Id == id, entity);
		}
		
		public override ReplaceOneResult Replace(IClientSessionHandle handle, TestBooks entity)
		{
			var id = entity.Id;
			return _collection.ReplaceOne(handle,
				e => e.Id == id, entity);
		}
		
		public override async Task<ReplaceOneResult> ReplaceAsync(IClientSessionHandle handle, TestBooks entity)
		{
			var id = entity.Id;
			return await _collection.ReplaceOneAsync(handle,
				e => e.Id == id, entity);
		}
		
		#endregion
		
	}
}
