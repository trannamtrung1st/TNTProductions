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
	public partial interface IVATOrderService : IBaseService<VATOrder, VATOrderViewModel, int>
	{
	}
	
	public partial class VATOrderService : BaseService, IVATOrderService
	{
		private IVATOrderRepository repository;
		
		public VATOrderService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IVATOrderRepository>(uow);
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
		public VATOrder Add(VATOrder entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<VATOrder> AddAsync(VATOrder entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public VATOrder Update(VATOrder entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<VATOrder> UpdateAsync(VATOrder entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public VATOrder Delete(VATOrder entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<VATOrder> DeleteAsync(VATOrder entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public VATOrder Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<VATOrder> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public VATOrder FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<VATOrder> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public VATOrder Activate(VATOrder entity)
		{
			return repository.Activate(entity);
		}
		
		public VATOrder Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public VATOrder Deactivate(VATOrder entity)
		{
			return repository.Deactivate(entity);
		}
		
		public VATOrder Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<VATOrder> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<VATOrder> GetActive(Expression<Func<VATOrder, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public VATOrder FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public VATOrder FirstOrDefault(Expression<Func<VATOrder, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<VATOrder> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<VATOrder> FirstOrDefaultAsync(Expression<Func<VATOrder, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public VATOrderService()
		{
			repository = G.TContainer.Resolve<IVATOrderRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~VATOrderService()
		{
			Dispose(false);
		}
		#endregion
	}
}
