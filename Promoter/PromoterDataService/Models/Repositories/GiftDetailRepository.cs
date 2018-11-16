using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoterDataService.Models;
using PromoterDataService.Managers;
using System.Linq.Expressions;
using System.Data.Entity;

namespace PromoterDataService.Models.Repositories
{
	public partial interface IGiftDetailRepository : IBaseRepository<GiftDetail, int>
	{
	}
	
	public partial class GiftDetailRepository : BaseRepository<GiftDetail, int>, IGiftDetailRepository
	{
		public GiftDetailRepository() : base()
		{
		}
		
		public GiftDetailRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override GiftDetail Add(GiftDetail entity)
		{
			
			entity = context.GiftDetails.Add(entity);
			return entity;
		}
		
		public override GiftDetail Remove(GiftDetail entity)
		{
			context.GiftDetails.Attach(entity);
			entity = context.GiftDetails.Remove(entity);
			return entity;
		}
		
		public override GiftDetail Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.GiftDetails.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<GiftDetail> RemoveIf(Expression<Func<GiftDetail, bool>> expr)
		{
			return context.GiftDetails.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<GiftDetail> RemoveRange(IEnumerable<GiftDetail> list)
		{
			return context.GiftDetails.RemoveRange(list);
		}
		
		public override GiftDetail FindById(int key)
		{
			var entity = context.GiftDetails.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override GiftDetail FindActiveById(int key)
		{
			var entity = context.GiftDetails.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<GiftDetail> FindByIdAsync(int key)
		{
			var entity = await context.GiftDetails.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<GiftDetail> FindActiveByIdAsync(int key)
		{
			var entity = await context.GiftDetails.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override GiftDetail FindByIdInclude<TProperty>(int key, params Expression<Func<GiftDetail, TProperty>>[] members)
		{
			IQueryable<GiftDetail> dbSet = context.GiftDetails;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ID == key);
		}
		
		public override async Task<GiftDetail> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<GiftDetail, TProperty>>[] members)
		{
			IQueryable<GiftDetail> dbSet = context.GiftDetails;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
		}
		
		public override GiftDetail Activate(GiftDetail entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override GiftDetail Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override GiftDetail Deactivate(GiftDetail entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override GiftDetail Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<GiftDetail> GetActive()
		{
			return context.GiftDetails;
		}
		
		public override IQueryable<GiftDetail> GetActive(Expression<Func<GiftDetail, bool>> expr)
		{
			return context.GiftDetails.Where(expr);
		}
		
		public override GiftDetail FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override GiftDetail FirstOrDefault(Expression<Func<GiftDetail, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<GiftDetail> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<GiftDetail> FirstOrDefaultAsync(Expression<Func<GiftDetail, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override GiftDetail SingleOrDefault(Expression<Func<GiftDetail, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<GiftDetail> SingleOrDefaultAsync(Expression<Func<GiftDetail, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override GiftDetail Update(GiftDetail entity)
		{
			entity = context.GiftDetails.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
