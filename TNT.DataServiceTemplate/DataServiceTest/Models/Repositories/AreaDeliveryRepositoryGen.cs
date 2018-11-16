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
	public partial interface IAreaDeliveryRepository : IBaseRepository<AreaDelivery, int>
	{
	}
	
	public partial class AreaDeliveryRepository : BaseRepository<AreaDelivery, int>, IAreaDeliveryRepository
	{
		public AreaDeliveryRepository() : base()
		{
		}
		
		public AreaDeliveryRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override AreaDelivery Add(AreaDelivery entity)
		{
			
			entity = context.AreaDeliveries.Add(entity);
			return entity;
		}
		
		public override AreaDelivery Remove(AreaDelivery entity)
		{
			context.AreaDeliveries.Attach(entity);
			entity = context.AreaDeliveries.Remove(entity);
			return entity;
		}
		
		public override AreaDelivery Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.AreaDeliveries.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<AreaDelivery> RemoveIf(Expression<Func<AreaDelivery, bool>> expr)
		{
			return context.AreaDeliveries.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<AreaDelivery> RemoveRange(IEnumerable<AreaDelivery> list)
		{
			return context.AreaDeliveries.RemoveRange(list);
		}
		
		public override AreaDelivery FindById(int key)
		{
			var entity = context.AreaDeliveries.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override AreaDelivery FindActiveById(int key)
		{
			var entity = context.AreaDeliveries.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<AreaDelivery> FindByIdAsync(int key)
		{
			var entity = await context.AreaDeliveries.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<AreaDelivery> FindActiveByIdAsync(int key)
		{
			var entity = await context.AreaDeliveries.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override AreaDelivery FindByIdInclude<TProperty>(int key, params Expression<Func<AreaDelivery, TProperty>>[] members)
		{
			IQueryable<AreaDelivery> dbSet = context.AreaDeliveries;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<AreaDelivery> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<AreaDelivery, TProperty>>[] members)
		{
			IQueryable<AreaDelivery> dbSet = context.AreaDeliveries;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override AreaDelivery Activate(AreaDelivery entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override AreaDelivery Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override AreaDelivery Deactivate(AreaDelivery entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override AreaDelivery Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<AreaDelivery> GetActive()
		{
			return context.AreaDeliveries;
		}
		
		public override IQueryable<AreaDelivery> GetActive(Expression<Func<AreaDelivery, bool>> expr)
		{
			return context.AreaDeliveries.Where(expr);
		}
		
		public override AreaDelivery FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override AreaDelivery FirstOrDefault(Expression<Func<AreaDelivery, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<AreaDelivery> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<AreaDelivery> FirstOrDefaultAsync(Expression<Func<AreaDelivery, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override AreaDelivery SingleOrDefault(Expression<Func<AreaDelivery, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<AreaDelivery> SingleOrDefaultAsync(Expression<Func<AreaDelivery, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override AreaDelivery Update(AreaDelivery entity)
		{
			entity = context.AreaDeliveries.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
