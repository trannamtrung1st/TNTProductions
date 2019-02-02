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
	public partial interface ICustomerEventRepository : IBaseRepository<CustomerEvent, int>
	{
	}
	
	public partial class CustomerEventRepository : BaseRepository<CustomerEvent, int>, ICustomerEventRepository
	{
		public CustomerEventRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		public CustomerEventRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override CustomerEvent FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<CustomerEvent> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		#endregion
	}
}
