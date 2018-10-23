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
	public partial interface IPriceAdditionRepository : IBaseRepository<PriceAddition, int>
	{
	}
	
	public partial class PriceAdditionRepository : BaseRepository<PriceAddition, int>, IPriceAdditionRepository
	{
		public PriceAdditionRepository() : base()
		{
		}
		
		public PriceAdditionRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PriceAddition Add(PriceAddition entity)
		{
			
			entity = context.PriceAdditions.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PriceAddition> AddAsync(PriceAddition entity)
		{
			
			entity = context.PriceAdditions.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override PriceAddition Delete(PriceAddition entity)
		{
			context.PriceAdditions.Attach(entity);
			entity = context.PriceAdditions.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PriceAddition> DeleteAsync(PriceAddition entity)
		{
			context.PriceAdditions.Attach(entity);
			entity = context.PriceAdditions.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override PriceAddition Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.PriceAdditions.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PriceAddition> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.PriceAdditions.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override PriceAddition FindById(int key)
		{
			var entity = context.PriceAdditions.FirstOrDefault(
				e => e.AdditionPriceID == key);
			return entity;
		}
		
		public override PriceAddition FindActiveById(int key)
		{
			var entity = context.PriceAdditions.FirstOrDefault(
				e => e.AdditionPriceID == key);
			return entity;
		}
		
		public override async Task<PriceAddition> FindByIdAsync(int key)
		{
			var entity = await context.PriceAdditions.FirstOrDefaultAsync(
				e => e.AdditionPriceID == key);
			return entity;
		}
		
		public override async Task<PriceAddition> FindActiveByIdAsync(int key)
		{
			var entity = await context.PriceAdditions.FirstOrDefaultAsync(
				e => e.AdditionPriceID == key);
			return entity;
		}
		
		public override PriceAddition FindByIdInclude<TProperty>(int key, params Expression<Func<PriceAddition, TProperty>>[] members)
		{
			IQueryable<PriceAddition> dbSet = context.PriceAdditions;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.AdditionPriceID == key);
		}
		
		public override async Task<PriceAddition> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<PriceAddition, TProperty>>[] members)
		{
			IQueryable<PriceAddition> dbSet = context.PriceAdditions;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.AdditionPriceID == key);
		}
		
		public override PriceAddition Activate(PriceAddition entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PriceAddition Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PriceAddition Deactivate(PriceAddition entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PriceAddition Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<PriceAddition> GetActive()
		{
			return context.PriceAdditions;
		}
		
		public override IQueryable<PriceAddition> GetActive(Expression<Func<PriceAddition, bool>> expr)
		{
			return context.PriceAdditions.Where(expr);
		}
		
		public override PriceAddition FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override PriceAddition FirstOrDefault(Expression<Func<PriceAddition, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<PriceAddition> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<PriceAddition> FirstOrDefaultAsync(Expression<Func<PriceAddition, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override PriceAddition SingleOrDefault(Expression<Func<PriceAddition, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<PriceAddition> SingleOrDefaultAsync(Expression<Func<PriceAddition, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override PriceAddition Update(PriceAddition entity)
		{
			entity = context.PriceAdditions.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PriceAddition> UpdateAsync(PriceAddition entity)
		{
			entity = context.PriceAdditions.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
