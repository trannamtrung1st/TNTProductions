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
	public partial interface ITokenUserRepository : IBaseRepository<TokenUser, int>
	{
	}
	
	public partial class TokenUserRepository : BaseRepository<TokenUser, int>, ITokenUserRepository
	{
		public TokenUserRepository() : base()
		{
		}
		
		public TokenUserRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override TokenUser Add(TokenUser entity)
		{
			
			entity = context.TokenUsers.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<TokenUser> AddAsync(TokenUser entity)
		{
			
			entity = context.TokenUsers.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override TokenUser Delete(TokenUser entity)
		{
			context.TokenUsers.Attach(entity);
			entity = context.TokenUsers.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<TokenUser> DeleteAsync(TokenUser entity)
		{
			context.TokenUsers.Attach(entity);
			entity = context.TokenUsers.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override TokenUser Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.TokenUsers.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<TokenUser> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.TokenUsers.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override TokenUser FindById(int key)
		{
			var entity = context.TokenUsers.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override TokenUser FindActiveById(int key)
		{
			var entity = context.TokenUsers.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<TokenUser> FindByIdAsync(int key)
		{
			var entity = await context.TokenUsers.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<TokenUser> FindActiveByIdAsync(int key)
		{
			var entity = await context.TokenUsers.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override TokenUser FindByIdInclude<TProperty>(int key, params Expression<Func<TokenUser, TProperty>>[] members)
		{
			IQueryable<TokenUser> dbSet = context.TokenUsers;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<TokenUser> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<TokenUser, TProperty>>[] members)
		{
			IQueryable<TokenUser> dbSet = context.TokenUsers;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override TokenUser Activate(TokenUser entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override TokenUser Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override TokenUser Deactivate(TokenUser entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override TokenUser Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<TokenUser> GetActive()
		{
			return context.TokenUsers;
		}
		
		public override IQueryable<TokenUser> GetActive(Expression<Func<TokenUser, bool>> expr)
		{
			return context.TokenUsers.Where(expr);
		}
		
		public override TokenUser FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override TokenUser FirstOrDefault(Expression<Func<TokenUser, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<TokenUser> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<TokenUser> FirstOrDefaultAsync(Expression<Func<TokenUser, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override TokenUser SingleOrDefault(Expression<Func<TokenUser, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<TokenUser> SingleOrDefaultAsync(Expression<Func<TokenUser, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override TokenUser Update(TokenUser entity)
		{
			entity = context.TokenUsers.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<TokenUser> UpdateAsync(TokenUser entity)
		{
			entity = context.TokenUsers.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
