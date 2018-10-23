using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DataServiceTest.Utilities;
using DataServiceTest.Managers;
using DataServiceTest.ViewModels;
using DataServiceTest.Models.Repositories;
using DataServiceTest.Global;
using TNT.IoContainer.Wrapper;

namespace DataServiceTest.Models.Services
{
	public partial interface IVoucherService : IBaseService<Voucher, VoucherViewModel, int>
	{
	}
	
	public partial class VoucherService : BaseService, IVoucherService
	{
		private IVoucherRepository repository;
		
		public VoucherService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IVoucherRepository>(uow);
		}
		
		public override bool AutoSave
		{
			get
			{
				return repository.AutoSave;
			}
			set
			{
				repository.AutoSave = value;
			}
		}
		
		#region CRUD Area
		public Voucher Add(Voucher entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Voucher> AddAsync(Voucher entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Voucher Update(Voucher entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Voucher> UpdateAsync(Voucher entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Voucher Delete(Voucher entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Voucher> DeleteAsync(Voucher entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Voucher Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Voucher> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Voucher FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Voucher> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Voucher Activate(Voucher entity)
		{
			return repository.Activate(entity);
		}
		
		public Voucher Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Voucher Deactivate(Voucher entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Voucher Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Voucher> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Voucher> GetActive(Expression<Func<Voucher, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Voucher FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Voucher FirstOrDefault(Expression<Func<Voucher, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Voucher> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Voucher> FirstOrDefaultAsync(Expression<Func<Voucher, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public VoucherService()
		{
			repository = G.TContainer.Resolve<IVoucherRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~VoucherService()
		{
			Dispose(false);
		}
		#endregion
	}
}
