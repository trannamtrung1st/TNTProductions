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
	public partial interface IPayslipAttributeRepository : IBaseRepository<PayslipAttribute, int>
	{
	}
	
	public partial class PayslipAttributeRepository : BaseRepository<PayslipAttribute, int>, IPayslipAttributeRepository
	{
		public PayslipAttributeRepository() : base()
		{
		}
		
		public PayslipAttributeRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PayslipAttribute Add(PayslipAttribute entity)
		{
			entity.Active = true;
			entity = context.PayslipAttributes.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PayslipAttribute> AddAsync(PayslipAttribute entity)
		{
			entity.Active = true;
			entity = context.PayslipAttributes.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override PayslipAttribute Delete(PayslipAttribute entity)
		{
			context.PayslipAttributes.Attach(entity);
			entity = context.PayslipAttributes.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PayslipAttribute> DeleteAsync(PayslipAttribute entity)
		{
			context.PayslipAttributes.Attach(entity);
			entity = context.PayslipAttributes.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override PayslipAttribute Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.PayslipAttributes.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PayslipAttribute> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.PayslipAttributes.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override PayslipAttribute FindById(int key)
		{
			var entity = context.PayslipAttributes.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override PayslipAttribute FindActiveById(int key)
		{
			var entity = context.PayslipAttributes.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<PayslipAttribute> FindByIdAsync(int key)
		{
			var entity = await context.PayslipAttributes.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<PayslipAttribute> FindActiveByIdAsync(int key)
		{
			var entity = await context.PayslipAttributes.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override PayslipAttribute FindByIdInclude<TProperty>(int key, params Expression<Func<PayslipAttribute, TProperty>>[] members)
		{
			IQueryable<PayslipAttribute> dbSet = context.PayslipAttributes;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<PayslipAttribute> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<PayslipAttribute, TProperty>>[] members)
		{
			IQueryable<PayslipAttribute> dbSet = context.PayslipAttributes;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override PayslipAttribute Activate(PayslipAttribute entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override PayslipAttribute Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override PayslipAttribute Deactivate(PayslipAttribute entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override PayslipAttribute Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<PayslipAttribute> GetActive()
		{
			return context.PayslipAttributes.Where(e => e.Active);
		}
		
		public override IQueryable<PayslipAttribute> GetActive(Expression<Func<PayslipAttribute, bool>> expr)
		{
			return context.PayslipAttributes.Where(e => e.Active).Where(expr);
		}
		
		public override PayslipAttribute FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override PayslipAttribute FirstOrDefault(Expression<Func<PayslipAttribute, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<PayslipAttribute> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<PayslipAttribute> FirstOrDefaultAsync(Expression<Func<PayslipAttribute, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override PayslipAttribute SingleOrDefault(Expression<Func<PayslipAttribute, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<PayslipAttribute> SingleOrDefaultAsync(Expression<Func<PayslipAttribute, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override PayslipAttribute Update(PayslipAttribute entity)
		{
			entity = context.PayslipAttributes.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PayslipAttribute> UpdateAsync(PayslipAttribute entity)
		{
			entity = context.PayslipAttributes.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
