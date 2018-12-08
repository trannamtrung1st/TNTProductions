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
	public partial interface ISystemPartnerMappingRepository : IBaseRepository<SystemPartnerMapping, int>
	{
	}
	
	public partial class SystemPartnerMappingRepository : BaseRepository<SystemPartnerMapping, int>, ISystemPartnerMappingRepository
	{
		public SystemPartnerMappingRepository(DbContext context) : base(context)
		{
		}
		
		public SystemPartnerMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override SystemPartnerMapping FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override SystemPartnerMapping FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<SystemPartnerMapping> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<SystemPartnerMapping> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override SystemPartnerMapping Activate(SystemPartnerMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override SystemPartnerMapping Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override SystemPartnerMapping Deactivate(SystemPartnerMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override SystemPartnerMapping Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<SystemPartnerMapping> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<SystemPartnerMapping> GetActive(Expression<Func<SystemPartnerMapping, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
