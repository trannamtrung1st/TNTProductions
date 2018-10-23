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
	public partial interface IFingerScanMachineService : IBaseService<FingerScanMachine, FingerScanMachineViewModel, int>
	{
	}
	
	public partial class FingerScanMachineService : BaseService, IFingerScanMachineService
	{
		private IFingerScanMachineRepository repository;
		
		public FingerScanMachineService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IFingerScanMachineRepository>(uow);
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
		public FingerScanMachine Add(FingerScanMachine entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<FingerScanMachine> AddAsync(FingerScanMachine entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public FingerScanMachine Update(FingerScanMachine entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<FingerScanMachine> UpdateAsync(FingerScanMachine entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public FingerScanMachine Delete(FingerScanMachine entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<FingerScanMachine> DeleteAsync(FingerScanMachine entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public FingerScanMachine Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<FingerScanMachine> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public FingerScanMachine FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<FingerScanMachine> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public FingerScanMachine Activate(FingerScanMachine entity)
		{
			return repository.Activate(entity);
		}
		
		public FingerScanMachine Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public FingerScanMachine Deactivate(FingerScanMachine entity)
		{
			return repository.Deactivate(entity);
		}
		
		public FingerScanMachine Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<FingerScanMachine> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<FingerScanMachine> GetActive(Expression<Func<FingerScanMachine, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public FingerScanMachine FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public FingerScanMachine FirstOrDefault(Expression<Func<FingerScanMachine, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<FingerScanMachine> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<FingerScanMachine> FirstOrDefaultAsync(Expression<Func<FingerScanMachine, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public FingerScanMachineService()
		{
			repository = G.TContainer.Resolve<IFingerScanMachineRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~FingerScanMachineService()
		{
			Dispose(false);
		}
		#endregion
	}
}
