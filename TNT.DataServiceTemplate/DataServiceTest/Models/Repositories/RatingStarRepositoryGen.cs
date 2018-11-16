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
	public partial interface IRatingStarRepository : IBaseRepository<RatingStar, int>
	{
	}
	
	public partial class RatingStarRepository : BaseRepository<RatingStar, int>, IRatingStarRepository
	{
		public RatingStarRepository() : base()
		{
		}
		
		public RatingStarRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override RatingStar Add(RatingStar entity)
		{
			
			entity = context.RatingStars.Add(entity);
			return entity;
		}
		
		public override RatingStar Remove(RatingStar entity)
		{
			context.RatingStars.Attach(entity);
			entity = context.RatingStars.Remove(entity);
			return entity;
		}
		
		public override RatingStar Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.RatingStars.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<RatingStar> RemoveIf(Expression<Func<RatingStar, bool>> expr)
		{
			return context.RatingStars.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<RatingStar> RemoveRange(IEnumerable<RatingStar> list)
		{
			return context.RatingStars.RemoveRange(list);
		}
		
		public override RatingStar FindById(int key)
		{
			var entity = context.RatingStars.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override RatingStar FindActiveById(int key)
		{
			var entity = context.RatingStars.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<RatingStar> FindByIdAsync(int key)
		{
			var entity = await context.RatingStars.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<RatingStar> FindActiveByIdAsync(int key)
		{
			var entity = await context.RatingStars.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override RatingStar FindByIdInclude<TProperty>(int key, params Expression<Func<RatingStar, TProperty>>[] members)
		{
			IQueryable<RatingStar> dbSet = context.RatingStars;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ID == key);
		}
		
		public override async Task<RatingStar> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<RatingStar, TProperty>>[] members)
		{
			IQueryable<RatingStar> dbSet = context.RatingStars;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
		}
		
		public override RatingStar Activate(RatingStar entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override RatingStar Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override RatingStar Deactivate(RatingStar entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override RatingStar Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<RatingStar> GetActive()
		{
			return context.RatingStars;
		}
		
		public override IQueryable<RatingStar> GetActive(Expression<Func<RatingStar, bool>> expr)
		{
			return context.RatingStars.Where(expr);
		}
		
		public override RatingStar FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override RatingStar FirstOrDefault(Expression<Func<RatingStar, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<RatingStar> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<RatingStar> FirstOrDefaultAsync(Expression<Func<RatingStar, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override RatingStar SingleOrDefault(Expression<Func<RatingStar, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<RatingStar> SingleOrDefaultAsync(Expression<Func<RatingStar, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override RatingStar Update(RatingStar entity)
		{
			entity = context.RatingStars.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
