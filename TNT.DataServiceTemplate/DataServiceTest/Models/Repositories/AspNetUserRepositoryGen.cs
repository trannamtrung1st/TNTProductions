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
	public partial interface IAspNetUserRepository : IBaseRepository<AspNetUser, string>
	{
	}
	
	public partial class AspNetUserRepository : BaseRepository<AspNetUser, string>, IAspNetUserRepository
	{
		public AspNetUserRepository() : base()
		{
		}
		
		public AspNetUserRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override AspNetUser Add(AspNetUser entity)
		{
			
			entity = context.AspNetUsers.Add(entity);
			return entity;
		}
		
		public override AspNetUser Remove(AspNetUser entity)
		{
			context.AspNetUsers.Attach(entity);
			entity = context.AspNetUsers.Remove(entity);
			return entity;
		}
		
		public override AspNetUser Remove(string key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.AspNetUsers.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<AspNetUser> RemoveIf(Expression<Func<AspNetUser, bool>> expr)
		{
			return context.AspNetUsers.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<AspNetUser> RemoveRange(IEnumerable<AspNetUser> list)
		{
			return context.AspNetUsers.RemoveRange(list);
		}
		
		public override AspNetUser FindById(string key)
		{
			var entity = context.AspNetUsers.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override AspNetUser FindActiveById(string key)
		{
			var entity = context.AspNetUsers.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<AspNetUser> FindByIdAsync(string key)
		{
			var entity = await context.AspNetUsers.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<AspNetUser> FindActiveByIdAsync(string key)
		{
			var entity = await context.AspNetUsers.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override AspNetUser FindByIdInclude<TProperty>(string key, params Expression<Func<AspNetUser, TProperty>>[] members)
		{
			IQueryable<AspNetUser> dbSet = context.AspNetUsers;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<AspNetUser> FindByIdIncludeAsync<TProperty>(string key, params Expression<Func<AspNetUser, TProperty>>[] members)
		{
			IQueryable<AspNetUser> dbSet = context.AspNetUsers;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override AspNetUser Activate(AspNetUser entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override AspNetUser Activate(string key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override AspNetUser Deactivate(AspNetUser entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override AspNetUser Deactivate(string key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<AspNetUser> GetActive()
		{
			return context.AspNetUsers;
		}
		
		public override IQueryable<AspNetUser> GetActive(Expression<Func<AspNetUser, bool>> expr)
		{
			return context.AspNetUsers.Where(expr);
		}
		
		public override AspNetUser FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override AspNetUser FirstOrDefault(Expression<Func<AspNetUser, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<AspNetUser> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<AspNetUser> FirstOrDefaultAsync(Expression<Func<AspNetUser, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override AspNetUser SingleOrDefault(Expression<Func<AspNetUser, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<AspNetUser> SingleOrDefaultAsync(Expression<Func<AspNetUser, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override AspNetUser Update(AspNetUser entity)
		{
			entity = context.AspNetUsers.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
