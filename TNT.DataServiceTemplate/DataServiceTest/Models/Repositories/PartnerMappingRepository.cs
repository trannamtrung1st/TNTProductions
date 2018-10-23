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
	public partial interface IPartnerMappingRepository : IBaseRepository<PartnerMapping, int>
	{
	}
	
	public partial class PartnerMappingRepository : BaseRepository<PartnerMapping, int>, IPartnerMappingRepository
	{
		public PartnerMappingRepository() : base()
		{
		}
		
		public PartnerMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PartnerMapping Add(PartnerMapping entity)
		{
			
			entity = context.PartnerMappings.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PartnerMapping> AddAsync(PartnerMapping entity)
		{
			
			entity = context.PartnerMappings.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override PartnerMapping Delete(PartnerMapping entity)
		{
			context.PartnerMappings.Attach(entity);
			entity = context.PartnerMappings.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PartnerMapping> DeleteAsync(PartnerMapping entity)
		{
			context.PartnerMappings.Attach(entity);
			entity = context.PartnerMappings.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override PartnerMapping Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.PartnerMappings.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PartnerMapping> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.PartnerMappings.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override PartnerMapping FindById(int key)
		{
			var entity = context.PartnerMappings.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override PartnerMapping FindActiveById(int key)
		{
			var entity = context.PartnerMappings.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<PartnerMapping> FindByIdAsync(int key)
		{
			var entity = await context.PartnerMappings.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<PartnerMapping> FindActiveByIdAsync(int key)
		{
			var entity = await context.PartnerMappings.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override PartnerMapping FindByIdInclude<TProperty>(int key, params Expression<Func<PartnerMapping, TProperty>>[] members)
		{
			IQueryable<PartnerMapping> dbSet = context.PartnerMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<PartnerMapping> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<PartnerMapping, TProperty>>[] members)
		{
			IQueryable<PartnerMapping> dbSet = context.PartnerMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override PartnerMapping Activate(PartnerMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PartnerMapping Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PartnerMapping Deactivate(PartnerMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PartnerMapping Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<PartnerMapping> GetActive()
		{
			return context.PartnerMappings;
		}
		
		public override IQueryable<PartnerMapping> GetActive(Expression<Func<PartnerMapping, bool>> expr)
		{
			return context.PartnerMappings.Where(expr);
		}
		
		public override PartnerMapping FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override PartnerMapping FirstOrDefault(Expression<Func<PartnerMapping, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<PartnerMapping> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<PartnerMapping> FirstOrDefaultAsync(Expression<Func<PartnerMapping, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override PartnerMapping SingleOrDefault(Expression<Func<PartnerMapping, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<PartnerMapping> SingleOrDefaultAsync(Expression<Func<PartnerMapping, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override PartnerMapping Update(PartnerMapping entity)
		{
			entity = context.PartnerMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PartnerMapping> UpdateAsync(PartnerMapping entity)
		{
			entity = context.PartnerMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
