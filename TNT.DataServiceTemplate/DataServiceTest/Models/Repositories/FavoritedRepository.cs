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
	public partial interface IFavoritedRepository : IBaseRepository<Favorited, int>
	{
	}
	
	public partial class FavoritedRepository : BaseRepository<Favorited, int>, IFavoritedRepository
	{
		public FavoritedRepository() : base()
		{
		}
		
		public FavoritedRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Favorited Add(Favorited entity)
		{
			entity.Active = true;
			entity = context.Favoriteds.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Favorited> AddAsync(Favorited entity)
		{
			entity.Active = true;
			entity = context.Favoriteds.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Favorited Delete(Favorited entity)
		{
			context.Favoriteds.Attach(entity);
			entity = context.Favoriteds.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Favorited> DeleteAsync(Favorited entity)
		{
			context.Favoriteds.Attach(entity);
			entity = context.Favoriteds.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Favorited Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Favoriteds.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Favorited> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Favoriteds.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Favorited FindById(int key)
		{
			var entity = context.Favoriteds.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override Favorited FindActiveById(int key)
		{
			var entity = context.Favoriteds.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<Favorited> FindByIdAsync(int key)
		{
			var entity = await context.Favoriteds.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Favorited> FindActiveByIdAsync(int key)
		{
			var entity = await context.Favoriteds.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override Favorited FindByIdInclude<TProperty>(int key, params Expression<Func<Favorited, TProperty>>[] members)
		{
			IQueryable<Favorited> dbSet = context.Favoriteds;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<Favorited> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Favorited, TProperty>>[] members)
		{
			IQueryable<Favorited> dbSet = context.Favoriteds;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override Favorited Activate(Favorited entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override Favorited Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override Favorited Deactivate(Favorited entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override Favorited Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<Favorited> GetActive()
		{
			return context.Favoriteds.Where(e => e.Active);
		}
		
		public override IQueryable<Favorited> GetActive(Expression<Func<Favorited, bool>> expr)
		{
			return context.Favoriteds.Where(e => e.Active).Where(expr);
		}
		
		public override Favorited FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Favorited FirstOrDefault(Expression<Func<Favorited, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Favorited> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Favorited> FirstOrDefaultAsync(Expression<Func<Favorited, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Favorited SingleOrDefault(Expression<Func<Favorited, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Favorited> SingleOrDefaultAsync(Expression<Func<Favorited, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Favorited Update(Favorited entity)
		{
			entity = context.Favoriteds.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Favorited> UpdateAsync(Favorited entity)
		{
			entity = context.Favoriteds.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
