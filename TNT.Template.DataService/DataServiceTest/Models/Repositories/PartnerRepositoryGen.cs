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
	public partial interface IPartnerRepository : IBaseRepository<Partner, int>
	{
	}
	
	public partial class PartnerRepository : BaseRepository<Partner, int>, IPartnerRepository
	{
		public PartnerRepository(DbContext context) : base(context)
		{
		}
		
		public PartnerRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Partner FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override Partner FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<Partner> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<Partner> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override Partner Activate(Partner entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Partner Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Partner Deactivate(Partner entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Partner Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Partner> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<Partner> GetActive(Expression<Func<Partner, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
