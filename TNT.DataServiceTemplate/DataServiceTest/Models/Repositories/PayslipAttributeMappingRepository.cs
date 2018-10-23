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
	public partial interface IPayslipAttributeMappingRepository : IBaseRepository<PayslipAttributeMapping, int>
	{
	}
	
	public partial class PayslipAttributeMappingRepository : BaseRepository<PayslipAttributeMapping, int>, IPayslipAttributeMappingRepository
	{
		public PayslipAttributeMappingRepository() : base()
		{
		}
		
		public PayslipAttributeMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PayslipAttributeMapping Add(PayslipAttributeMapping entity)
		{
			entity.Active = true;
			entity = context.PayslipAttributeMappings.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PayslipAttributeMapping> AddAsync(PayslipAttributeMapping entity)
		{
			entity.Active = true;
			entity = context.PayslipAttributeMappings.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override PayslipAttributeMapping Delete(PayslipAttributeMapping entity)
		{
			context.PayslipAttributeMappings.Attach(entity);
			entity = context.PayslipAttributeMappings.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PayslipAttributeMapping> DeleteAsync(PayslipAttributeMapping entity)
		{
			context.PayslipAttributeMappings.Attach(entity);
			entity = context.PayslipAttributeMappings.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override PayslipAttributeMapping Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.PayslipAttributeMappings.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PayslipAttributeMapping> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.PayslipAttributeMappings.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override PayslipAttributeMapping FindById(int key)
		{
			var entity = context.PayslipAttributeMappings.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override PayslipAttributeMapping FindActiveById(int key)
		{
			var entity = context.PayslipAttributeMappings.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<PayslipAttributeMapping> FindByIdAsync(int key)
		{
			var entity = await context.PayslipAttributeMappings.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<PayslipAttributeMapping> FindActiveByIdAsync(int key)
		{
			var entity = await context.PayslipAttributeMappings.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override PayslipAttributeMapping FindByIdInclude<TProperty>(int key, params Expression<Func<PayslipAttributeMapping, TProperty>>[] members)
		{
			IQueryable<PayslipAttributeMapping> dbSet = context.PayslipAttributeMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<PayslipAttributeMapping> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<PayslipAttributeMapping, TProperty>>[] members)
		{
			IQueryable<PayslipAttributeMapping> dbSet = context.PayslipAttributeMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override PayslipAttributeMapping Activate(PayslipAttributeMapping entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override PayslipAttributeMapping Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override PayslipAttributeMapping Deactivate(PayslipAttributeMapping entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override PayslipAttributeMapping Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<PayslipAttributeMapping> GetActive()
		{
			return context.PayslipAttributeMappings.Where(e => e.Active);
		}
		
		public override IQueryable<PayslipAttributeMapping> GetActive(Expression<Func<PayslipAttributeMapping, bool>> expr)
		{
			return context.PayslipAttributeMappings.Where(e => e.Active).Where(expr);
		}
		
		public override PayslipAttributeMapping FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override PayslipAttributeMapping FirstOrDefault(Expression<Func<PayslipAttributeMapping, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<PayslipAttributeMapping> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<PayslipAttributeMapping> FirstOrDefaultAsync(Expression<Func<PayslipAttributeMapping, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override PayslipAttributeMapping SingleOrDefault(Expression<Func<PayslipAttributeMapping, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<PayslipAttributeMapping> SingleOrDefaultAsync(Expression<Func<PayslipAttributeMapping, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override PayslipAttributeMapping Update(PayslipAttributeMapping entity)
		{
			entity = context.PayslipAttributeMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PayslipAttributeMapping> UpdateAsync(PayslipAttributeMapping entity)
		{
			entity = context.PayslipAttributeMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
