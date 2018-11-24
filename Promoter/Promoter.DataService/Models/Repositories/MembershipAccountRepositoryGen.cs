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
	public partial interface IMembershipAccountRepository : IBaseRepository<MembershipAccount, int>
	{
	}
	
	public partial class MembershipAccountRepository : BaseRepository<MembershipAccount, int>, IMembershipAccountRepository
	{
		public MembershipAccountRepository(PromoterEntities context) : base(context)
		{
		}
		
		public MembershipAccountRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override MembershipAccount Add(MembershipAccount entity)
		{
			
			entity = context.MembershipAccounts.Add(entity);
			return entity;
		}
		
		public override MembershipAccount Remove(MembershipAccount entity)
		{
			context.MembershipAccounts.Attach(entity);
			entity = context.MembershipAccounts.Remove(entity);
			return entity;
		}
		
		public override MembershipAccount Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.MembershipAccounts.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<MembershipAccount> RemoveIf(Expression<Func<MembershipAccount, bool>> expr)
		{
			return context.MembershipAccounts.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<MembershipAccount> RemoveRange(IEnumerable<MembershipAccount> list)
		{
			return context.MembershipAccounts.RemoveRange(list);
		}
		
		public override MembershipAccount FindById(int key)
		{
			var entity = context.MembershipAccounts.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override MembershipAccount FindActiveById(int key)
		{
			var entity = context.MembershipAccounts.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<MembershipAccount> FindByIdAsync(int key)
		{
			var entity = await context.MembershipAccounts.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<MembershipAccount> FindActiveByIdAsync(int key)
		{
			var entity = await context.MembershipAccounts.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override MembershipAccount FindByIdInclude<TProperty>(int key, params Expression<Func<MembershipAccount, TProperty>>[] members)
		{
			IQueryable<MembershipAccount> dbSet = context.MembershipAccounts;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<MembershipAccount> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<MembershipAccount, TProperty>>[] members)
		{
			IQueryable<MembershipAccount> dbSet = context.MembershipAccounts;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override MembershipAccount Activate(MembershipAccount entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override MembershipAccount Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override MembershipAccount Deactivate(MembershipAccount entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override MembershipAccount Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<MembershipAccount> GetActive()
		{
			return context.MembershipAccounts;
		}
		
		public override IQueryable<MembershipAccount> GetActive(Expression<Func<MembershipAccount, bool>> expr)
		{
			return context.MembershipAccounts.Where(expr);
		}
		
		public override MembershipAccount FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override MembershipAccount FirstOrDefault(Expression<Func<MembershipAccount, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<MembershipAccount> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<MembershipAccount> FirstOrDefaultAsync(Expression<Func<MembershipAccount, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override MembershipAccount SingleOrDefault(Expression<Func<MembershipAccount, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<MembershipAccount> SingleOrDefaultAsync(Expression<Func<MembershipAccount, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override MembershipAccount Update(MembershipAccount entity)
		{
			entity = context.MembershipAccounts.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
