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
	public partial interface IPosConfigRepository : IBaseRepository<PosConfig, int>
	{
	}
	
	public partial class PosConfigRepository : BaseRepository<PosConfig, int>, IPosConfigRepository
	{
		public PosConfigRepository() : base()
		{
		}
		
		public PosConfigRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PosConfig Add(PosConfig entity)
		{
			
			entity = context.PosConfigs.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PosConfig> AddAsync(PosConfig entity)
		{
			
			entity = context.PosConfigs.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override PosConfig Delete(PosConfig entity)
		{
			context.PosConfigs.Attach(entity);
			entity = context.PosConfigs.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PosConfig> DeleteAsync(PosConfig entity)
		{
			context.PosConfigs.Attach(entity);
			entity = context.PosConfigs.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override PosConfig Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.PosConfigs.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PosConfig> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.PosConfigs.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override PosConfig FindById(int key)
		{
			var entity = context.PosConfigs.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override PosConfig FindActiveById(int key)
		{
			var entity = context.PosConfigs.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<PosConfig> FindByIdAsync(int key)
		{
			var entity = await context.PosConfigs.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<PosConfig> FindActiveByIdAsync(int key)
		{
			var entity = await context.PosConfigs.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override PosConfig FindByIdInclude<TProperty>(int key, params Expression<Func<PosConfig, TProperty>>[] members)
		{
			IQueryable<PosConfig> dbSet = context.PosConfigs;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<PosConfig> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<PosConfig, TProperty>>[] members)
		{
			IQueryable<PosConfig> dbSet = context.PosConfigs;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override PosConfig Activate(PosConfig entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PosConfig Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PosConfig Deactivate(PosConfig entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PosConfig Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<PosConfig> GetActive()
		{
			return context.PosConfigs;
		}
		
		public override IQueryable<PosConfig> GetActive(Expression<Func<PosConfig, bool>> expr)
		{
			return context.PosConfigs.Where(expr);
		}
		
		public override PosConfig FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override PosConfig FirstOrDefault(Expression<Func<PosConfig, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<PosConfig> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<PosConfig> FirstOrDefaultAsync(Expression<Func<PosConfig, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override PosConfig SingleOrDefault(Expression<Func<PosConfig, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<PosConfig> SingleOrDefaultAsync(Expression<Func<PosConfig, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override PosConfig Update(PosConfig entity)
		{
			entity = context.PosConfigs.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PosConfig> UpdateAsync(PosConfig entity)
		{
			entity = context.PosConfigs.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
