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
	public partial interface IEmployeeFingerRepository : IBaseRepository<EmployeeFinger, int>
	{
	}
	
	public partial class EmployeeFingerRepository : BaseRepository<EmployeeFinger, int>, IEmployeeFingerRepository
	{
		public EmployeeFingerRepository() : base()
		{
		}
		
		public EmployeeFingerRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override EmployeeFinger Add(EmployeeFinger entity)
		{
			entity.Active = true;
			entity = context.EmployeeFingers.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<EmployeeFinger> AddAsync(EmployeeFinger entity)
		{
			entity.Active = true;
			entity = context.EmployeeFingers.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override EmployeeFinger Delete(EmployeeFinger entity)
		{
			context.EmployeeFingers.Attach(entity);
			entity = context.EmployeeFingers.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<EmployeeFinger> DeleteAsync(EmployeeFinger entity)
		{
			context.EmployeeFingers.Attach(entity);
			entity = context.EmployeeFingers.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override EmployeeFinger Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.EmployeeFingers.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<EmployeeFinger> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.EmployeeFingers.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override EmployeeFinger FindById(int key)
		{
			var entity = context.EmployeeFingers.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override EmployeeFinger FindActiveById(int key)
		{
			var entity = context.EmployeeFingers.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<EmployeeFinger> FindByIdAsync(int key)
		{
			var entity = await context.EmployeeFingers.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<EmployeeFinger> FindActiveByIdAsync(int key)
		{
			var entity = await context.EmployeeFingers.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override EmployeeFinger FindByIdInclude<TProperty>(int key, params Expression<Func<EmployeeFinger, TProperty>>[] members)
		{
			IQueryable<EmployeeFinger> dbSet = context.EmployeeFingers;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<EmployeeFinger> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<EmployeeFinger, TProperty>>[] members)
		{
			IQueryable<EmployeeFinger> dbSet = context.EmployeeFingers;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override EmployeeFinger Activate(EmployeeFinger entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override EmployeeFinger Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override EmployeeFinger Deactivate(EmployeeFinger entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override EmployeeFinger Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<EmployeeFinger> GetActive()
		{
			return context.EmployeeFingers.Where(e => e.Active);
		}
		
		public override IQueryable<EmployeeFinger> GetActive(Expression<Func<EmployeeFinger, bool>> expr)
		{
			return context.EmployeeFingers.Where(e => e.Active).Where(expr);
		}
		
		public override EmployeeFinger FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override EmployeeFinger FirstOrDefault(Expression<Func<EmployeeFinger, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<EmployeeFinger> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<EmployeeFinger> FirstOrDefaultAsync(Expression<Func<EmployeeFinger, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override EmployeeFinger SingleOrDefault(Expression<Func<EmployeeFinger, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<EmployeeFinger> SingleOrDefaultAsync(Expression<Func<EmployeeFinger, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override EmployeeFinger Update(EmployeeFinger entity)
		{
			entity = context.EmployeeFingers.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<EmployeeFinger> UpdateAsync(EmployeeFinger entity)
		{
			entity = context.EmployeeFingers.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
