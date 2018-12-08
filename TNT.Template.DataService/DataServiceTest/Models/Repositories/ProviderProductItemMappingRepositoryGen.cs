using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.Models;
using DataServiceTest.Managers;
using System.Linq.Expressions;
using System.Data.Entity;

namespace DataServiceTest.Models.Repositories
{
	public partial interface IProviderProductItemMappingRepository : IBaseRepository<ProviderProductItemMapping, int>
	{
	}
	
	public partial class ProviderProductItemMappingRepository : BaseRepository<ProviderProductItemMapping, int>, IProviderProductItemMappingRepository
	{
		public ProviderProductItemMappingRepository(DbContext context) : base(context)
		{
		}
		
		public ProviderProductItemMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override ProviderProductItemMapping FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ProviderProductItemId == key);
			return entity;
		}
		
		public override ProviderProductItemMapping FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ProviderProductItemId == key && e.Active);
			return entity;
		}
		
		public override async Task<ProviderProductItemMapping> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ProviderProductItemId == key);
			return entity;
		}
		
		public override async Task<ProviderProductItemMapping> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ProviderProductItemId == key && e.Active);
			return entity;
		}
		
		public override ProviderProductItemMapping Activate(ProviderProductItemMapping entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override ProviderProductItemMapping Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override ProviderProductItemMapping Deactivate(ProviderProductItemMapping entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override ProviderProductItemMapping Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<ProviderProductItemMapping> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<ProviderProductItemMapping> GetActive(Expression<Func<ProviderProductItemMapping, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
