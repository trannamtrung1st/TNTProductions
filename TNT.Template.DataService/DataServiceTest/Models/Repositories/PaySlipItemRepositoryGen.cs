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
	public partial interface IPaySlipItemRepository : IBaseRepository<PaySlipItem, int>
	{
	}
	
	public partial class PaySlipItemRepository : BaseRepository<PaySlipItem, int>, IPaySlipItemRepository
	{
		public PaySlipItemRepository() : base()
		{
		}
		
		public PaySlipItemRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PaySlipItem Add(PaySlipItem entity)
		{
			entity.Active = true;
			entity = context.PaySlipItems.Add(entity);
			return entity;
		}
		
		public override PaySlipItem Remove(PaySlipItem entity)
		{
			context.PaySlipItems.Attach(entity);
			entity = context.PaySlipItems.Remove(entity);
			return entity;
		}
		
		public override PaySlipItem Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.PaySlipItems.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<PaySlipItem> RemoveIf(Expression<Func<PaySlipItem, bool>> expr)
		{
			return context.PaySlipItems.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<PaySlipItem> RemoveRange(IEnumerable<PaySlipItem> list)
		{
			return context.PaySlipItems.RemoveRange(list);
		}
		
		public override PaySlipItem FindById(int key)
		{
			var entity = context.PaySlipItems.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override PaySlipItem FindActiveById(int key)
		{
			var entity = context.PaySlipItems.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<PaySlipItem> FindByIdAsync(int key)
		{
			var entity = await context.PaySlipItems.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<PaySlipItem> FindActiveByIdAsync(int key)
		{
			var entity = await context.PaySlipItems.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override PaySlipItem FindByIdInclude<TProperty>(int key, params Expression<Func<PaySlipItem, TProperty>>[] members)
		{
			IQueryable<PaySlipItem> dbSet = context.PaySlipItems;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<PaySlipItem> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<PaySlipItem, TProperty>>[] members)
		{
			IQueryable<PaySlipItem> dbSet = context.PaySlipItems;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override PaySlipItem Activate(PaySlipItem entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override PaySlipItem Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override PaySlipItem Deactivate(PaySlipItem entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override PaySlipItem Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<PaySlipItem> GetActive()
		{
			return context.PaySlipItems.Where(e => e.Active);
		}
		
		public override IQueryable<PaySlipItem> GetActive(Expression<Func<PaySlipItem, bool>> expr)
		{
			return context.PaySlipItems.Where(e => e.Active).Where(expr);
		}
		
		public override PaySlipItem FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override PaySlipItem FirstOrDefault(Expression<Func<PaySlipItem, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<PaySlipItem> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<PaySlipItem> FirstOrDefaultAsync(Expression<Func<PaySlipItem, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override PaySlipItem SingleOrDefault(Expression<Func<PaySlipItem, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<PaySlipItem> SingleOrDefaultAsync(Expression<Func<PaySlipItem, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override PaySlipItem Update(PaySlipItem entity)
		{
			entity = context.PaySlipItems.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
