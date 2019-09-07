using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.Models.Configs;
using MongoDB.Driver;

namespace TestDataService.Models.Repositories
{
	public partial interface ITestRepository : IBaseRepository<Test, String>
	{
	}
	
	public partial class TestRepository : BaseRepository<Test, String>, ITestRepository
	{
		public TestRepository(IMongoDbSettings settings) : base(settings)
		{
		}
		
		#region CRUD area
		
		public override Test FindById(String id)
		{
			var entity = _collection.Find(
			Builders<Test>.Filter.Where(e => e.Id == id)).FirstOrDefault();
			return entity;
		}
		
		public override async Task<Test> FindByIdAsync(String id)
		{
			var entity = await (await _collection.FindAsync(
			Builders<Test>.Filter.Where(e => e.Id == id))).FirstOrDefaultAsync();
			return entity;
		}
		
		public override Test Remove(String id)
		{
			return _collection.FindOneAndDelete(
			Builders<Test>.Filter.Where(e => e.Id == id));
		}
		
		public override Test Remove(IClientSessionHandle handle, String id)
		{
			return _collection.FindOneAndDelete(handle,
			Builders<Test>.Filter.Where(e => e.Id == id));
		}
		
		public override async Task<Test> RemoveAsync(String id)
		{
			return await _collection.FindOneAndDeleteAsync(
			Builders<Test>.Filter.Where(e => e.Id == id));
		}
		
		public override async Task<Test> RemoveAsync(IClientSessionHandle handle, String id)
		{
			return await _collection.FindOneAndDeleteAsync(handle,
			Builders<Test>.Filter.Where(e => e.Id == id));
		}
		
		public override Test Replace(Test entity)
		{
			var id = entity.Id;
			return _collection.FindOneAndReplace(
			Builders<Test>.Filter.Where(e => e.Id == id), entity);
		}
		
		public override async Task<Test> ReplaceAsync(Test entity)
		{
			var id = entity.Id;
			return await _collection.FindOneAndReplaceAsync(
			Builders<Test>.Filter.Where(e => e.Id == id), entity);
		}
		
		public override Test Replace(IClientSessionHandle handle, Test entity)
		{
			var id = entity.Id;
			return _collection.FindOneAndReplace(handle,
			Builders<Test>.Filter.Where(e => e.Id == id), entity);
		}
		
		public override async Task<Test> ReplaceAsync(IClientSessionHandle handle, Test entity)
		{
			var id = entity.Id;
			return await _collection.FindOneAndReplaceAsync(handle,
			Builders<Test>.Filter.Where(e => e.Id == id), entity);
		}
		
		#endregion
		
	}
}
