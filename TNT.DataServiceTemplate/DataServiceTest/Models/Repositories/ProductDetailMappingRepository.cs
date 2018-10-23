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
	public partial interface IProductDetailMappingRepository : IBaseRepository<ProductDetailMapping, int>
	{
	}
	
	public partial class ProductDetailMappingRepository : BaseRepository<ProductDetailMapping, int>, IProductDetailMappingRepository
	{
		public ProductDetailMappingRepository() : base()
		{
		}
		
		public ProductDetailMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override ProductDetailMapping Add(ProductDetailMapping entity)
		{
			
			entity = context.ProductDetailMappings.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ProductDetailMapping> AddAsync(ProductDetailMapping entity)
		{
			
			entity = context.ProductDetailMappings.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override ProductDetailMapping Delete(ProductDetailMapping entity)
		{
			context.ProductDetailMappings.Attach(entity);
			entity = context.ProductDetailMappings.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ProductDetailMapping> DeleteAsync(ProductDetailMapping entity)
		{
			context.ProductDetailMappings.Attach(entity);
			entity = context.ProductDetailMappings.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override ProductDetailMapping Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.ProductDetailMappings.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ProductDetailMapping> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.ProductDetailMappings.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override ProductDetailMapping FindById(int key)
		{
			var entity = context.ProductDetailMappings.FirstOrDefault(
				e => e.ProductDetailID == key);
			return entity;
		}
		
		public override ProductDetailMapping FindActiveById(int key)
		{
			var entity = context.ProductDetailMappings.FirstOrDefault(
				e => e.ProductDetailID == key);
			return entity;
		}
		
		public override async Task<ProductDetailMapping> FindByIdAsync(int key)
		{
			var entity = await context.ProductDetailMappings.FirstOrDefaultAsync(
				e => e.ProductDetailID == key);
			return entity;
		}
		
		public override async Task<ProductDetailMapping> FindActiveByIdAsync(int key)
		{
			var entity = await context.ProductDetailMappings.FirstOrDefaultAsync(
				e => e.ProductDetailID == key);
			return entity;
		}
		
		public override ProductDetailMapping FindByIdInclude<TProperty>(int key, params Expression<Func<ProductDetailMapping, TProperty>>[] members)
		{
			IQueryable<ProductDetailMapping> dbSet = context.ProductDetailMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ProductDetailID == key);
		}
		
		public override async Task<ProductDetailMapping> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<ProductDetailMapping, TProperty>>[] members)
		{
			IQueryable<ProductDetailMapping> dbSet = context.ProductDetailMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ProductDetailID == key);
		}
		
		public override ProductDetailMapping Activate(ProductDetailMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override ProductDetailMapping Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override ProductDetailMapping Deactivate(ProductDetailMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override ProductDetailMapping Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<ProductDetailMapping> GetActive()
		{
			return context.ProductDetailMappings;
		}
		
		public override IQueryable<ProductDetailMapping> GetActive(Expression<Func<ProductDetailMapping, bool>> expr)
		{
			return context.ProductDetailMappings.Where(expr);
		}
		
		public override ProductDetailMapping FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override ProductDetailMapping FirstOrDefault(Expression<Func<ProductDetailMapping, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<ProductDetailMapping> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<ProductDetailMapping> FirstOrDefaultAsync(Expression<Func<ProductDetailMapping, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override ProductDetailMapping SingleOrDefault(Expression<Func<ProductDetailMapping, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<ProductDetailMapping> SingleOrDefaultAsync(Expression<Func<ProductDetailMapping, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override ProductDetailMapping Update(ProductDetailMapping entity)
		{
			entity = context.ProductDetailMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ProductDetailMapping> UpdateAsync(ProductDetailMapping entity)
		{
			entity = context.ProductDetailMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
