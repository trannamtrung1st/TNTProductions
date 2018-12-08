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
		public PaySlipItemRepository(DbContext context) : base(context)
		{
		}
		
		public PaySlipItemRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PaySlipItem FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override PaySlipItem FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<PaySlipItem> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<PaySlipItem> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
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
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<PaySlipItem> GetActive(Expression<Func<PaySlipItem, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
