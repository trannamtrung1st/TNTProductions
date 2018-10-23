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
	public partial interface ICostRepository : IBaseRepository<Cost, int>
	{
	}
	
	public partial class CostRepository : BaseRepository<Cost, int>, ICostRepository
	{
		public CostRepository() : base()
		{
		}
		
		public CostRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Cost Add(Cost entity)
		{
			
			entity = context.Costs.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Cost> AddAsync(Cost entity)
		{
			
			entity = context.Costs.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Cost Delete(Cost entity)
		{
			context.Costs.Attach(entity);
			entity = context.Costs.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Cost> DeleteAsync(Cost entity)
		{
			context.Costs.Attach(entity);
			entity = context.Costs.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Cost Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Costs.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Cost> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Costs.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Cost FindById(int key)
		{
			var entity = context.Costs.FirstOrDefault(
				e => e.CostID == key);
			return entity;
		}
		
		public override Cost FindActiveById(int key)
		{
			var entity = context.Costs.FirstOrDefault(
				e => e.CostID == key);
			return entity;
		}
		
		public override async Task<Cost> FindByIdAsync(int key)
		{
			var entity = await context.Costs.FirstOrDefaultAsync(
				e => e.CostID == key);
			return entity;
		}
		
		public override async Task<Cost> FindActiveByIdAsync(int key)
		{
			var entity = await context.Costs.FirstOrDefaultAsync(
				e => e.CostID == key);
			return entity;
		}
		
		public override Cost FindByIdInclude<TProperty>(int key, params Expression<Func<Cost, TProperty>>[] members)
		{
			IQueryable<Cost> dbSet = context.Costs;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.CostID == key);
		}
		
		public override async Task<Cost> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Cost, TProperty>>[] members)
		{
			IQueryable<Cost> dbSet = context.Costs;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.CostID == key);
		}
		
		public override Cost Activate(Cost entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Cost Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Cost Deactivate(Cost entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Cost Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Cost> GetActive()
		{
			return context.Costs;
		}
		
		public override IQueryable<Cost> GetActive(Expression<Func<Cost, bool>> expr)
		{
			return context.Costs.Where(expr);
		}
		
		public override Cost FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Cost FirstOrDefault(Expression<Func<Cost, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Cost> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Cost> FirstOrDefaultAsync(Expression<Func<Cost, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Cost SingleOrDefault(Expression<Func<Cost, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Cost> SingleOrDefaultAsync(Expression<Func<Cost, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Cost Update(Cost entity)
		{
			entity = context.Costs.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Cost> UpdateAsync(Cost entity)
		{
			entity = context.Costs.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
