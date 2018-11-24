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
	public partial interface IBrandAccountRepository : IBaseRepository<BrandAccount, int>
	{
	}
	
	public partial class BrandAccountRepository : BaseRepository<BrandAccount, int>, IBrandAccountRepository
	{
		public BrandAccountRepository(PromoterEntities context) : base(context)
		{
		}
		
		public BrandAccountRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override BrandAccount Add(BrandAccount entity)
		{
			
			entity = context.BrandAccounts.Add(entity);
			return entity;
		}
		
		public override BrandAccount Remove(BrandAccount entity)
		{
			context.BrandAccounts.Attach(entity);
			entity = context.BrandAccounts.Remove(entity);
			return entity;
		}
		
		public override BrandAccount Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.BrandAccounts.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<BrandAccount> RemoveIf(Expression<Func<BrandAccount, bool>> expr)
		{
			return context.BrandAccounts.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<BrandAccount> RemoveRange(IEnumerable<BrandAccount> list)
		{
			return context.BrandAccounts.RemoveRange(list);
		}
		
		public override BrandAccount FindById(int key)
		{
			var entity = context.BrandAccounts.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override BrandAccount FindActiveById(int key)
		{
			var entity = context.BrandAccounts.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<BrandAccount> FindByIdAsync(int key)
		{
			var entity = await context.BrandAccounts.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<BrandAccount> FindActiveByIdAsync(int key)
		{
			var entity = await context.BrandAccounts.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override BrandAccount FindByIdInclude<TProperty>(int key, params Expression<Func<BrandAccount, TProperty>>[] members)
		{
			IQueryable<BrandAccount> dbSet = context.BrandAccounts;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<BrandAccount> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<BrandAccount, TProperty>>[] members)
		{
			IQueryable<BrandAccount> dbSet = context.BrandAccounts;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override BrandAccount Activate(BrandAccount entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override BrandAccount Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override BrandAccount Deactivate(BrandAccount entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override BrandAccount Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<BrandAccount> GetActive()
		{
			return context.BrandAccounts;
		}
		
		public override IQueryable<BrandAccount> GetActive(Expression<Func<BrandAccount, bool>> expr)
		{
			return context.BrandAccounts.Where(expr);
		}
		
		public override BrandAccount FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override BrandAccount FirstOrDefault(Expression<Func<BrandAccount, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<BrandAccount> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<BrandAccount> FirstOrDefaultAsync(Expression<Func<BrandAccount, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override BrandAccount SingleOrDefault(Expression<Func<BrandAccount, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<BrandAccount> SingleOrDefaultAsync(Expression<Func<BrandAccount, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override BrandAccount Update(BrandAccount entity)
		{
			entity = context.BrandAccounts.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
