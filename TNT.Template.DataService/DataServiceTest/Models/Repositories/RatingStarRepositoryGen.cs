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
		public RatingStarRepository(DbContext context) : base(context)
		{
		}
		
		public RatingStarRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override RatingStar FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override RatingStar FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<RatingStar> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<RatingStar> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
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
			return dbSet;
		}
		
		public override IQueryable<RatingStar> GetActive(Expression<Func<RatingStar, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
