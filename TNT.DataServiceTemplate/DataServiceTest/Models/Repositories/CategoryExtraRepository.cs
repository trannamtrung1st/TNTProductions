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
	public partial interface ICategoryExtraRepository : IBaseRepository<CategoryExtra, int>
	{
	}
	
	public partial class CategoryExtraRepository : BaseRepository<CategoryExtra, int>, ICategoryExtraRepository
	{
		public CategoryExtraRepository() : base()
		{
		}
		
		public CategoryExtraRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override CategoryExtra Add(CategoryExtra entity)
		{
			
			entity = context.CategoryExtras.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CategoryExtra> AddAsync(CategoryExtra entity)
		{
			
			entity = context.CategoryExtras.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override CategoryExtra Delete(CategoryExtra entity)
		{
			context.CategoryExtras.Attach(entity);
			entity = context.CategoryExtras.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CategoryExtra> DeleteAsync(CategoryExtra entity)
		{
			context.CategoryExtras.Attach(entity);
			entity = context.CategoryExtras.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override CategoryExtra Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.CategoryExtras.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CategoryExtra> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.CategoryExtras.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override CategoryExtra FindById(int key)
		{
			var entity = context.CategoryExtras.FirstOrDefault(
				e => e.CategoryExtraId == key);
			return entity;
		}
		
		public override CategoryExtra FindActiveById(int key)
		{
			var entity = context.CategoryExtras.FirstOrDefault(
				e => e.CategoryExtraId == key);
			return entity;
		}
		
		public override async Task<CategoryExtra> FindByIdAsync(int key)
		{
			var entity = await context.CategoryExtras.FirstOrDefaultAsync(
				e => e.CategoryExtraId == key);
			return entity;
		}
		
		public override async Task<CategoryExtra> FindActiveByIdAsync(int key)
		{
			var entity = await context.CategoryExtras.FirstOrDefaultAsync(
				e => e.CategoryExtraId == key);
			return entity;
		}
		
		public override CategoryExtra FindByIdInclude<TProperty>(int key, params Expression<Func<CategoryExtra, TProperty>>[] members)
		{
			IQueryable<CategoryExtra> dbSet = context.CategoryExtras;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.CategoryExtraId == key);
		}
		
		public override async Task<CategoryExtra> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<CategoryExtra, TProperty>>[] members)
		{
			IQueryable<CategoryExtra> dbSet = context.CategoryExtras;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.CategoryExtraId == key);
		}
		
		public override CategoryExtra Activate(CategoryExtra entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CategoryExtra Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CategoryExtra Deactivate(CategoryExtra entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CategoryExtra Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<CategoryExtra> GetActive()
		{
			return context.CategoryExtras;
		}
		
		public override IQueryable<CategoryExtra> GetActive(Expression<Func<CategoryExtra, bool>> expr)
		{
			return context.CategoryExtras.Where(expr);
		}
		
		public override CategoryExtra FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override CategoryExtra FirstOrDefault(Expression<Func<CategoryExtra, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<CategoryExtra> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<CategoryExtra> FirstOrDefaultAsync(Expression<Func<CategoryExtra, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override CategoryExtra SingleOrDefault(Expression<Func<CategoryExtra, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<CategoryExtra> SingleOrDefaultAsync(Expression<Func<CategoryExtra, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override CategoryExtra Update(CategoryExtra entity)
		{
			entity = context.CategoryExtras.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CategoryExtra> UpdateAsync(CategoryExtra entity)
		{
			entity = context.CategoryExtras.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
