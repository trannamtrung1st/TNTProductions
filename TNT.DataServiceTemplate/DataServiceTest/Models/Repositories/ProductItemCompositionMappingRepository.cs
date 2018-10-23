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
	public partial interface IProductItemCompositionMappingRepository : IBaseRepository<ProductItemCompositionMapping, ProductItemCompositionMappingPK>
	{
	}
	
	public partial class ProductItemCompositionMappingRepository : BaseRepository<ProductItemCompositionMapping, ProductItemCompositionMappingPK>, IProductItemCompositionMappingRepository
	{
		public ProductItemCompositionMappingRepository() : base()
		{
		}
		
		public ProductItemCompositionMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override ProductItemCompositionMapping Add(ProductItemCompositionMapping entity)
		{
			
			entity = context.ProductItemCompositionMappings.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ProductItemCompositionMapping> AddAsync(ProductItemCompositionMapping entity)
		{
			
			entity = context.ProductItemCompositionMappings.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override ProductItemCompositionMapping Delete(ProductItemCompositionMapping entity)
		{
			context.ProductItemCompositionMappings.Attach(entity);
			entity = context.ProductItemCompositionMappings.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ProductItemCompositionMapping> DeleteAsync(ProductItemCompositionMapping entity)
		{
			context.ProductItemCompositionMappings.Attach(entity);
			entity = context.ProductItemCompositionMappings.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override ProductItemCompositionMapping Delete(ProductItemCompositionMappingPK key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.ProductItemCompositionMappings.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ProductItemCompositionMapping> DeleteAsync(ProductItemCompositionMappingPK key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.ProductItemCompositionMappings.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override ProductItemCompositionMapping FindById(ProductItemCompositionMappingPK key)
		{
			var entity = context.ProductItemCompositionMappings.FirstOrDefault(
				e => e.ProducID == key.ProducID && e.ItemID == key.ItemID);
			return entity;
		}
		
		public override ProductItemCompositionMapping FindActiveById(ProductItemCompositionMappingPK key)
		{
			var entity = context.ProductItemCompositionMappings.FirstOrDefault(
				e => e.ProducID == key.ProducID && e.ItemID == key.ItemID);
			return entity;
		}
		
		public override async Task<ProductItemCompositionMapping> FindByIdAsync(ProductItemCompositionMappingPK key)
		{
			var entity = await context.ProductItemCompositionMappings.FirstOrDefaultAsync(
				e => e.ProducID == key.ProducID && e.ItemID == key.ItemID);
			return entity;
		}
		
		public override async Task<ProductItemCompositionMapping> FindActiveByIdAsync(ProductItemCompositionMappingPK key)
		{
			var entity = await context.ProductItemCompositionMappings.FirstOrDefaultAsync(
				e => e.ProducID == key.ProducID && e.ItemID == key.ItemID);
			return entity;
		}
		
		public override ProductItemCompositionMapping FindByIdInclude<TProperty>(ProductItemCompositionMappingPK key, params Expression<Func<ProductItemCompositionMapping, TProperty>>[] members)
		{
			IQueryable<ProductItemCompositionMapping> dbSet = context.ProductItemCompositionMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ProducID == key.ProducID && e.ItemID == key.ItemID);
		}
		
		public override async Task<ProductItemCompositionMapping> FindByIdIncludeAsync<TProperty>(ProductItemCompositionMappingPK key, params Expression<Func<ProductItemCompositionMapping, TProperty>>[] members)
		{
			IQueryable<ProductItemCompositionMapping> dbSet = context.ProductItemCompositionMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ProducID == key.ProducID && e.ItemID == key.ItemID);
		}
		
		public override ProductItemCompositionMapping Activate(ProductItemCompositionMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override ProductItemCompositionMapping Activate(ProductItemCompositionMappingPK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override ProductItemCompositionMapping Deactivate(ProductItemCompositionMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override ProductItemCompositionMapping Deactivate(ProductItemCompositionMappingPK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<ProductItemCompositionMapping> GetActive()
		{
			return context.ProductItemCompositionMappings;
		}
		
		public override IQueryable<ProductItemCompositionMapping> GetActive(Expression<Func<ProductItemCompositionMapping, bool>> expr)
		{
			return context.ProductItemCompositionMappings.Where(expr);
		}
		
		public override ProductItemCompositionMapping FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override ProductItemCompositionMapping FirstOrDefault(Expression<Func<ProductItemCompositionMapping, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<ProductItemCompositionMapping> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<ProductItemCompositionMapping> FirstOrDefaultAsync(Expression<Func<ProductItemCompositionMapping, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override ProductItemCompositionMapping SingleOrDefault(Expression<Func<ProductItemCompositionMapping, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<ProductItemCompositionMapping> SingleOrDefaultAsync(Expression<Func<ProductItemCompositionMapping, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override ProductItemCompositionMapping Update(ProductItemCompositionMapping entity)
		{
			entity = context.ProductItemCompositionMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ProductItemCompositionMapping> UpdateAsync(ProductItemCompositionMapping entity)
		{
			entity = context.ProductItemCompositionMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
