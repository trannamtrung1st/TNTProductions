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
	public partial interface ICustomerFilterRepository : IBaseRepository<CustomerFilter, int>
	{
	}
	
	public partial class CustomerFilterRepository : BaseRepository<CustomerFilter, int>, ICustomerFilterRepository
	{
		public CustomerFilterRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		public CustomerFilterRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override CustomerFilter FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<CustomerFilter> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		#endregion
	}
}
