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
	public partial interface IApplicationRepository : IBaseRepository<Application, System.Guid>
	{
	}
	
	public partial class ApplicationRepository : BaseRepository<Application, System.Guid>, IApplicationRepository
	{
		public ApplicationRepository(DbContext context) : base(context)
		{
		}
		
		public ApplicationRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Application FindById(System.Guid key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ApplicationId == key);
			return entity;
		}
		
		public override Application FindActiveById(System.Guid key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ApplicationId == key);
			return entity;
		}
		
		public override async Task<Application> FindByIdAsync(System.Guid key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ApplicationId == key);
			return entity;
		}
		
		public override async Task<Application> FindActiveByIdAsync(System.Guid key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ApplicationId == key);
			return entity;
		}
		
		public override Application Activate(Application entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Application Activate(System.Guid key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Application Deactivate(Application entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Application Deactivate(System.Guid key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Application> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<Application> GetActive(Expression<Func<Application, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
