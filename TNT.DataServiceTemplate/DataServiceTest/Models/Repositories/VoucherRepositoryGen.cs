﻿using System;
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
			entity.Active = true;
			entity = context.Vouchers.Add(entity);
			return entity;
		}
		
		public override Voucher Remove(Voucher entity)
		{
			context.Vouchers.Attach(entity);
			entity = context.Vouchers.Remove(entity);
			return entity;
		}
		
		public override Voucher Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Vouchers.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<Voucher> RemoveIf(Expression<Func<Voucher, bool>> expr)
		{
			return context.Vouchers.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<Voucher> RemoveRange(IEnumerable<Voucher> list)
		{
			return context.Vouchers.RemoveRange(list);
		}
		
		public override Voucher FindById(int key)
		{
			var entity = context.Vouchers.FirstOrDefault(
				e => e.VoucherID == key);
			return entity;
		}
		
		public override Voucher FindActiveById(int key)
		{
			var entity = context.Vouchers.FirstOrDefault(
				e => e.VoucherID == key && e.Active);
			return entity;
		}
		
		public override async Task<Voucher> FindByIdAsync(int key)
		{
			var entity = await context.Vouchers.FirstOrDefaultAsync(
				e => e.VoucherID == key);
			return entity;
		}
		
		public override async Task<Voucher> FindActiveByIdAsync(int key)
		{
			var entity = await context.Vouchers.FirstOrDefaultAsync(
				e => e.VoucherID == key && e.Active);
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
				e => e.VoucherID == key);
		}
		
		public override async Task<Voucher> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Voucher, TProperty>>[] members)
		{
			IQueryable<Voucher> dbSet = context.Vouchers;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.VoucherID == key);
		}
		
		public override Voucher Activate(Voucher entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override Voucher Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override Voucher Deactivate(Voucher entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override Voucher Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<Voucher> GetActive()
		{
			return context.Vouchers.Where(e => e.Active);
		}
		
		public override IQueryable<Voucher> GetActive(Expression<Func<Voucher, bool>> expr)
		{
			return context.Vouchers.Where(e => e.Active).Where(expr);
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
			return entity;
		}
		#endregion
		
	}
}