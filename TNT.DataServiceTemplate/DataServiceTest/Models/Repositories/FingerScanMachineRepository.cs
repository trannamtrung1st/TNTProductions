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
	public partial interface IFingerScanMachineRepository : IBaseRepository<FingerScanMachine, int>
	{
	}
	
	public partial class FingerScanMachineRepository : BaseRepository<FingerScanMachine, int>, IFingerScanMachineRepository
	{
		public FingerScanMachineRepository() : base()
		{
		}
		
		public FingerScanMachineRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override FingerScanMachine Add(FingerScanMachine entity)
		{
			entity.Active = true;
			entity = context.FingerScanMachines.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<FingerScanMachine> AddAsync(FingerScanMachine entity)
		{
			entity.Active = true;
			entity = context.FingerScanMachines.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override FingerScanMachine Delete(FingerScanMachine entity)
		{
			context.FingerScanMachines.Attach(entity);
			entity = context.FingerScanMachines.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<FingerScanMachine> DeleteAsync(FingerScanMachine entity)
		{
			context.FingerScanMachines.Attach(entity);
			entity = context.FingerScanMachines.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override FingerScanMachine Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.FingerScanMachines.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<FingerScanMachine> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.FingerScanMachines.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override FingerScanMachine FindById(int key)
		{
			var entity = context.FingerScanMachines.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override FingerScanMachine FindActiveById(int key)
		{
			var entity = context.FingerScanMachines.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<FingerScanMachine> FindByIdAsync(int key)
		{
			var entity = await context.FingerScanMachines.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<FingerScanMachine> FindActiveByIdAsync(int key)
		{
			var entity = await context.FingerScanMachines.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override FingerScanMachine FindByIdInclude<TProperty>(int key, params Expression<Func<FingerScanMachine, TProperty>>[] members)
		{
			IQueryable<FingerScanMachine> dbSet = context.FingerScanMachines;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<FingerScanMachine> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<FingerScanMachine, TProperty>>[] members)
		{
			IQueryable<FingerScanMachine> dbSet = context.FingerScanMachines;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override FingerScanMachine Activate(FingerScanMachine entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override FingerScanMachine Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override FingerScanMachine Deactivate(FingerScanMachine entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override FingerScanMachine Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<FingerScanMachine> GetActive()
		{
			return context.FingerScanMachines.Where(e => e.Active);
		}
		
		public override IQueryable<FingerScanMachine> GetActive(Expression<Func<FingerScanMachine, bool>> expr)
		{
			return context.FingerScanMachines.Where(e => e.Active).Where(expr);
		}
		
		public override FingerScanMachine FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override FingerScanMachine FirstOrDefault(Expression<Func<FingerScanMachine, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<FingerScanMachine> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<FingerScanMachine> FirstOrDefaultAsync(Expression<Func<FingerScanMachine, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override FingerScanMachine SingleOrDefault(Expression<Func<FingerScanMachine, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<FingerScanMachine> SingleOrDefaultAsync(Expression<Func<FingerScanMachine, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override FingerScanMachine Update(FingerScanMachine entity)
		{
			entity = context.FingerScanMachines.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<FingerScanMachine> UpdateAsync(FingerScanMachine entity)
		{
			entity = context.FingerScanMachines.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
