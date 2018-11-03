using System;
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
	public partial interface IVoucherRepository : IBaseRepository<Voucher, int>
	{
	}
	
	public partial class VoucherRepository : BaseRepository<Voucher, int>, IVoucherRepository
	{
		public VoucherRepository() : base()
		{
		}
		
		public VoucherRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Voucher Add(Voucher entity)
		{
			
			entity = context.Vouchers.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Voucher> AddAsync(Voucher entity)
		{
			
			entity = context.Vouchers.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Voucher Delete(Voucher entity)
		{
			context.Vouchers.Attach(entity);
			entity = context.Vouchers.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Voucher> DeleteAsync(Voucher entity)
		{
			context.Vouchers.Attach(entity);
			entity = context.Vouchers.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Voucher Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Vouchers.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Voucher> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Vouchers.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Voucher FindById(int key)
		{
			var entity = context.Vouchers.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override Voucher FindActiveById(int key)
		{
			var entity = context.Vouchers.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<Voucher> FindByIdAsync(int key)
		{
			var entity = await context.Vouchers.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<Voucher> FindActiveByIdAsync(int key)
		{
			var entity = await context.Vouchers.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override Voucher FindByIdInclude<TProperty>(int key, params Expression<Func<Voucher, TProperty>>[] members)
		{
			IQueryable<Voucher> dbSet = context.Vouchers;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ID == key);
		}
		
		public override async Task<Voucher> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Voucher, TProperty>>[] members)
		{
			IQueryable<Voucher> dbSet = context.Vouchers;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
		}
		
		public override Voucher Activate(Voucher entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Voucher Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Voucher Deactivate(Voucher entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Voucher Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Voucher> GetActive()
		{
			return context.Vouchers;
		}
		
		public override IQueryable<Voucher> GetActive(Expression<Func<Voucher, bool>> expr)
		{
			return context.Vouchers.Where(expr);
		}
		
		public override Voucher FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Voucher FirstOrDefault(Expression<Func<Voucher, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Voucher> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Voucher> FirstOrDefaultAsync(Expression<Func<Voucher, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Voucher SingleOrDefault(Expression<Func<Voucher, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Voucher> SingleOrDefaultAsync(Expression<Func<Voucher, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Voucher Update(Voucher entity)
		{
			entity = context.Vouchers.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Voucher> UpdateAsync(Voucher entity)
		{
			entity = context.Vouchers.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
