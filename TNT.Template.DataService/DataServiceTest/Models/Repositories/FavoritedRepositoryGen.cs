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
	public partial interface IFavoritedRepository : IBaseRepository<Favorited, int>
	{
	}
	
	public partial class FavoritedRepository : BaseRepository<Favorited, int>, IFavoritedRepository
	{
		public FavoritedRepository(DbContext context) : base(context)
		{
		}
		
		public FavoritedRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Favorited FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override Favorited FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<Favorited> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Favorited> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override Favorited Activate(Favorited entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override Favorited Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override Favorited Deactivate(Favorited entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override Favorited Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<Favorited> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<Favorited> GetActive(Expression<Func<Favorited, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
