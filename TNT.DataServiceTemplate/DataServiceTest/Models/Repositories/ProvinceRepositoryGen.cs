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
	public partial interface IProvinceRepository : IBaseRepository<Province, int>
	{
	}
	
	public partial class ProvinceRepository : BaseRepository<Province, int>, IProvinceRepository
	{
		public ProvinceRepository() : base()
		{
		}
		
		public ProvinceRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Province Add(Province entity)
		{
			
			entity = context.Provinces.Add(entity);
			return entity;
		}
		
		public override Province Remove(Province entity)
		{
			context.Provinces.Attach(entity);
			entity = context.Provinces.Remove(entity);
			return entity;
		}
		
		public override Province Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Provinces.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<Province> RemoveIf(Expression<Func<Province, bool>> expr)
		{
			return context.Provinces.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<Province> RemoveRange(IEnumerable<Province> list)
		{
			return context.Provinces.RemoveRange(list);
		}
		
		public override Province FindById(int key)
		{
			var entity = context.Provinces.FirstOrDefault(
				e => e.ProvinceCode == key);
			return entity;
		}
		
		public override Province FindActiveById(int key)
		{
			var entity = context.Provinces.FirstOrDefault(
				e => e.ProvinceCode == key);
			return entity;
		}
		
		public override async Task<Province> FindByIdAsync(int key)
		{
			var entity = await context.Provinces.FirstOrDefaultAsync(
				e => e.ProvinceCode == key);
			return entity;
		}
		
		public override async Task<Province> FindActiveByIdAsync(int key)
		{
			var entity = await context.Provinces.FirstOrDefaultAsync(
				e => e.ProvinceCode == key);
			return entity;
		}
		
		public override Province FindByIdInclude<TProperty>(int key, params Expression<Func<Province, TProperty>>[] members)
		{
			IQueryable<Province> dbSet = context.Provinces;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ProvinceCode == key);
		}
		
		public override async Task<Province> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Province, TProperty>>[] members)
		{
			IQueryable<Province> dbSet = context.Provinces;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ProvinceCode == key);
		}
		
		public override Province Activate(Province entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Province Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Province Deactivate(Province entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Province Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Province> GetActive()
		{
			return context.Provinces;
		}
		
		public override IQueryable<Province> GetActive(Expression<Func<Province, bool>> expr)
		{
			return context.Provinces.Where(expr);
		}
		
		public override Province FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Province FirstOrDefault(Expression<Func<Province, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Province> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Province> FirstOrDefaultAsync(Expression<Func<Province, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Province SingleOrDefault(Expression<Func<Province, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Province> SingleOrDefaultAsync(Expression<Func<Province, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Province Update(Province entity)
		{
			entity = context.Provinces.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
