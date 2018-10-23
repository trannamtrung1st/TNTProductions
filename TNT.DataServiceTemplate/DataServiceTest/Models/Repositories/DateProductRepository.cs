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
	public partial interface IDateProductRepository : IBaseRepository<DateProduct, int>
	{
	}
	
	public partial class DateProductRepository : BaseRepository<DateProduct, int>, IDateProductRepository
	{
		public DateProductRepository() : base()
		{
		}
		
		public DateProductRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override DateProduct Add(DateProduct entity)
		{
			
			entity = context.DateProducts.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<DateProduct> AddAsync(DateProduct entity)
		{
			
			entity = context.DateProducts.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override DateProduct Delete(DateProduct entity)
		{
			context.DateProducts.Attach(entity);
			entity = context.DateProducts.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<DateProduct> DeleteAsync(DateProduct entity)
		{
			context.DateProducts.Attach(entity);
			entity = context.DateProducts.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override DateProduct Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.DateProducts.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<DateProduct> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.DateProducts.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override DateProduct FindById(int key)
		{
			var entity = context.DateProducts.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override DateProduct FindActiveById(int key)
		{
			var entity = context.DateProducts.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<DateProduct> FindByIdAsync(int key)
		{
			var entity = await context.DateProducts.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<DateProduct> FindActiveByIdAsync(int key)
		{
			var entity = await context.DateProducts.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override DateProduct FindByIdInclude<TProperty>(int key, params Expression<Func<DateProduct, TProperty>>[] members)
		{
			IQueryable<DateProduct> dbSet = context.DateProducts;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ID == key);
		}
		
		public override async Task<DateProduct> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<DateProduct, TProperty>>[] members)
		{
			IQueryable<DateProduct> dbSet = context.DateProducts;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
		}
		
		public override DateProduct Activate(DateProduct entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override DateProduct Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override DateProduct Deactivate(DateProduct entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override DateProduct Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<DateProduct> GetActive()
		{
			return context.DateProducts;
		}
		
		public override IQueryable<DateProduct> GetActive(Expression<Func<DateProduct, bool>> expr)
		{
			return context.DateProducts.Where(expr);
		}
		
		public override DateProduct FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override DateProduct FirstOrDefault(Expression<Func<DateProduct, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<DateProduct> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<DateProduct> FirstOrDefaultAsync(Expression<Func<DateProduct, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override DateProduct SingleOrDefault(Expression<Func<DateProduct, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<DateProduct> SingleOrDefaultAsync(Expression<Func<DateProduct, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override DateProduct Update(DateProduct entity)
		{
			entity = context.DateProducts.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<DateProduct> UpdateAsync(DateProduct entity)
		{
			entity = context.DateProducts.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
