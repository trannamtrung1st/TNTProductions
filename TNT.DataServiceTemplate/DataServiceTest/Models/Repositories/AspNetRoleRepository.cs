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
	public partial interface IAspNetRoleRepository : IBaseRepository<AspNetRole, string>
	{
	}
	
	public partial class AspNetRoleRepository : BaseRepository<AspNetRole, string>, IAspNetRoleRepository
	{
		public AspNetRoleRepository() : base()
		{
		}
		
		public AspNetRoleRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override AspNetRole Add(AspNetRole entity)
		{
			
			entity = context.AspNetRoles.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<AspNetRole> AddAsync(AspNetRole entity)
		{
			
			entity = context.AspNetRoles.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override AspNetRole Delete(AspNetRole entity)
		{
			context.AspNetRoles.Attach(entity);
			entity = context.AspNetRoles.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<AspNetRole> DeleteAsync(AspNetRole entity)
		{
			context.AspNetRoles.Attach(entity);
			entity = context.AspNetRoles.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override AspNetRole Delete(string key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.AspNetRoles.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<AspNetRole> DeleteAsync(string key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.AspNetRoles.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override AspNetRole FindById(string key)
		{
			var entity = context.AspNetRoles.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override AspNetRole FindActiveById(string key)
		{
			var entity = context.AspNetRoles.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<AspNetRole> FindByIdAsync(string key)
		{
			var entity = await context.AspNetRoles.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<AspNetRole> FindActiveByIdAsync(string key)
		{
			var entity = await context.AspNetRoles.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override AspNetRole FindByIdInclude<TProperty>(string key, params Expression<Func<AspNetRole, TProperty>>[] members)
		{
			IQueryable<AspNetRole> dbSet = context.AspNetRoles;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<AspNetRole> FindByIdIncludeAsync<TProperty>(string key, params Expression<Func<AspNetRole, TProperty>>[] members)
		{
			IQueryable<AspNetRole> dbSet = context.AspNetRoles;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override AspNetRole Activate(AspNetRole entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override AspNetRole Activate(string key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override AspNetRole Deactivate(AspNetRole entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override AspNetRole Deactivate(string key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<AspNetRole> GetActive()
		{
			return context.AspNetRoles;
		}
		
		public override IQueryable<AspNetRole> GetActive(Expression<Func<AspNetRole, bool>> expr)
		{
			return context.AspNetRoles.Where(expr);
		}
		
		public override AspNetRole FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override AspNetRole FirstOrDefault(Expression<Func<AspNetRole, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<AspNetRole> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<AspNetRole> FirstOrDefaultAsync(Expression<Func<AspNetRole, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override AspNetRole SingleOrDefault(Expression<Func<AspNetRole, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<AspNetRole> SingleOrDefaultAsync(Expression<Func<AspNetRole, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override AspNetRole Update(AspNetRole entity)
		{
			entity = context.AspNetRoles.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<AspNetRole> UpdateAsync(AspNetRole entity)
		{
			entity = context.AspNetRoles.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
