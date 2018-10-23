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
	public partial interface IProfileRepository : IBaseRepository<Profile, System.Guid>
	{
	}
	
	public partial class ProfileRepository : BaseRepository<Profile, System.Guid>, IProfileRepository
	{
		public ProfileRepository() : base()
		{
		}
		
		public ProfileRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Profile Add(Profile entity)
		{
			
			entity = context.Profiles.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Profile> AddAsync(Profile entity)
		{
			
			entity = context.Profiles.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Profile Delete(Profile entity)
		{
			context.Profiles.Attach(entity);
			entity = context.Profiles.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Profile> DeleteAsync(Profile entity)
		{
			context.Profiles.Attach(entity);
			entity = context.Profiles.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Profile Delete(System.Guid key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Profiles.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Profile> DeleteAsync(System.Guid key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Profiles.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Profile FindById(System.Guid key)
		{
			var entity = context.Profiles.FirstOrDefault(
				e => e.UserId == key);
			return entity;
		}
		
		public override Profile FindActiveById(System.Guid key)
		{
			var entity = context.Profiles.FirstOrDefault(
				e => e.UserId == key);
			return entity;
		}
		
		public override async Task<Profile> FindByIdAsync(System.Guid key)
		{
			var entity = await context.Profiles.FirstOrDefaultAsync(
				e => e.UserId == key);
			return entity;
		}
		
		public override async Task<Profile> FindActiveByIdAsync(System.Guid key)
		{
			var entity = await context.Profiles.FirstOrDefaultAsync(
				e => e.UserId == key);
			return entity;
		}
		
		public override Profile FindByIdInclude<TProperty>(System.Guid key, params Expression<Func<Profile, TProperty>>[] members)
		{
			IQueryable<Profile> dbSet = context.Profiles;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.UserId == key);
		}
		
		public override async Task<Profile> FindByIdIncludeAsync<TProperty>(System.Guid key, params Expression<Func<Profile, TProperty>>[] members)
		{
			IQueryable<Profile> dbSet = context.Profiles;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.UserId == key);
		}
		
		public override Profile Activate(Profile entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Profile Activate(System.Guid key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Profile Deactivate(Profile entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Profile Deactivate(System.Guid key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Profile> GetActive()
		{
			return context.Profiles;
		}
		
		public override IQueryable<Profile> GetActive(Expression<Func<Profile, bool>> expr)
		{
			return context.Profiles.Where(expr);
		}
		
		public override Profile FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Profile FirstOrDefault(Expression<Func<Profile, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Profile> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Profile> FirstOrDefaultAsync(Expression<Func<Profile, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Profile SingleOrDefault(Expression<Func<Profile, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Profile> SingleOrDefaultAsync(Expression<Func<Profile, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Profile Update(Profile entity)
		{
			entity = context.Profiles.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Profile> UpdateAsync(Profile entity)
		{
			entity = context.Profiles.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
