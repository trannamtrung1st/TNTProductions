using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Promoter.DataService.Models;
using Promoter.DataService.Managers;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Promoter.DataService.Models.Repositories
{
	public partial interface ICustomerRepository : IBaseRepository<Customer, int>
	{
	}
	
	public partial class CustomerRepository : BaseRepository<Customer, int>, ICustomerRepository
	{
		public CustomerRepository(PromoterEntities context) : base(context)
		{
		}
		
		public CustomerRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Customer Add(Customer entity)
		{
			
			entity = context.Customers.Add(entity);
			return entity;
		}
		
		public override Customer Remove(Customer entity)
		{
			context.Customers.Attach(entity);
			entity = context.Customers.Remove(entity);
			return entity;
		}
		
		public override Customer Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Customers.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<Customer> RemoveIf(Expression<Func<Customer, bool>> expr)
		{
			return context.Customers.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<Customer> RemoveRange(IEnumerable<Customer> list)
		{
			return context.Customers.RemoveRange(list);
		}
		
		public override Customer FindById(int key)
		{
			var entity = context.Customers.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override Customer FindActiveById(int key)
		{
			var entity = context.Customers.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Customer> FindByIdAsync(int key)
		{
			var entity = await context.Customers.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Customer> FindActiveByIdAsync(int key)
		{
			var entity = await context.Customers.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override Customer FindByIdInclude<TProperty>(int key, params Expression<Func<Customer, TProperty>>[] members)
		{
			IQueryable<Customer> dbSet = context.Customers;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<Customer> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Customer, TProperty>>[] members)
		{
			IQueryable<Customer> dbSet = context.Customers;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override Customer Activate(Customer entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Customer Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Customer Deactivate(Customer entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Customer Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Customer> GetActive()
		{
			return context.Customers;
		}
		
		public override IQueryable<Customer> GetActive(Expression<Func<Customer, bool>> expr)
		{
			return context.Customers.Where(expr);
		}
		
		public override Customer FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Customer FirstOrDefault(Expression<Func<Customer, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Customer> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Customer> FirstOrDefaultAsync(Expression<Func<Customer, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Customer SingleOrDefault(Expression<Func<Customer, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Customer> SingleOrDefaultAsync(Expression<Func<Customer, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Customer Update(Customer entity)
		{
			entity = context.Customers.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
