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
	public partial interface ICustomerProductMappingRepository : IBaseRepository<CustomerProductMapping, int>
	{
	}
	
	public partial class CustomerProductMappingRepository : BaseRepository<CustomerProductMapping, int>, ICustomerProductMappingRepository
	{
		public CustomerProductMappingRepository() : base()
		{
		}
		
		public CustomerProductMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override CustomerProductMapping Add(CustomerProductMapping entity)
		{
			
			entity = context.CustomerProductMappings.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CustomerProductMapping> AddAsync(CustomerProductMapping entity)
		{
			
			entity = context.CustomerProductMappings.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override CustomerProductMapping Delete(CustomerProductMapping entity)
		{
			context.CustomerProductMappings.Attach(entity);
			entity = context.CustomerProductMappings.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CustomerProductMapping> DeleteAsync(CustomerProductMapping entity)
		{
			context.CustomerProductMappings.Attach(entity);
			entity = context.CustomerProductMappings.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override CustomerProductMapping Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.CustomerProductMappings.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CustomerProductMapping> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.CustomerProductMappings.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override CustomerProductMapping FindById(int key)
		{
			var entity = context.CustomerProductMappings.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override CustomerProductMapping FindActiveById(int key)
		{
			var entity = context.CustomerProductMappings.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<CustomerProductMapping> FindByIdAsync(int key)
		{
			var entity = await context.CustomerProductMappings.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<CustomerProductMapping> FindActiveByIdAsync(int key)
		{
			var entity = await context.CustomerProductMappings.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override CustomerProductMapping FindByIdInclude<TProperty>(int key, params Expression<Func<CustomerProductMapping, TProperty>>[] members)
		{
			IQueryable<CustomerProductMapping> dbSet = context.CustomerProductMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ID == key);
		}
		
		public override async Task<CustomerProductMapping> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<CustomerProductMapping, TProperty>>[] members)
		{
			IQueryable<CustomerProductMapping> dbSet = context.CustomerProductMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
		}
		
		public override CustomerProductMapping Activate(CustomerProductMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CustomerProductMapping Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CustomerProductMapping Deactivate(CustomerProductMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CustomerProductMapping Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<CustomerProductMapping> GetActive()
		{
			return context.CustomerProductMappings;
		}
		
		public override IQueryable<CustomerProductMapping> GetActive(Expression<Func<CustomerProductMapping, bool>> expr)
		{
			return context.CustomerProductMappings.Where(expr);
		}
		
		public override CustomerProductMapping FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override CustomerProductMapping FirstOrDefault(Expression<Func<CustomerProductMapping, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<CustomerProductMapping> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<CustomerProductMapping> FirstOrDefaultAsync(Expression<Func<CustomerProductMapping, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override CustomerProductMapping SingleOrDefault(Expression<Func<CustomerProductMapping, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<CustomerProductMapping> SingleOrDefaultAsync(Expression<Func<CustomerProductMapping, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override CustomerProductMapping Update(CustomerProductMapping entity)
		{
			entity = context.CustomerProductMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CustomerProductMapping> UpdateAsync(CustomerProductMapping entity)
		{
			entity = context.CustomerProductMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
