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
	public partial interface ICustomerRepository : IBaseRepository<Customer, int>
	{
	}
	
	public partial class CustomerRepository : BaseRepository<Customer, int>, ICustomerRepository
	{
		public CustomerRepository(DbContext context) : base(context)
		{
		}
		
		public CustomerRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Customer FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.CustomerID == key);
			return entity;
		}
		
		public override Customer FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.CustomerID == key);
			return entity;
		}
		
		public override async Task<Customer> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.CustomerID == key);
			return entity;
		}
		
		public override async Task<Customer> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.CustomerID == key);
			return entity;
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
			return dbSet;
		}
		
		public override IQueryable<Customer> GetActive(Expression<Func<Customer, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
