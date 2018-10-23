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
	public partial interface IMenuRepository : IBaseRepository<Menu, int>
	{
	}
	
	public partial class MenuRepository : BaseRepository<Menu, int>, IMenuRepository
	{
		public MenuRepository() : base()
		{
		}
		
		public MenuRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Menu Add(Menu entity)
		{
			
			entity = context.Menus.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Menu> AddAsync(Menu entity)
		{
			
			entity = context.Menus.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Menu Delete(Menu entity)
		{
			context.Menus.Attach(entity);
			entity = context.Menus.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Menu> DeleteAsync(Menu entity)
		{
			context.Menus.Attach(entity);
			entity = context.Menus.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Menu Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Menus.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Menu> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Menus.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Menu FindById(int key)
		{
			var entity = context.Menus.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override Menu FindActiveById(int key)
		{
			var entity = context.Menus.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Menu> FindByIdAsync(int key)
		{
			var entity = await context.Menus.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Menu> FindActiveByIdAsync(int key)
		{
			var entity = await context.Menus.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override Menu FindByIdInclude<TProperty>(int key, params Expression<Func<Menu, TProperty>>[] members)
		{
			IQueryable<Menu> dbSet = context.Menus;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<Menu> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Menu, TProperty>>[] members)
		{
			IQueryable<Menu> dbSet = context.Menus;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override Menu Activate(Menu entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Menu Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Menu Deactivate(Menu entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Menu Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Menu> GetActive()
		{
			return context.Menus;
		}
		
		public override IQueryable<Menu> GetActive(Expression<Func<Menu, bool>> expr)
		{
			return context.Menus.Where(expr);
		}
		
		public override Menu FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Menu FirstOrDefault(Expression<Func<Menu, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Menu> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Menu> FirstOrDefaultAsync(Expression<Func<Menu, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Menu SingleOrDefault(Expression<Func<Menu, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Menu> SingleOrDefaultAsync(Expression<Func<Menu, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Menu Update(Menu entity)
		{
			entity = context.Menus.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Menu> UpdateAsync(Menu entity)
		{
			entity = context.Menus.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
