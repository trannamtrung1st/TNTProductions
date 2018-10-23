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
	public partial interface IC_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4Service : IBaseService<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4, C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4ViewModel, System.Guid>
	{
	}
	
	public partial class C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4Service : BaseService, IC_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4Service
	{
		private IC_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4Repository repository;
		
		public C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4Service(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IC_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4Repository>(uow);
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
		public C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 Add(C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4> AddAsync(C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 Update(C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4> UpdateAsync(C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 Delete(C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4> DeleteAsync(C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 Delete(System.Guid key)
		{
			return repository.Delete(key);
		}
		
		public async Task<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4> DeleteAsync(System.Guid key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 FindById(System.Guid key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4> FindByIdAsync(System.Guid key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 Activate(C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 entity)
		{
			return repository.Activate(entity);
		}
		
		public C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 Activate(System.Guid key)
		{
			return repository.Activate(key);
		}
		
		public C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 Deactivate(C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 entity)
		{
			return repository.Deactivate(entity);
		}
		
		public C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 Deactivate(System.Guid key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4> GetActive(Expression<Func<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 FirstOrDefault(Expression<Func<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4> FirstOrDefaultAsync(Expression<Func<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4Service()
		{
			repository = G.TContainer.Resolve<IC_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4Repository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4Service()
		{
			Dispose(false);
		}
		#endregion
	}
}
