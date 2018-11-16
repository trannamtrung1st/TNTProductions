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
	public partial interface IWardRepository : IBaseRepository<Ward, int>
	{
	}
	
	public partial class WardRepository : BaseRepository<Ward, int>, IWardRepository
	{
		public WardRepository() : base()
		{
		}
		
		public WardRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Ward Add(Ward entity)
		{
			
			entity = context.Wards.Add(entity);
			return entity;
		}
		
		public override Ward Remove(Ward entity)
		{
			context.Wards.Attach(entity);
			entity = context.Wards.Remove(entity);
			return entity;
		}
		
		public override Ward Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Wards.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<Ward> RemoveIf(Expression<Func<Ward, bool>> expr)
		{
			return context.Wards.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<Ward> RemoveRange(IEnumerable<Ward> list)
		{
			return context.Wards.RemoveRange(list);
		}
		
		public override Ward FindById(int key)
		{
			var entity = context.Wards.FirstOrDefault(
				e => e.WardCode == key);
			return entity;
		}
		
		public override Ward FindActiveById(int key)
		{
			var entity = context.Wards.FirstOrDefault(
				e => e.WardCode == key);
			return entity;
		}
		
		public override async Task<Ward> FindByIdAsync(int key)
		{
			var entity = await context.Wards.FirstOrDefaultAsync(
				e => e.WardCode == key);
			return entity;
		}
		
		public override async Task<Ward> FindActiveByIdAsync(int key)
		{
			var entity = await context.Wards.FirstOrDefaultAsync(
				e => e.WardCode == key);
			return entity;
		}
		
		public override Ward FindByIdInclude<TProperty>(int key, params Expression<Func<Ward, TProperty>>[] members)
		{
			IQueryable<Ward> dbSet = context.Wards;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.WardCode == key);
		}
		
		public override async Task<Ward> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Ward, TProperty>>[] members)
		{
			IQueryable<Ward> dbSet = context.Wards;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.WardCode == key);
		}
		
		public override Ward Activate(Ward entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Ward Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Ward Deactivate(Ward entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Ward Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Ward> GetActive()
		{
			return context.Wards;
		}
		
		public override IQueryable<Ward> GetActive(Expression<Func<Ward, bool>> expr)
		{
			return context.Wards.Where(expr);
		}
		
		public override Ward FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Ward FirstOrDefault(Expression<Func<Ward, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Ward> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Ward> FirstOrDefaultAsync(Expression<Func<Ward, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Ward SingleOrDefault(Expression<Func<Ward, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Ward> SingleOrDefaultAsync(Expression<Func<Ward, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Ward Update(Ward entity)
		{
			entity = context.Wards.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
