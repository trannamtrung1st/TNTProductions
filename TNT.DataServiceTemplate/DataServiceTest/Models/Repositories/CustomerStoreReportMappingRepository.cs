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
	public partial interface ICustomerStoreReportMappingRepository : IBaseRepository<CustomerStoreReportMapping, int>
	{
	}
	
	public partial class CustomerStoreReportMappingRepository : BaseRepository<CustomerStoreReportMapping, int>, ICustomerStoreReportMappingRepository
	{
		public CustomerStoreReportMappingRepository() : base()
		{
		}
		
		public CustomerStoreReportMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override CustomerStoreReportMapping Add(CustomerStoreReportMapping entity)
		{
			
			entity = context.CustomerStoreReportMappings.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CustomerStoreReportMapping> AddAsync(CustomerStoreReportMapping entity)
		{
			
			entity = context.CustomerStoreReportMappings.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override CustomerStoreReportMapping Delete(CustomerStoreReportMapping entity)
		{
			context.CustomerStoreReportMappings.Attach(entity);
			entity = context.CustomerStoreReportMappings.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CustomerStoreReportMapping> DeleteAsync(CustomerStoreReportMapping entity)
		{
			context.CustomerStoreReportMappings.Attach(entity);
			entity = context.CustomerStoreReportMappings.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override CustomerStoreReportMapping Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.CustomerStoreReportMappings.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CustomerStoreReportMapping> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.CustomerStoreReportMappings.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override CustomerStoreReportMapping FindById(int key)
		{
			var entity = context.CustomerStoreReportMappings.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override CustomerStoreReportMapping FindActiveById(int key)
		{
			var entity = context.CustomerStoreReportMappings.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<CustomerStoreReportMapping> FindByIdAsync(int key)
		{
			var entity = await context.CustomerStoreReportMappings.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<CustomerStoreReportMapping> FindActiveByIdAsync(int key)
		{
			var entity = await context.CustomerStoreReportMappings.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override CustomerStoreReportMapping FindByIdInclude<TProperty>(int key, params Expression<Func<CustomerStoreReportMapping, TProperty>>[] members)
		{
			IQueryable<CustomerStoreReportMapping> dbSet = context.CustomerStoreReportMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ID == key);
		}
		
		public override async Task<CustomerStoreReportMapping> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<CustomerStoreReportMapping, TProperty>>[] members)
		{
			IQueryable<CustomerStoreReportMapping> dbSet = context.CustomerStoreReportMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
		}
		
		public override CustomerStoreReportMapping Activate(CustomerStoreReportMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CustomerStoreReportMapping Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CustomerStoreReportMapping Deactivate(CustomerStoreReportMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CustomerStoreReportMapping Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<CustomerStoreReportMapping> GetActive()
		{
			return context.CustomerStoreReportMappings;
		}
		
		public override IQueryable<CustomerStoreReportMapping> GetActive(Expression<Func<CustomerStoreReportMapping, bool>> expr)
		{
			return context.CustomerStoreReportMappings.Where(expr);
		}
		
		public override CustomerStoreReportMapping FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override CustomerStoreReportMapping FirstOrDefault(Expression<Func<CustomerStoreReportMapping, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<CustomerStoreReportMapping> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<CustomerStoreReportMapping> FirstOrDefaultAsync(Expression<Func<CustomerStoreReportMapping, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override CustomerStoreReportMapping SingleOrDefault(Expression<Func<CustomerStoreReportMapping, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<CustomerStoreReportMapping> SingleOrDefaultAsync(Expression<Func<CustomerStoreReportMapping, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override CustomerStoreReportMapping Update(CustomerStoreReportMapping entity)
		{
			entity = context.CustomerStoreReportMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CustomerStoreReportMapping> UpdateAsync(CustomerStoreReportMapping entity)
		{
			entity = context.CustomerStoreReportMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
