using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.Models.Configs;
using MongoDB.Driver;

namespace TestDataService.Models.Repositories
{
	public partial interface ITNTRepository : IBaseRepository<TNT, String>
	{
	}
	
	public partial class TNTRepository : BaseRepository<TNT, String>, ITNTRepository
	{
		public TNTRepository(IMongoDbSettings settings) : base(settings)
		{
		}
		
		#region CRUD area
		
		public override TNT FindById(String id)
		{
			var entity = _collection.Find(
				e => e.Id == id).FirstOrDefault();
			return entity;
		}
		
		public override async Task<TNT> FindByIdAsync(String id)
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
		
		public override ReplaceOneResult Replace(TNT entity)
		{
			var id = entity.Id;
			return _collection.ReplaceOne(
				e => e.Id == id, entity);
		}
		
		public override async Task<ReplaceOneResult> ReplaceAsync(TNT entity)
		{
			var id = entity.Id;
			return await _collection.ReplaceOneAsync(
				e => e.Id == id, entity);
		}
		
		public override ReplaceOneResult Replace(IClientSessionHandle handle, TNT entity)
		{
			var id = entity.Id;
			return _collection.ReplaceOne(handle,
				e => e.Id == id, entity);
		}
		
		public override async Task<ReplaceOneResult> ReplaceAsync(IClientSessionHandle handle, TNT entity)
		{
			var id = entity.Id;
			return await _collection.ReplaceOneAsync(handle,
				e => e.Id == id, entity);
		}
		
		#endregion
		
	}
}
