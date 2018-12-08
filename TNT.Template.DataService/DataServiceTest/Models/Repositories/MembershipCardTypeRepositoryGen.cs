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
	public partial interface IMembershipCardTypeRepository : IBaseRepository<MembershipCardType, int>
	{
	}
	
	public partial class MembershipCardTypeRepository : BaseRepository<MembershipCardType, int>, IMembershipCardTypeRepository
	{
		public MembershipCardTypeRepository(DbContext context) : base(context)
		{
		}
		
		public MembershipCardTypeRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override MembershipCardType FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override MembershipCardType FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<MembershipCardType> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<MembershipCardType> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override MembershipCardType Activate(MembershipCardType entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override MembershipCardType Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override MembershipCardType Deactivate(MembershipCardType entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override MembershipCardType Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<MembershipCardType> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<MembershipCardType> GetActive(Expression<Func<MembershipCardType, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
