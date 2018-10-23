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
	public partial interface ICustomerTypeRepository : IBaseRepository<CustomerType, int>
	{
	}
	
	public partial class CustomerTypeRepository : BaseRepository<CustomerType, int>, ICustomerTypeRepository
	{
		public CustomerTypeRepository() : base()
		{
		}
		
		public CustomerTypeRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override CustomerType Add(CustomerType entity)
		{
			
			entity = context.CustomerTypes.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CustomerType> AddAsync(CustomerType entity)
		{
			
			entity = context.CustomerTypes.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override CustomerType Delete(CustomerType entity)
		{
			context.CustomerTypes.Attach(entity);
			entity = context.CustomerTypes.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CustomerType> DeleteAsync(CustomerType entity)
		{
			context.CustomerTypes.Attach(entity);
			entity = context.CustomerTypes.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override CustomerType Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.CustomerTypes.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CustomerType> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.CustomerTypes.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override CustomerType FindById(int key)
		{
			var entity = context.CustomerTypes.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override CustomerType FindActiveById(int key)
		{
			var entity = context.CustomerTypes.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<CustomerType> FindByIdAsync(int key)
		{
			var entity = await context.CustomerTypes.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<CustomerType> FindActiveByIdAsync(int key)
		{
			var entity = await context.CustomerTypes.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override CustomerType FindByIdInclude<TProperty>(int key, params Expression<Func<CustomerType, TProperty>>[] members)
		{
			IQueryable<CustomerType> dbSet = context.CustomerTypes;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ID == key);
		}
		
		public override async Task<CustomerType> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<CustomerType, TProperty>>[] members)
		{
			IQueryable<CustomerType> dbSet = context.CustomerTypes;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
		}
		
		public override CustomerType Activate(CustomerType entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CustomerType Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CustomerType Deactivate(CustomerType entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CustomerType Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<CustomerType> GetActive()
		{
			return context.CustomerTypes;
		}
		
		public override IQueryable<CustomerType> GetActive(Expression<Func<CustomerType, bool>> expr)
		{
			return context.CustomerTypes.Where(expr);
		}
		
		public override CustomerType FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override CustomerType FirstOrDefault(Expression<Func<CustomerType, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<CustomerType> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<CustomerType> FirstOrDefaultAsync(Expression<Func<CustomerType, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override CustomerType SingleOrDefault(Expression<Func<CustomerType, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<CustomerType> SingleOrDefaultAsync(Expression<Func<CustomerType, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override CustomerType Update(CustomerType entity)
		{
			entity = context.CustomerTypes.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CustomerType> UpdateAsync(CustomerType entity)
		{
			entity = context.CustomerTypes.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
