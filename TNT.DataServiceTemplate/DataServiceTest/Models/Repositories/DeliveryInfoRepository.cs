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
	public partial interface IDeliveryInfoRepository : IBaseRepository<DeliveryInfo, int>
	{
	}
	
	public partial class DeliveryInfoRepository : BaseRepository<DeliveryInfo, int>, IDeliveryInfoRepository
	{
		public DeliveryInfoRepository() : base()
		{
		}
		
		public DeliveryInfoRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override DeliveryInfo Add(DeliveryInfo entity)
		{
			
			entity = context.DeliveryInfoes.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<DeliveryInfo> AddAsync(DeliveryInfo entity)
		{
			
			entity = context.DeliveryInfoes.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override DeliveryInfo Delete(DeliveryInfo entity)
		{
			context.DeliveryInfoes.Attach(entity);
			entity = context.DeliveryInfoes.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<DeliveryInfo> DeleteAsync(DeliveryInfo entity)
		{
			context.DeliveryInfoes.Attach(entity);
			entity = context.DeliveryInfoes.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override DeliveryInfo Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.DeliveryInfoes.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<DeliveryInfo> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.DeliveryInfoes.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override DeliveryInfo FindById(int key)
		{
			var entity = context.DeliveryInfoes.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override DeliveryInfo FindActiveById(int key)
		{
			var entity = context.DeliveryInfoes.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<DeliveryInfo> FindByIdAsync(int key)
		{
			var entity = await context.DeliveryInfoes.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<DeliveryInfo> FindActiveByIdAsync(int key)
		{
			var entity = await context.DeliveryInfoes.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override DeliveryInfo FindByIdInclude<TProperty>(int key, params Expression<Func<DeliveryInfo, TProperty>>[] members)
		{
			IQueryable<DeliveryInfo> dbSet = context.DeliveryInfoes;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<DeliveryInfo> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<DeliveryInfo, TProperty>>[] members)
		{
			IQueryable<DeliveryInfo> dbSet = context.DeliveryInfoes;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override DeliveryInfo Activate(DeliveryInfo entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override DeliveryInfo Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override DeliveryInfo Deactivate(DeliveryInfo entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override DeliveryInfo Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<DeliveryInfo> GetActive()
		{
			return context.DeliveryInfoes;
		}
		
		public override IQueryable<DeliveryInfo> GetActive(Expression<Func<DeliveryInfo, bool>> expr)
		{
			return context.DeliveryInfoes.Where(expr);
		}
		
		public override DeliveryInfo FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override DeliveryInfo FirstOrDefault(Expression<Func<DeliveryInfo, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<DeliveryInfo> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<DeliveryInfo> FirstOrDefaultAsync(Expression<Func<DeliveryInfo, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override DeliveryInfo SingleOrDefault(Expression<Func<DeliveryInfo, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<DeliveryInfo> SingleOrDefaultAsync(Expression<Func<DeliveryInfo, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override DeliveryInfo Update(DeliveryInfo entity)
		{
			entity = context.DeliveryInfoes.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<DeliveryInfo> UpdateAsync(DeliveryInfo entity)
		{
			entity = context.DeliveryInfoes.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
