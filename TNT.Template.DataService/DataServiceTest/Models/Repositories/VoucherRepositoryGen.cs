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
	public partial interface IVoucherRepository : IBaseRepository<Voucher, int>
	{
	}
	
	public partial class VoucherRepository : BaseRepository<Voucher, int>, IVoucherRepository
	{
		public VoucherRepository(DbContext context) : base(context)
		{
		}
		
		public VoucherRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Voucher FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.VoucherID == key);
			return entity;
		}
		
		public override Voucher FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.VoucherID == key && e.Active);
			return entity;
		}
		
		public override async Task<Voucher> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.VoucherID == key);
			return entity;
		}
		
		public override async Task<Voucher> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.VoucherID == key && e.Active);
			return entity;
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
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<Voucher> GetActive(Expression<Func<Voucher, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
