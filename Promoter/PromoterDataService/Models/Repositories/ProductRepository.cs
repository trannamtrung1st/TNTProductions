﻿using System;
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
	public partial interface IProductRepository : IBaseRepository<Product, int>
	{
	}
	
	public partial class ProductRepository : BaseRepository<Product, int>, IProductRepository
	{
		public ProductRepository() : base()
		{
		}
		
		public ProductRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Product Add(Product entity)
		{
			
			entity = context.Products.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Product> AddAsync(Product entity)
		{
			
			entity = context.Products.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Product Delete(Product entity)
		{
			context.Products.Attach(entity);
			entity = context.Products.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Product> DeleteAsync(Product entity)
		{
			context.Products.Attach(entity);
			entity = context.Products.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Product Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Products.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Product> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Products.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Product FindById(int key)
		{
			var entity = context.Products.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override Product FindActiveById(int key)
		{
			var entity = context.Products.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Product> FindByIdAsync(int key)
		{
			var entity = await context.Products.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Product> FindActiveByIdAsync(int key)
		{
			var entity = await context.Products.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override Product FindByIdInclude<TProperty>(int key, params Expression<Func<Product, TProperty>>[] members)
		{
			IQueryable<Product> dbSet = context.Products;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<Product> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Product, TProperty>>[] members)
		{
			IQueryable<Product> dbSet = context.Products;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override Product Activate(Product entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Product Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Product Deactivate(Product entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Product Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Product> GetActive()
		{
			return context.Products;
		}
		
		public override IQueryable<Product> GetActive(Expression<Func<Product, bool>> expr)
		{
			return context.Products.Where(expr);
		}
		
		public override Product FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Product FirstOrDefault(Expression<Func<Product, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Product> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Product> FirstOrDefaultAsync(Expression<Func<Product, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Product SingleOrDefault(Expression<Func<Product, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Product> SingleOrDefaultAsync(Expression<Func<Product, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Product Update(Product entity)
		{
			entity = context.Products.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Product> UpdateAsync(Product entity)
		{
			entity = context.Products.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
