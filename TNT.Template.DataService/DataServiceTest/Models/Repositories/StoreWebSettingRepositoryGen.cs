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
	public partial interface IStoreWebSettingRepository : IBaseRepository<StoreWebSetting, int>
	{
	}
	
	public partial class StoreWebSettingRepository : BaseRepository<StoreWebSetting, int>, IStoreWebSettingRepository
	{
		public StoreWebSettingRepository(DbContext context) : base(context)
		{
		}
		
		public StoreWebSettingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override StoreWebSetting FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override StoreWebSetting FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<StoreWebSetting> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<StoreWebSetting> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override StoreWebSetting Activate(StoreWebSetting entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override StoreWebSetting Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override StoreWebSetting Deactivate(StoreWebSetting entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override StoreWebSetting Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<StoreWebSetting> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<StoreWebSetting> GetActive(Expression<Func<StoreWebSetting, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
