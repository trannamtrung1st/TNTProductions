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
	public partial interface ICategoryExtraRepository : IBaseRepository<CategoryExtra, int>
	{
	}
	
	public partial class CategoryExtraRepository : BaseRepository<CategoryExtra, int>, ICategoryExtraRepository
	{
		public CategoryExtraRepository(DbContext context) : base(context)
		{
		}
		
		public CategoryExtraRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override CategoryExtra FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.CategoryExtraId == key);
			return entity;
		}
		
		public override CategoryExtra FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.CategoryExtraId == key);
			return entity;
		}
		
		public override async Task<CategoryExtra> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.CategoryExtraId == key);
			return entity;
		}
		
		public override async Task<CategoryExtra> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.CategoryExtraId == key);
			return entity;
		}
		
		public override CategoryExtra Activate(CategoryExtra entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CategoryExtra Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CategoryExtra Deactivate(CategoryExtra entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CategoryExtra Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<CategoryExtra> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<CategoryExtra> GetActive(Expression<Func<CategoryExtra, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
