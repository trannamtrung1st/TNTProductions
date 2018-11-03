using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoterDataService.Models;
using PromoterDataService.Managers;
using System.Linq.Expressions;
using System.Data.Entity;

namespace PromoterDataService.Models.Repositories
{
	public partial interface IVoucherConfigRepository : IBaseRepository<VoucherConfig, int>
	{
	}
	
	public partial class VoucherConfigRepository : BaseRepository<VoucherConfig, int>, IVoucherConfigRepository
	{
		public VoucherConfigRepository() : base()
		{
		}
		
		public VoucherConfigRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override VoucherConfig Add(VoucherConfig entity)
		{
			
			entity = context.VoucherConfigs.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<VoucherConfig> AddAsync(VoucherConfig entity)
		{
			
			entity = context.VoucherConfigs.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override VoucherConfig Delete(VoucherConfig entity)
		{
			context.VoucherConfigs.Attach(entity);
			entity = context.VoucherConfigs.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<VoucherConfig> DeleteAsync(VoucherConfig entity)
		{
			context.VoucherConfigs.Attach(entity);
			entity = context.VoucherConfigs.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override VoucherConfig Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.VoucherConfigs.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<VoucherConfig> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.VoucherConfigs.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override VoucherConfig FindById(int key)
		{
			var entity = context.VoucherConfigs.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override VoucherConfig FindActiveById(int key)
		{
			var entity = context.VoucherConfigs.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<VoucherConfig> FindByIdAsync(int key)
		{
			var entity = await context.VoucherConfigs.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<VoucherConfig> FindActiveByIdAsync(int key)
		{
			var entity = await context.VoucherConfigs.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override VoucherConfig FindByIdInclude<TProperty>(int key, params Expression<Func<VoucherConfig, TProperty>>[] members)
		{
			IQueryable<VoucherConfig> dbSet = context.VoucherConfigs;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ID == key);
		}
		
		public override async Task<VoucherConfig> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<VoucherConfig, TProperty>>[] members)
		{
			IQueryable<VoucherConfig> dbSet = context.VoucherConfigs;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
		}
		
		public override VoucherConfig Activate(VoucherConfig entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override VoucherConfig Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override VoucherConfig Deactivate(VoucherConfig entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override VoucherConfig Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<VoucherConfig> GetActive()
		{
			return context.VoucherConfigs;
		}
		
		public override IQueryable<VoucherConfig> GetActive(Expression<Func<VoucherConfig, bool>> expr)
		{
			return context.VoucherConfigs.Where(expr);
		}
		
		public override VoucherConfig FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override VoucherConfig FirstOrDefault(Expression<Func<VoucherConfig, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<VoucherConfig> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<VoucherConfig> FirstOrDefaultAsync(Expression<Func<VoucherConfig, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override VoucherConfig SingleOrDefault(Expression<Func<VoucherConfig, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<VoucherConfig> SingleOrDefaultAsync(Expression<Func<VoucherConfig, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override VoucherConfig Update(VoucherConfig entity)
		{
			entity = context.VoucherConfigs.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<VoucherConfig> UpdateAsync(VoucherConfig entity)
		{
			entity = context.VoucherConfigs.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
