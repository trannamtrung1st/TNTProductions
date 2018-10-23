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
	public partial interface IMachineConnectRepository : IBaseRepository<MachineConnect, int>
	{
	}
	
	public partial class MachineConnectRepository : BaseRepository<MachineConnect, int>, IMachineConnectRepository
	{
		public MachineConnectRepository() : base()
		{
		}
		
		public MachineConnectRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override MachineConnect Add(MachineConnect entity)
		{
			entity.Active = true;
			entity = context.MachineConnects.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<MachineConnect> AddAsync(MachineConnect entity)
		{
			entity.Active = true;
			entity = context.MachineConnects.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override MachineConnect Delete(MachineConnect entity)
		{
			context.MachineConnects.Attach(entity);
			entity = context.MachineConnects.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<MachineConnect> DeleteAsync(MachineConnect entity)
		{
			context.MachineConnects.Attach(entity);
			entity = context.MachineConnects.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override MachineConnect Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.MachineConnects.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<MachineConnect> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.MachineConnects.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override MachineConnect FindById(int key)
		{
			var entity = context.MachineConnects.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override MachineConnect FindActiveById(int key)
		{
			var entity = context.MachineConnects.FirstOrDefault(
				e => e.ID == key && e.Active);
			return entity;
		}
		
		public override async Task<MachineConnect> FindByIdAsync(int key)
		{
			var entity = await context.MachineConnects.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<MachineConnect> FindActiveByIdAsync(int key)
		{
			var entity = await context.MachineConnects.FirstOrDefaultAsync(
				e => e.ID == key && e.Active);
			return entity;
		}
		
		public override MachineConnect FindByIdInclude<TProperty>(int key, params Expression<Func<MachineConnect, TProperty>>[] members)
		{
			IQueryable<MachineConnect> dbSet = context.MachineConnects;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ID == key);
		}
		
		public override async Task<MachineConnect> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<MachineConnect, TProperty>>[] members)
		{
			IQueryable<MachineConnect> dbSet = context.MachineConnects;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
		}
		
		public override MachineConnect Activate(MachineConnect entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override MachineConnect Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override MachineConnect Deactivate(MachineConnect entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override MachineConnect Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<MachineConnect> GetActive()
		{
			return context.MachineConnects.Where(e => e.Active);
		}
		
		public override IQueryable<MachineConnect> GetActive(Expression<Func<MachineConnect, bool>> expr)
		{
			return context.MachineConnects.Where(e => e.Active).Where(expr);
		}
		
		public override MachineConnect FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override MachineConnect FirstOrDefault(Expression<Func<MachineConnect, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<MachineConnect> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<MachineConnect> FirstOrDefaultAsync(Expression<Func<MachineConnect, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override MachineConnect SingleOrDefault(Expression<Func<MachineConnect, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<MachineConnect> SingleOrDefaultAsync(Expression<Func<MachineConnect, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override MachineConnect Update(MachineConnect entity)
		{
			entity = context.MachineConnects.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<MachineConnect> UpdateAsync(MachineConnect entity)
		{
			entity = context.MachineConnects.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
