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
	public partial interface ICouponCampaignRepository : IBaseRepository<CouponCampaign, int>
	{
	}
	
	public partial class CouponCampaignRepository : BaseRepository<CouponCampaign, int>, ICouponCampaignRepository
	{
		public CouponCampaignRepository() : base()
		{
		}
		
		public CouponCampaignRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override CouponCampaign Add(CouponCampaign entity)
		{
			
			entity = context.CouponCampaigns.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CouponCampaign> AddAsync(CouponCampaign entity)
		{
			
			entity = context.CouponCampaigns.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override CouponCampaign Delete(CouponCampaign entity)
		{
			context.CouponCampaigns.Attach(entity);
			entity = context.CouponCampaigns.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CouponCampaign> DeleteAsync(CouponCampaign entity)
		{
			context.CouponCampaigns.Attach(entity);
			entity = context.CouponCampaigns.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override CouponCampaign Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.CouponCampaigns.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CouponCampaign> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.CouponCampaigns.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override CouponCampaign FindById(int key)
		{
			var entity = context.CouponCampaigns.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override CouponCampaign FindActiveById(int key)
		{
			var entity = context.CouponCampaigns.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<CouponCampaign> FindByIdAsync(int key)
		{
			var entity = await context.CouponCampaigns.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<CouponCampaign> FindActiveByIdAsync(int key)
		{
			var entity = await context.CouponCampaigns.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override CouponCampaign FindByIdInclude<TProperty>(int key, params Expression<Func<CouponCampaign, TProperty>>[] members)
		{
			IQueryable<CouponCampaign> dbSet = context.CouponCampaigns;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<CouponCampaign> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<CouponCampaign, TProperty>>[] members)
		{
			IQueryable<CouponCampaign> dbSet = context.CouponCampaigns;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override CouponCampaign Activate(CouponCampaign entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CouponCampaign Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CouponCampaign Deactivate(CouponCampaign entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CouponCampaign Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<CouponCampaign> GetActive()
		{
			return context.CouponCampaigns;
		}
		
		public override IQueryable<CouponCampaign> GetActive(Expression<Func<CouponCampaign, bool>> expr)
		{
			return context.CouponCampaigns.Where(expr);
		}
		
		public override CouponCampaign FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override CouponCampaign FirstOrDefault(Expression<Func<CouponCampaign, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<CouponCampaign> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<CouponCampaign> FirstOrDefaultAsync(Expression<Func<CouponCampaign, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override CouponCampaign SingleOrDefault(Expression<Func<CouponCampaign, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<CouponCampaign> SingleOrDefaultAsync(Expression<Func<CouponCampaign, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override CouponCampaign Update(CouponCampaign entity)
		{
			entity = context.CouponCampaigns.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CouponCampaign> UpdateAsync(CouponCampaign entity)
		{
			entity = context.CouponCampaigns.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
