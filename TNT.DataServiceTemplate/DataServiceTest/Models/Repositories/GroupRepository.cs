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
	public partial interface IGroupRepository : IBaseRepository<Group, int>
	{
	}
	
	public partial class GroupRepository : BaseRepository<Group, int>, IGroupRepository
	{
		public GroupRepository() : base()
		{
		}
		
		public GroupRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Group Add(Group entity)
		{
			
			entity = context.Groups.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Group> AddAsync(Group entity)
		{
			
			entity = context.Groups.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Group Delete(Group entity)
		{
			context.Groups.Attach(entity);
			entity = context.Groups.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Group> DeleteAsync(Group entity)
		{
			context.Groups.Attach(entity);
			entity = context.Groups.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Group Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Groups.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Group> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Groups.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Group FindById(int key)
		{
			var entity = context.Groups.FirstOrDefault(
				e => e.GroupId == key);
			return entity;
		}
		
		public override Group FindActiveById(int key)
		{
			var entity = context.Groups.FirstOrDefault(
				e => e.GroupId == key);
			return entity;
		}
		
		public override async Task<Group> FindByIdAsync(int key)
		{
			var entity = await context.Groups.FirstOrDefaultAsync(
				e => e.GroupId == key);
			return entity;
		}
		
		public override async Task<Group> FindActiveByIdAsync(int key)
		{
			var entity = await context.Groups.FirstOrDefaultAsync(
				e => e.GroupId == key);
			return entity;
		}
		
		public override Group FindByIdInclude<TProperty>(int key, params Expression<Func<Group, TProperty>>[] members)
		{
			IQueryable<Group> dbSet = context.Groups;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.GroupId == key);
		}
		
		public override async Task<Group> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Group, TProperty>>[] members)
		{
			IQueryable<Group> dbSet = context.Groups;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.GroupId == key);
		}
		
		public override Group Activate(Group entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Group Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Group Deactivate(Group entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Group Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Group> GetActive()
		{
			return context.Groups;
		}
		
		public override IQueryable<Group> GetActive(Expression<Func<Group, bool>> expr)
		{
			return context.Groups.Where(expr);
		}
		
		public override Group FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Group FirstOrDefault(Expression<Func<Group, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Group> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Group> FirstOrDefaultAsync(Expression<Func<Group, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Group SingleOrDefault(Expression<Func<Group, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Group> SingleOrDefaultAsync(Expression<Func<Group, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Group Update(Group entity)
		{
			entity = context.Groups.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Group> UpdateAsync(Group entity)
		{
			entity = context.Groups.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
