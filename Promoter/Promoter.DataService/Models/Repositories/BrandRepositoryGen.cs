using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Promoter.DataService.Models;
using Promoter.DataService.Managers;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Promoter.DataService.Models.Repositories
{
	public partial interface IBrandRepository : IBaseRepository<Brand, int>
	{
	}
	
	public partial class BrandRepository : BaseRepository<Brand, int>, IBrandRepository
	{
		public BrandRepository(PromoterEntities context) : base(context)
		{
		}
		
		public BrandRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Brand Add(Brand entity)
		{
			
			entity = context.Brands.Add(entity);
			return entity;
		}
		
		public override Brand Remove(Brand entity)
		{
			context.Brands.Attach(entity);
			entity = context.Brands.Remove(entity);
			return entity;
		}
		
		public override Brand Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Brands.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<Brand> RemoveIf(Expression<Func<Brand, bool>> expr)
		{
			return context.Brands.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<Brand> RemoveRange(IEnumerable<Brand> list)
		{
			return context.Brands.RemoveRange(list);
		}
		
		public override Brand FindById(int key)
		{
			var entity = context.Brands.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override Brand FindActiveById(int key)
		{
			var entity = context.Brands.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Brand> FindByIdAsync(int key)
		{
			var entity = await context.Brands.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Brand> FindActiveByIdAsync(int key)
		{
			var entity = await context.Brands.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override Brand FindByIdInclude<TProperty>(int key, params Expression<Func<Brand, TProperty>>[] members)
		{
			IQueryable<Brand> dbSet = context.Brands;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<Brand> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Brand, TProperty>>[] members)
		{
			IQueryable<Brand> dbSet = context.Brands;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override Brand Activate(Brand entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Brand Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Brand Deactivate(Brand entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Brand Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Brand> GetActive()
		{
			return context.Brands;
		}
		
		public override IQueryable<Brand> GetActive(Expression<Func<Brand, bool>> expr)
		{
			return context.Brands.Where(expr);
		}
		
		public override Brand FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Brand FirstOrDefault(Expression<Func<Brand, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Brand> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Brand> FirstOrDefaultAsync(Expression<Func<Brand, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Brand SingleOrDefault(Expression<Func<Brand, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Brand> SingleOrDefaultAsync(Expression<Func<Brand, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Brand Update(Brand entity)
		{
			entity = context.Brands.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
