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
	public partial interface IAspNetUserClaimRepository : IBaseRepository<AspNetUserClaim, int>
	{
	}
	
	public partial class AspNetUserClaimRepository : BaseRepository<AspNetUserClaim, int>, IAspNetUserClaimRepository
	{
		public AspNetUserClaimRepository() : base()
		{
		}
		
		public AspNetUserClaimRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override AspNetUserClaim Add(AspNetUserClaim entity)
		{
			
			entity = context.AspNetUserClaims.Add(entity);
			return entity;
		}
		
		public override AspNetUserClaim Remove(AspNetUserClaim entity)
		{
			context.AspNetUserClaims.Attach(entity);
			entity = context.AspNetUserClaims.Remove(entity);
			return entity;
		}
		
		public override AspNetUserClaim Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.AspNetUserClaims.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<AspNetUserClaim> RemoveIf(Expression<Func<AspNetUserClaim, bool>> expr)
		{
			return context.AspNetUserClaims.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<AspNetUserClaim> RemoveRange(IEnumerable<AspNetUserClaim> list)
		{
			return context.AspNetUserClaims.RemoveRange(list);
		}
		
		public override AspNetUserClaim FindById(int key)
		{
			var entity = context.AspNetUserClaims.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override AspNetUserClaim FindActiveById(int key)
		{
			var entity = context.AspNetUserClaims.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<AspNetUserClaim> FindByIdAsync(int key)
		{
			var entity = await context.AspNetUserClaims.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<AspNetUserClaim> FindActiveByIdAsync(int key)
		{
			var entity = await context.AspNetUserClaims.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override AspNetUserClaim FindByIdInclude<TProperty>(int key, params Expression<Func<AspNetUserClaim, TProperty>>[] members)
		{
			IQueryable<AspNetUserClaim> dbSet = context.AspNetUserClaims;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<AspNetUserClaim> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<AspNetUserClaim, TProperty>>[] members)
		{
			IQueryable<AspNetUserClaim> dbSet = context.AspNetUserClaims;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override AspNetUserClaim Activate(AspNetUserClaim entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override AspNetUserClaim Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override AspNetUserClaim Deactivate(AspNetUserClaim entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override AspNetUserClaim Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<AspNetUserClaim> GetActive()
		{
			return context.AspNetUserClaims;
		}
		
		public override IQueryable<AspNetUserClaim> GetActive(Expression<Func<AspNetUserClaim, bool>> expr)
		{
			return context.AspNetUserClaims.Where(expr);
		}
		
		public override AspNetUserClaim FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override AspNetUserClaim FirstOrDefault(Expression<Func<AspNetUserClaim, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<AspNetUserClaim> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<AspNetUserClaim> FirstOrDefaultAsync(Expression<Func<AspNetUserClaim, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override AspNetUserClaim SingleOrDefault(Expression<Func<AspNetUserClaim, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<AspNetUserClaim> SingleOrDefaultAsync(Expression<Func<AspNetUserClaim, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override AspNetUserClaim Update(AspNetUserClaim entity)
		{
			entity = context.AspNetUserClaims.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
