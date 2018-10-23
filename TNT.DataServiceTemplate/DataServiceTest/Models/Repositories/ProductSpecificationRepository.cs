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
	public partial interface IProductSpecificationRepository : IBaseRepository<ProductSpecification, int>
	{
	}
	
	public partial class ProductSpecificationRepository : BaseRepository<ProductSpecification, int>, IProductSpecificationRepository
	{
		public ProductSpecificationRepository() : base()
		{
		}
		
		public ProductSpecificationRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override ProductSpecification Add(ProductSpecification entity)
		{
			entity.Active = true;
			entity = context.ProductSpecifications.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ProductSpecification> AddAsync(ProductSpecification entity)
		{
			entity.Active = true;
			entity = context.ProductSpecifications.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override ProductSpecification Delete(ProductSpecification entity)
		{
			context.ProductSpecifications.Attach(entity);
			entity = context.ProductSpecifications.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ProductSpecification> DeleteAsync(ProductSpecification entity)
		{
			context.ProductSpecifications.Attach(entity);
			entity = context.ProductSpecifications.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override ProductSpecification Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.ProductSpecifications.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ProductSpecification> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.ProductSpecifications.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override ProductSpecification FindById(int key)
		{
			var entity = context.ProductSpecifications.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override ProductSpecification FindActiveById(int key)
		{
			var entity = context.ProductSpecifications.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<ProductSpecification> FindByIdAsync(int key)
		{
			var entity = await context.ProductSpecifications.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<ProductSpecification> FindActiveByIdAsync(int key)
		{
			var entity = await context.ProductSpecifications.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override ProductSpecification FindByIdInclude<TProperty>(int key, params Expression<Func<ProductSpecification, TProperty>>[] members)
		{
			IQueryable<ProductSpecification> dbSet = context.ProductSpecifications;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<ProductSpecification> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<ProductSpecification, TProperty>>[] members)
		{
			IQueryable<ProductSpecification> dbSet = context.ProductSpecifications;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override ProductSpecification Activate(ProductSpecification entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override ProductSpecification Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override ProductSpecification Deactivate(ProductSpecification entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override ProductSpecification Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<ProductSpecification> GetActive()
		{
			return context.ProductSpecifications.Where(e => e.Active);
		}
		
		public override IQueryable<ProductSpecification> GetActive(Expression<Func<ProductSpecification, bool>> expr)
		{
			return context.ProductSpecifications.Where(e => e.Active).Where(expr);
		}
		
		public override ProductSpecification FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override ProductSpecification FirstOrDefault(Expression<Func<ProductSpecification, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<ProductSpecification> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<ProductSpecification> FirstOrDefaultAsync(Expression<Func<ProductSpecification, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override ProductSpecification SingleOrDefault(Expression<Func<ProductSpecification, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<ProductSpecification> SingleOrDefaultAsync(Expression<Func<ProductSpecification, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override ProductSpecification Update(ProductSpecification entity)
		{
			entity = context.ProductSpecifications.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ProductSpecification> UpdateAsync(ProductSpecification entity)
		{
			entity = context.ProductSpecifications.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
