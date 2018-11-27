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
	public partial interface IDateProductItemRepository : IBaseRepository<DateProductItem, int>
	{
	}
	
	public partial class DateProductItemRepository : BaseRepository<DateProductItem, int>, IDateProductItemRepository
	{
		public DateProductItemRepository() : base()
		{
		}
		
		public DateProductItemRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override DateProductItem Add(DateProductItem entity)
		{
			
			entity = context.DateProductItems.Add(entity);
			return entity;
		}
		
		public override DateProductItem Remove(DateProductItem entity)
		{
			context.DateProductItems.Attach(entity);
			entity = context.DateProductItems.Remove(entity);
			return entity;
		}
		
		public override DateProductItem Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.DateProductItems.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<DateProductItem> RemoveIf(Expression<Func<DateProductItem, bool>> expr)
		{
			return context.DateProductItems.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<DateProductItem> RemoveRange(IEnumerable<DateProductItem> list)
		{
			return context.DateProductItems.RemoveRange(list);
		}
		
		public override DateProductItem FindById(int key)
		{
			var entity = context.DateProductItems.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override DateProductItem FindActiveById(int key)
		{
			var entity = context.DateProductItems.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<DateProductItem> FindByIdAsync(int key)
		{
			var entity = await context.DateProductItems.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<DateProductItem> FindActiveByIdAsync(int key)
		{
			var entity = await context.DateProductItems.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override DateProductItem FindByIdInclude<TProperty>(int key, params Expression<Func<DateProductItem, TProperty>>[] members)
		{
			IQueryable<DateProductItem> dbSet = context.DateProductItems;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ID == key);
		}
		
		public override async Task<DateProductItem> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<DateProductItem, TProperty>>[] members)
		{
			IQueryable<DateProductItem> dbSet = context.DateProductItems;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
		}
		
		public override DateProductItem Activate(DateProductItem entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override DateProductItem Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override DateProductItem Deactivate(DateProductItem entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override DateProductItem Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<DateProductItem> GetActive()
		{
			return context.DateProductItems;
		}
		
		public override IQueryable<DateProductItem> GetActive(Expression<Func<DateProductItem, bool>> expr)
		{
			return context.DateProductItems.Where(expr);
		}
		
		public override DateProductItem FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override DateProductItem FirstOrDefault(Expression<Func<DateProductItem, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<DateProductItem> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<DateProductItem> FirstOrDefaultAsync(Expression<Func<DateProductItem, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override DateProductItem SingleOrDefault(Expression<Func<DateProductItem, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<DateProductItem> SingleOrDefaultAsync(Expression<Func<DateProductItem, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override DateProductItem Update(DateProductItem entity)
		{
			entity = context.DateProductItems.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
