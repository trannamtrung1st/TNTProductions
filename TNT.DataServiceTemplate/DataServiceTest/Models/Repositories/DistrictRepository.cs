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
	public partial interface IDistrictRepository : IBaseRepository<District, int>
	{
	}
	
	public partial class DistrictRepository : BaseRepository<District, int>, IDistrictRepository
	{
		public DistrictRepository() : base()
		{
		}
		
		public DistrictRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override District Add(District entity)
		{
			
			entity = context.Districts.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<District> AddAsync(District entity)
		{
			
			entity = context.Districts.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override District Delete(District entity)
		{
			context.Districts.Attach(entity);
			entity = context.Districts.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<District> DeleteAsync(District entity)
		{
			context.Districts.Attach(entity);
			entity = context.Districts.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override District Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Districts.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<District> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Districts.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override District FindById(int key)
		{
			var entity = context.Districts.FirstOrDefault(
				e => e.DistrictCode == key);
			return entity;
		}
		
		public override District FindActiveById(int key)
		{
			var entity = context.Districts.FirstOrDefault(
				e => e.DistrictCode == key);
			return entity;
		}
		
		public override async Task<District> FindByIdAsync(int key)
		{
			var entity = await context.Districts.FirstOrDefaultAsync(
				e => e.DistrictCode == key);
			return entity;
		}
		
		public override async Task<District> FindActiveByIdAsync(int key)
		{
			var entity = await context.Districts.FirstOrDefaultAsync(
				e => e.DistrictCode == key);
			return entity;
		}
		
		public override District FindByIdInclude<TProperty>(int key, params Expression<Func<District, TProperty>>[] members)
		{
			IQueryable<District> dbSet = context.Districts;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.DistrictCode == key);
		}
		
		public override async Task<District> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<District, TProperty>>[] members)
		{
			IQueryable<District> dbSet = context.Districts;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.DistrictCode == key);
		}
		
		public override District Activate(District entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override District Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override District Deactivate(District entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override District Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<District> GetActive()
		{
			return context.Districts;
		}
		
		public override IQueryable<District> GetActive(Expression<Func<District, bool>> expr)
		{
			return context.Districts.Where(expr);
		}
		
		public override District FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override District FirstOrDefault(Expression<Func<District, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<District> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<District> FirstOrDefaultAsync(Expression<Func<District, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override District SingleOrDefault(Expression<Func<District, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<District> SingleOrDefaultAsync(Expression<Func<District, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override District Update(District entity)
		{
			entity = context.Districts.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<District> UpdateAsync(District entity)
		{
			entity = context.Districts.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
