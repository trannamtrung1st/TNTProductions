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
	public partial interface IMachineConnectService : IBaseService<MachineConnect, MachineConnectViewModel, int>
	{
	}
	
	public partial class MachineConnectService : BaseService, IMachineConnectService
	{
		private IMachineConnectRepository repository;
		
		public MachineConnectService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IMachineConnectRepository>(uow);
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
		public MachineConnect Add(MachineConnect entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<MachineConnect> AddAsync(MachineConnect entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public MachineConnect Update(MachineConnect entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<MachineConnect> UpdateAsync(MachineConnect entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public MachineConnect Delete(MachineConnect entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<MachineConnect> DeleteAsync(MachineConnect entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public MachineConnect Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<MachineConnect> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public MachineConnect FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<MachineConnect> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public MachineConnect Activate(MachineConnect entity)
		{
			return repository.Activate(entity);
		}
		
		public MachineConnect Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public MachineConnect Deactivate(MachineConnect entity)
		{
			return repository.Deactivate(entity);
		}
		
		public MachineConnect Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<MachineConnect> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<MachineConnect> GetActive(Expression<Func<MachineConnect, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public MachineConnect FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public MachineConnect FirstOrDefault(Expression<Func<MachineConnect, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<MachineConnect> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<MachineConnect> FirstOrDefaultAsync(Expression<Func<MachineConnect, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public MachineConnectService()
		{
			repository = G.TContainer.Resolve<IMachineConnectRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~MachineConnectService()
		{
			Dispose(false);
		}
		#endregion
	}
}
