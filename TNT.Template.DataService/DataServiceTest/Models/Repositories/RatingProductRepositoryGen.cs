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
	public partial interface IRatingProductRepository : IBaseRepository<RatingProduct, int>
	{
	}
	
	public partial class RatingProductRepository : BaseRepository<RatingProduct, int>, IRatingProductRepository
	{
		public RatingProductRepository(DbContext context) : base(context)
		{
		}
		
		public RatingProductRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override RatingProduct FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override RatingProduct FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<RatingProduct> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<RatingProduct> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override RatingProduct Activate(RatingProduct entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override RatingProduct Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override RatingProduct Deactivate(RatingProduct entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override RatingProduct Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<RatingProduct> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<RatingProduct> GetActive(Expression<Func<RatingProduct, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
