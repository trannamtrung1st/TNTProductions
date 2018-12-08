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
	public partial interface IMembershipCardRepository : IBaseRepository<MembershipCard, int>
	{
	}
	
	public partial class MembershipCardRepository : BaseRepository<MembershipCard, int>, IMembershipCardRepository
	{
		public MembershipCardRepository(DbContext context) : base(context)
		{
		}
		
		public MembershipCardRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override MembershipCard FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override MembershipCard FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<MembershipCard> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<MembershipCard> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override MembershipCard Activate(MembershipCard entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override MembershipCard Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override MembershipCard Deactivate(MembershipCard entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override MembershipCard Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<MembershipCard> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<MembershipCard> GetActive(Expression<Func<MembershipCard, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
