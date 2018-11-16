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
	public partial interface IEmployeeGroupRepository : IBaseRepository<EmployeeGroup, int>
	{
	}
	
	public partial class EmployeeGroupRepository : BaseRepository<EmployeeGroup, int>, IEmployeeGroupRepository
	{
		public EmployeeGroupRepository() : base()
		{
		}
		
		public EmployeeGroupRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override EmployeeGroup Add(EmployeeGroup entity)
		{
			entity.Active = true;
			entity = context.EmployeeGroups.Add(entity);
			return entity;
		}
		
		public override EmployeeGroup Remove(EmployeeGroup entity)
		{
			context.EmployeeGroups.Attach(entity);
			entity = context.EmployeeGroups.Remove(entity);
			return entity;
		}
		
		public override EmployeeGroup Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.EmployeeGroups.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<EmployeeGroup> RemoveIf(Expression<Func<EmployeeGroup, bool>> expr)
		{
			return context.EmployeeGroups.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<EmployeeGroup> RemoveRange(IEnumerable<EmployeeGroup> list)
		{
			return context.EmployeeGroups.RemoveRange(list);
		}
		
		public override EmployeeGroup FindById(int key)
		{
			var entity = context.EmployeeGroups.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override EmployeeGroup FindActiveById(int key)
		{
			var entity = context.EmployeeGroups.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<EmployeeGroup> FindByIdAsync(int key)
		{
			var entity = await context.EmployeeGroups.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<EmployeeGroup> FindActiveByIdAsync(int key)
		{
			var entity = await context.EmployeeGroups.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override EmployeeGroup FindByIdInclude<TProperty>(int key, params Expression<Func<EmployeeGroup, TProperty>>[] members)
		{
			IQueryable<EmployeeGroup> dbSet = context.EmployeeGroups;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<EmployeeGroup> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<EmployeeGroup, TProperty>>[] members)
		{
			IQueryable<EmployeeGroup> dbSet = context.EmployeeGroups;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override EmployeeGroup Activate(EmployeeGroup entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override EmployeeGroup Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override EmployeeGroup Deactivate(EmployeeGroup entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override EmployeeGroup Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<EmployeeGroup> GetActive()
		{
			return context.EmployeeGroups.Where(e => e.Active);
		}
		
		public override IQueryable<EmployeeGroup> GetActive(Expression<Func<EmployeeGroup, bool>> expr)
		{
			return context.EmployeeGroups.Where(e => e.Active).Where(expr);
		}
		
		public override EmployeeGroup FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override EmployeeGroup FirstOrDefault(Expression<Func<EmployeeGroup, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<EmployeeGroup> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<EmployeeGroup> FirstOrDefaultAsync(Expression<Func<EmployeeGroup, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override EmployeeGroup SingleOrDefault(Expression<Func<EmployeeGroup, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<EmployeeGroup> SingleOrDefaultAsync(Expression<Func<EmployeeGroup, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override EmployeeGroup Update(EmployeeGroup entity)
		{
			entity = context.EmployeeGroups.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
