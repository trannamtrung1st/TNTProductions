using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Promoter.DataService.Models;
using Promoter.DataService.Managers;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Promoter.DataService.Models.Repositories
{
	public partial interface IMembershipRepository : IBaseRepository<Membership, int>
	{
	}
	
	public partial class MembershipRepository : BaseRepository<Membership, int>, IMembershipRepository
	{
		public MembershipRepository(PromoterEntities context) : base(context)
		{
		}
		
		public MembershipRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Membership Add(Membership entity)
		{
			
			entity = context.Memberships.Add(entity);
			return entity;
		}
		
		public override Membership Remove(Membership entity)
		{
			context.Memberships.Attach(entity);
			entity = context.Memberships.Remove(entity);
			return entity;
		}
		
		public override Membership Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Memberships.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<Membership> RemoveIf(Expression<Func<Membership, bool>> expr)
		{
			return context.Memberships.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<Membership> RemoveRange(IEnumerable<Membership> list)
		{
			return context.Memberships.RemoveRange(list);
		}
		
		public override Membership FindById(int key)
		{
			var entity = context.Memberships.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override Membership FindActiveById(int key)
		{
			var entity = context.Memberships.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Membership> FindByIdAsync(int key)
		{
			var entity = await context.Memberships.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Membership> FindActiveByIdAsync(int key)
		{
			var entity = await context.Memberships.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override Membership FindByIdInclude<TProperty>(int key, params Expression<Func<Membership, TProperty>>[] members)
		{
			IQueryable<Membership> dbSet = context.Memberships;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<Membership> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Membership, TProperty>>[] members)
		{
			IQueryable<Membership> dbSet = context.Memberships;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override Membership Activate(Membership entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Membership Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Membership Deactivate(Membership entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Membership Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Membership> GetActive()
		{
			return context.Memberships;
		}
		
		public override IQueryable<Membership> GetActive(Expression<Func<Membership, bool>> expr)
		{
			return context.Memberships.Where(expr);
		}
		
		public override Membership FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Membership FirstOrDefault(Expression<Func<Membership, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Membership> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Membership> FirstOrDefaultAsync(Expression<Func<Membership, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Membership SingleOrDefault(Expression<Func<Membership, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Membership> SingleOrDefaultAsync(Expression<Func<Membership, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Membership Update(Membership entity)
		{
			entity = context.Memberships.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
