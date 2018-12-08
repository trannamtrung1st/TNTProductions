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
		public CustomerStoreReportMappingRepository(DbContext context) : base(context)
		{
		}
		
		public CustomerStoreReportMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override CustomerStoreReportMapping FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override CustomerStoreReportMapping FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<CustomerStoreReportMapping> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<CustomerStoreReportMapping> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
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
			return dbSet;
		}
		
		public override IQueryable<CustomerStoreReportMapping> GetActive(Expression<Func<CustomerStoreReportMapping, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
