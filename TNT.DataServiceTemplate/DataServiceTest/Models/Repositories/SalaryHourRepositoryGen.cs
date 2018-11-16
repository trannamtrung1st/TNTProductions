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
	public partial interface ISalaryHourRepository : IBaseRepository<SalaryHour, int>
	{
	}
	
	public partial class SalaryHourRepository : BaseRepository<SalaryHour, int>, ISalaryHourRepository
	{
		public SalaryHourRepository() : base()
		{
		}
		
		public SalaryHourRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override SalaryHour Add(SalaryHour entity)
		{
			entity.Active = true;
			entity = context.SalaryHours.Add(entity);
			return entity;
		}
		
		public override SalaryHour Remove(SalaryHour entity)
		{
			context.SalaryHours.Attach(entity);
			entity = context.SalaryHours.Remove(entity);
			return entity;
		}
		
		public override SalaryHour Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.SalaryHours.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<SalaryHour> RemoveIf(Expression<Func<SalaryHour, bool>> expr)
		{
			return context.SalaryHours.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<SalaryHour> RemoveRange(IEnumerable<SalaryHour> list)
		{
			return context.SalaryHours.RemoveRange(list);
		}
		
		public override SalaryHour FindById(int key)
		{
			var entity = context.SalaryHours.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override SalaryHour FindActiveById(int key)
		{
			var entity = context.SalaryHours.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<SalaryHour> FindByIdAsync(int key)
		{
			var entity = await context.SalaryHours.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<SalaryHour> FindActiveByIdAsync(int key)
		{
			var entity = await context.SalaryHours.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override SalaryHour FindByIdInclude<TProperty>(int key, params Expression<Func<SalaryHour, TProperty>>[] members)
		{
			IQueryable<SalaryHour> dbSet = context.SalaryHours;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<SalaryHour> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<SalaryHour, TProperty>>[] members)
		{
			IQueryable<SalaryHour> dbSet = context.SalaryHours;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override SalaryHour Activate(SalaryHour entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override SalaryHour Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override SalaryHour Deactivate(SalaryHour entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override SalaryHour Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<SalaryHour> GetActive()
		{
			return context.SalaryHours.Where(e => e.Active);
		}
		
		public override IQueryable<SalaryHour> GetActive(Expression<Func<SalaryHour, bool>> expr)
		{
			return context.SalaryHours.Where(e => e.Active).Where(expr);
		}
		
		public override SalaryHour FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override SalaryHour FirstOrDefault(Expression<Func<SalaryHour, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<SalaryHour> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<SalaryHour> FirstOrDefaultAsync(Expression<Func<SalaryHour, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override SalaryHour SingleOrDefault(Expression<Func<SalaryHour, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<SalaryHour> SingleOrDefaultAsync(Expression<Func<SalaryHour, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override SalaryHour Update(SalaryHour entity)
		{
			entity = context.SalaryHours.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
