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
	public partial interface ICustomerCashbackDetailRepository : IBaseRepository<CustomerCashbackDetail, int>
	{
	}
	
	public partial class CustomerCashbackDetailRepository : BaseRepository<CustomerCashbackDetail, int>, ICustomerCashbackDetailRepository
	{
		public CustomerCashbackDetailRepository() : base()
		{
		}
		
		public CustomerCashbackDetailRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override CustomerCashbackDetail Add(CustomerCashbackDetail entity)
		{
			
			entity = context.CustomerCashbackDetails.Add(entity);
			return entity;
		}
		
		public override CustomerCashbackDetail Remove(CustomerCashbackDetail entity)
		{
			context.CustomerCashbackDetails.Attach(entity);
			entity = context.CustomerCashbackDetails.Remove(entity);
			return entity;
		}
		
		public override CustomerCashbackDetail Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.CustomerCashbackDetails.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<CustomerCashbackDetail> RemoveIf(Expression<Func<CustomerCashbackDetail, bool>> expr)
		{
			return context.CustomerCashbackDetails.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<CustomerCashbackDetail> RemoveRange(IEnumerable<CustomerCashbackDetail> list)
		{
			return context.CustomerCashbackDetails.RemoveRange(list);
		}
		
		public override CustomerCashbackDetail FindById(int key)
		{
			var entity = context.CustomerCashbackDetails.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override CustomerCashbackDetail FindActiveById(int key)
		{
			var entity = context.CustomerCashbackDetails.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<CustomerCashbackDetail> FindByIdAsync(int key)
		{
			var entity = await context.CustomerCashbackDetails.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<CustomerCashbackDetail> FindActiveByIdAsync(int key)
		{
			var entity = await context.CustomerCashbackDetails.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override CustomerCashbackDetail FindByIdInclude<TProperty>(int key, params Expression<Func<CustomerCashbackDetail, TProperty>>[] members)
		{
			IQueryable<CustomerCashbackDetail> dbSet = context.CustomerCashbackDetails;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ID == key);
		}
		
		public override async Task<CustomerCashbackDetail> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<CustomerCashbackDetail, TProperty>>[] members)
		{
			IQueryable<CustomerCashbackDetail> dbSet = context.CustomerCashbackDetails;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
		}
		
		public override CustomerCashbackDetail Activate(CustomerCashbackDetail entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CustomerCashbackDetail Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CustomerCashbackDetail Deactivate(CustomerCashbackDetail entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CustomerCashbackDetail Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<CustomerCashbackDetail> GetActive()
		{
			return context.CustomerCashbackDetails;
		}
		
		public override IQueryable<CustomerCashbackDetail> GetActive(Expression<Func<CustomerCashbackDetail, bool>> expr)
		{
			return context.CustomerCashbackDetails.Where(expr);
		}
		
		public override CustomerCashbackDetail FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override CustomerCashbackDetail FirstOrDefault(Expression<Func<CustomerCashbackDetail, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<CustomerCashbackDetail> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<CustomerCashbackDetail> FirstOrDefaultAsync(Expression<Func<CustomerCashbackDetail, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override CustomerCashbackDetail SingleOrDefault(Expression<Func<CustomerCashbackDetail, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<CustomerCashbackDetail> SingleOrDefaultAsync(Expression<Func<CustomerCashbackDetail, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override CustomerCashbackDetail Update(CustomerCashbackDetail entity)
		{
			entity = context.CustomerCashbackDetails.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
