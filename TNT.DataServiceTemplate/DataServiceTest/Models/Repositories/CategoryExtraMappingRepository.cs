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
	public partial interface ICategoryExtraMappingRepository : IBaseRepository<CategoryExtraMapping, int>
	{
	}
	
	public partial class CategoryExtraMappingRepository : BaseRepository<CategoryExtraMapping, int>, ICategoryExtraMappingRepository
	{
		public CategoryExtraMappingRepository() : base()
		{
		}
		
		public CategoryExtraMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override CategoryExtraMapping Add(CategoryExtraMapping entity)
		{
			
			entity = context.CategoryExtraMappings.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CategoryExtraMapping> AddAsync(CategoryExtraMapping entity)
		{
			
			entity = context.CategoryExtraMappings.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override CategoryExtraMapping Delete(CategoryExtraMapping entity)
		{
			context.CategoryExtraMappings.Attach(entity);
			entity = context.CategoryExtraMappings.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CategoryExtraMapping> DeleteAsync(CategoryExtraMapping entity)
		{
			context.CategoryExtraMappings.Attach(entity);
			entity = context.CategoryExtraMappings.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override CategoryExtraMapping Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.CategoryExtraMappings.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CategoryExtraMapping> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.CategoryExtraMappings.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override CategoryExtraMapping FindById(int key)
		{
			var entity = context.CategoryExtraMappings.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override CategoryExtraMapping FindActiveById(int key)
		{
			var entity = context.CategoryExtraMappings.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<CategoryExtraMapping> FindByIdAsync(int key)
		{
			var entity = await context.CategoryExtraMappings.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<CategoryExtraMapping> FindActiveByIdAsync(int key)
		{
			var entity = await context.CategoryExtraMappings.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override CategoryExtraMapping FindByIdInclude<TProperty>(int key, params Expression<Func<CategoryExtraMapping, TProperty>>[] members)
		{
			IQueryable<CategoryExtraMapping> dbSet = context.CategoryExtraMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<CategoryExtraMapping> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<CategoryExtraMapping, TProperty>>[] members)
		{
			IQueryable<CategoryExtraMapping> dbSet = context.CategoryExtraMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override CategoryExtraMapping Activate(CategoryExtraMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CategoryExtraMapping Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CategoryExtraMapping Deactivate(CategoryExtraMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CategoryExtraMapping Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<CategoryExtraMapping> GetActive()
		{
			return context.CategoryExtraMappings;
		}
		
		public override IQueryable<CategoryExtraMapping> GetActive(Expression<Func<CategoryExtraMapping, bool>> expr)
		{
			return context.CategoryExtraMappings.Where(expr);
		}
		
		public override CategoryExtraMapping FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override CategoryExtraMapping FirstOrDefault(Expression<Func<CategoryExtraMapping, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<CategoryExtraMapping> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<CategoryExtraMapping> FirstOrDefaultAsync(Expression<Func<CategoryExtraMapping, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override CategoryExtraMapping SingleOrDefault(Expression<Func<CategoryExtraMapping, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<CategoryExtraMapping> SingleOrDefaultAsync(Expression<Func<CategoryExtraMapping, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override CategoryExtraMapping Update(CategoryExtraMapping entity)
		{
			entity = context.CategoryExtraMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CategoryExtraMapping> UpdateAsync(CategoryExtraMapping entity)
		{
			entity = context.CategoryExtraMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
