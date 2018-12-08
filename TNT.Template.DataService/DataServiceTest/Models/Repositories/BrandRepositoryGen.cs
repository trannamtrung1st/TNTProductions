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
	public partial interface IBrandRepository : IBaseRepository<Brand, int>
	{
	}
	
	public partial class BrandRepository : BaseRepository<Brand, int>, IBrandRepository
	{
		public BrandRepository(DbContext context) : base(context)
		{
		}
		
		public BrandRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Brand FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override Brand FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<Brand> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Brand> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override Brand Activate(Brand entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override Brand Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override Brand Deactivate(Brand entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override Brand Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<Brand> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<Brand> GetActive(Expression<Func<Brand, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
