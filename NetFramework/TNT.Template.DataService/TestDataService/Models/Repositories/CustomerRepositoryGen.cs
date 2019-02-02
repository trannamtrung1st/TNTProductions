using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.Models;
using TNT.IoC.Attributes;
using System.Linq.Expressions;
using System.Data.Entity;

namespace TestDataService.Models.Repositories
{
	public partial interface ICustomerRepository : IBaseRepository<Customer, int>
	{
	}
	
	public partial class CustomerRepository : BaseRepository<Customer, int>, ICustomerRepository
	{
		public CustomerRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		public CustomerRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override Customer FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<Customer> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		#endregion
	}
}
