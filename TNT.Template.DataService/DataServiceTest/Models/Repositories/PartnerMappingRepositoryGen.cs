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
	public partial interface IPartnerMappingRepository : IBaseRepository<PartnerMapping, int>
	{
	}
	
	public partial class PartnerMappingRepository : BaseRepository<PartnerMapping, int>, IPartnerMappingRepository
	{
		public PartnerMappingRepository(DbContext context) : base(context)
		{
		}
		
		public PartnerMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PartnerMapping FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override PartnerMapping FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<PartnerMapping> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<PartnerMapping> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override PartnerMapping Activate(PartnerMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PartnerMapping Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PartnerMapping Deactivate(PartnerMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PartnerMapping Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<PartnerMapping> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<PartnerMapping> GetActive(Expression<Func<PartnerMapping, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
