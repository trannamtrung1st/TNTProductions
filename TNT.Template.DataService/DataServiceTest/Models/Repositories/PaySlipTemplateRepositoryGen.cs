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
	public partial interface IPaySlipTemplateRepository : IBaseRepository<PaySlipTemplate, int>
	{
	}
	
	public partial class PaySlipTemplateRepository : BaseRepository<PaySlipTemplate, int>, IPaySlipTemplateRepository
	{
		public PaySlipTemplateRepository() : base()
		{
		}
		
		public PaySlipTemplateRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PaySlipTemplate Add(PaySlipTemplate entity)
		{
			entity.Active = true;
			entity = context.PaySlipTemplates.Add(entity);
			return entity;
		}
		
		public override PaySlipTemplate Remove(PaySlipTemplate entity)
		{
			context.PaySlipTemplates.Attach(entity);
			entity = context.PaySlipTemplates.Remove(entity);
			return entity;
		}
		
		public override PaySlipTemplate Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.PaySlipTemplates.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<PaySlipTemplate> RemoveIf(Expression<Func<PaySlipTemplate, bool>> expr)
		{
			return context.PaySlipTemplates.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<PaySlipTemplate> RemoveRange(IEnumerable<PaySlipTemplate> list)
		{
			return context.PaySlipTemplates.RemoveRange(list);
		}
		
		public override PaySlipTemplate FindById(int key)
		{
			var entity = context.PaySlipTemplates.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override PaySlipTemplate FindActiveById(int key)
		{
			var entity = context.PaySlipTemplates.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<PaySlipTemplate> FindByIdAsync(int key)
		{
			var entity = await context.PaySlipTemplates.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<PaySlipTemplate> FindActiveByIdAsync(int key)
		{
			var entity = await context.PaySlipTemplates.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override PaySlipTemplate FindByIdInclude<TProperty>(int key, params Expression<Func<PaySlipTemplate, TProperty>>[] members)
		{
			IQueryable<PaySlipTemplate> dbSet = context.PaySlipTemplates;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<PaySlipTemplate> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<PaySlipTemplate, TProperty>>[] members)
		{
			IQueryable<PaySlipTemplate> dbSet = context.PaySlipTemplates;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override PaySlipTemplate Activate(PaySlipTemplate entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override PaySlipTemplate Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override PaySlipTemplate Deactivate(PaySlipTemplate entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override PaySlipTemplate Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<PaySlipTemplate> GetActive()
		{
			return context.PaySlipTemplates.Where(e => e.Active);
		}
		
		public override IQueryable<PaySlipTemplate> GetActive(Expression<Func<PaySlipTemplate, bool>> expr)
		{
			return context.PaySlipTemplates.Where(e => e.Active).Where(expr);
		}
		
		public override PaySlipTemplate FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override PaySlipTemplate FirstOrDefault(Expression<Func<PaySlipTemplate, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<PaySlipTemplate> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<PaySlipTemplate> FirstOrDefaultAsync(Expression<Func<PaySlipTemplate, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override PaySlipTemplate SingleOrDefault(Expression<Func<PaySlipTemplate, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<PaySlipTemplate> SingleOrDefaultAsync(Expression<Func<PaySlipTemplate, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override PaySlipTemplate Update(PaySlipTemplate entity)
		{
			entity = context.PaySlipTemplates.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
