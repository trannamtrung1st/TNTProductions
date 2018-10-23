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
	public partial interface IPaymentRepository : IBaseRepository<Payment, int>
	{
	}
	
	public partial class PaymentRepository : BaseRepository<Payment, int>, IPaymentRepository
	{
		public PaymentRepository() : base()
		{
		}
		
		public PaymentRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Payment Add(Payment entity)
		{
			
			entity = context.Payments.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Payment> AddAsync(Payment entity)
		{
			
			entity = context.Payments.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Payment Delete(Payment entity)
		{
			context.Payments.Attach(entity);
			entity = context.Payments.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Payment> DeleteAsync(Payment entity)
		{
			context.Payments.Attach(entity);
			entity = context.Payments.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Payment Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Payments.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Payment> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Payments.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Payment FindById(int key)
		{
			var entity = context.Payments.FirstOrDefault(
				e => e.PaymentID == key);
			return entity;
		}
		
		public override Payment FindActiveById(int key)
		{
			var entity = context.Payments.FirstOrDefault(
				e => e.PaymentID == key);
			return entity;
		}
		
		public override async Task<Payment> FindByIdAsync(int key)
		{
			var entity = await context.Payments.FirstOrDefaultAsync(
				e => e.PaymentID == key);
			return entity;
		}
		
		public override async Task<Payment> FindActiveByIdAsync(int key)
		{
			var entity = await context.Payments.FirstOrDefaultAsync(
				e => e.PaymentID == key);
			return entity;
		}
		
		public override Payment FindByIdInclude<TProperty>(int key, params Expression<Func<Payment, TProperty>>[] members)
		{
			IQueryable<Payment> dbSet = context.Payments;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.PaymentID == key);
		}
		
		public override async Task<Payment> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Payment, TProperty>>[] members)
		{
			IQueryable<Payment> dbSet = context.Payments;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.PaymentID == key);
		}
		
		public override Payment Activate(Payment entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Payment Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Payment Deactivate(Payment entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Payment Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Payment> GetActive()
		{
			return context.Payments;
		}
		
		public override IQueryable<Payment> GetActive(Expression<Func<Payment, bool>> expr)
		{
			return context.Payments.Where(expr);
		}
		
		public override Payment FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Payment FirstOrDefault(Expression<Func<Payment, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Payment> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Payment> FirstOrDefaultAsync(Expression<Func<Payment, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Payment SingleOrDefault(Expression<Func<Payment, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Payment> SingleOrDefaultAsync(Expression<Func<Payment, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Payment Update(Payment entity)
		{
			entity = context.Payments.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Payment> UpdateAsync(Payment entity)
		{
			entity = context.Payments.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
