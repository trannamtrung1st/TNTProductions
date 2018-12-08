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
	public partial interface IProviderRepository : IBaseRepository<Provider, int>
	{
	}
	
	public partial class ProviderRepository : BaseRepository<Provider, int>, IProviderRepository
	{
		public ProviderRepository(DbContext context) : base(context)
		{
		}
		
		public ProviderRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Provider FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override Provider FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Provider> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Provider> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override Provider Activate(Provider entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Provider Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Provider Deactivate(Provider entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Provider Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Provider> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<Provider> GetActive(Expression<Func<Provider, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
