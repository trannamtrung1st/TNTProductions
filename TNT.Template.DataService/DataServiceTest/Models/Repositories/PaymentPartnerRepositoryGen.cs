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
	public partial interface IPaymentPartnerRepository : IBaseRepository<PaymentPartner, int>
	{
	}
	
	public partial class PaymentPartnerRepository : BaseRepository<PaymentPartner, int>, IPaymentPartnerRepository
	{
		public PaymentPartnerRepository() : base()
		{
		}
		
		public PaymentPartnerRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PaymentPartner Add(PaymentPartner entity)
		{
			entity.Active = true;
			entity = context.PaymentPartners.Add(entity);
			return entity;
		}
		
		public override PaymentPartner Remove(PaymentPartner entity)
		{
			context.PaymentPartners.Attach(entity);
			entity = context.PaymentPartners.Remove(entity);
			return entity;
		}
		
		public override PaymentPartner Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.PaymentPartners.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<PaymentPartner> RemoveIf(Expression<Func<PaymentPartner, bool>> expr)
		{
			return context.PaymentPartners.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<PaymentPartner> RemoveRange(IEnumerable<PaymentPartner> list)
		{
			return context.PaymentPartners.RemoveRange(list);
		}
		
		public override PaymentPartner FindById(int key)
		{
			var entity = context.PaymentPartners.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override PaymentPartner FindActiveById(int key)
		{
			var entity = context.PaymentPartners.FirstOrDefault(
				e => e.ID == key && e.Active);
			return entity;
		}
		
		public override async Task<PaymentPartner> FindByIdAsync(int key)
		{
			var entity = await context.PaymentPartners.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<PaymentPartner> FindActiveByIdAsync(int key)
		{
			var entity = await context.PaymentPartners.FirstOrDefaultAsync(
				e => e.ID == key && e.Active);
			return entity;
		}
		
		public override PaymentPartner FindByIdInclude<TProperty>(int key, params Expression<Func<PaymentPartner, TProperty>>[] members)
		{
			IQueryable<PaymentPartner> dbSet = context.PaymentPartners;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ID == key);
		}
		
		public override async Task<PaymentPartner> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<PaymentPartner, TProperty>>[] members)
		{
			IQueryable<PaymentPartner> dbSet = context.PaymentPartners;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
		}
		
		public override PaymentPartner Activate(PaymentPartner entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override PaymentPartner Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override PaymentPartner Deactivate(PaymentPartner entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override PaymentPartner Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<PaymentPartner> GetActive()
		{
			return context.PaymentPartners.Where(e => e.Active);
		}
		
		public override IQueryable<PaymentPartner> GetActive(Expression<Func<PaymentPartner, bool>> expr)
		{
			return context.PaymentPartners.Where(e => e.Active).Where(expr);
		}
		
		public override PaymentPartner FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override PaymentPartner FirstOrDefault(Expression<Func<PaymentPartner, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<PaymentPartner> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<PaymentPartner> FirstOrDefaultAsync(Expression<Func<PaymentPartner, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override PaymentPartner SingleOrDefault(Expression<Func<PaymentPartner, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<PaymentPartner> SingleOrDefaultAsync(Expression<Func<PaymentPartner, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override PaymentPartner Update(PaymentPartner entity)
		{
			entity = context.PaymentPartners.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
