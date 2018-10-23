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
	public partial interface IVATOrderMappingRepository : IBaseRepository<VATOrderMapping, int>
	{
	}
	
	public partial class VATOrderMappingRepository : BaseRepository<VATOrderMapping, int>, IVATOrderMappingRepository
	{
		public VATOrderMappingRepository() : base()
		{
		}
		
		public VATOrderMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override VATOrderMapping Add(VATOrderMapping entity)
		{
			
			entity = context.VATOrderMappings.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<VATOrderMapping> AddAsync(VATOrderMapping entity)
		{
			
			entity = context.VATOrderMappings.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override VATOrderMapping Delete(VATOrderMapping entity)
		{
			context.VATOrderMappings.Attach(entity);
			entity = context.VATOrderMappings.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<VATOrderMapping> DeleteAsync(VATOrderMapping entity)
		{
			context.VATOrderMappings.Attach(entity);
			entity = context.VATOrderMappings.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override VATOrderMapping Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.VATOrderMappings.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<VATOrderMapping> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.VATOrderMappings.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override VATOrderMapping FindById(int key)
		{
			var entity = context.VATOrderMappings.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override VATOrderMapping FindActiveById(int key)
		{
			var entity = context.VATOrderMappings.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<VATOrderMapping> FindByIdAsync(int key)
		{
			var entity = await context.VATOrderMappings.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<VATOrderMapping> FindActiveByIdAsync(int key)
		{
			var entity = await context.VATOrderMappings.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override VATOrderMapping FindByIdInclude<TProperty>(int key, params Expression<Func<VATOrderMapping, TProperty>>[] members)
		{
			IQueryable<VATOrderMapping> dbSet = context.VATOrderMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ID == key);
		}
		
		public override async Task<VATOrderMapping> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<VATOrderMapping, TProperty>>[] members)
		{
			IQueryable<VATOrderMapping> dbSet = context.VATOrderMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
		}
		
		public override VATOrderMapping Activate(VATOrderMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override VATOrderMapping Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override VATOrderMapping Deactivate(VATOrderMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override VATOrderMapping Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<VATOrderMapping> GetActive()
		{
			return context.VATOrderMappings;
		}
		
		public override IQueryable<VATOrderMapping> GetActive(Expression<Func<VATOrderMapping, bool>> expr)
		{
			return context.VATOrderMappings.Where(expr);
		}
		
		public override VATOrderMapping FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override VATOrderMapping FirstOrDefault(Expression<Func<VATOrderMapping, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<VATOrderMapping> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<VATOrderMapping> FirstOrDefaultAsync(Expression<Func<VATOrderMapping, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override VATOrderMapping SingleOrDefault(Expression<Func<VATOrderMapping, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<VATOrderMapping> SingleOrDefaultAsync(Expression<Func<VATOrderMapping, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override VATOrderMapping Update(VATOrderMapping entity)
		{
			entity = context.VATOrderMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<VATOrderMapping> UpdateAsync(VATOrderMapping entity)
		{
			entity = context.VATOrderMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
