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
	public partial interface ISystemPartnerMappingService : IBaseService<SystemPartnerMapping, SystemPartnerMappingViewModel, int>
	{
	}
	
	public partial class SystemPartnerMappingService : BaseService, ISystemPartnerMappingService
	{
		private ISystemPartnerMappingRepository repository;
		
		public SystemPartnerMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ISystemPartnerMappingRepository>(uow);
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
		public SystemPartnerMapping Add(SystemPartnerMapping entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<SystemPartnerMapping> AddAsync(SystemPartnerMapping entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public SystemPartnerMapping Update(SystemPartnerMapping entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<SystemPartnerMapping> UpdateAsync(SystemPartnerMapping entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public SystemPartnerMapping Delete(SystemPartnerMapping entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<SystemPartnerMapping> DeleteAsync(SystemPartnerMapping entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public SystemPartnerMapping Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<SystemPartnerMapping> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public SystemPartnerMapping FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<SystemPartnerMapping> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public SystemPartnerMapping Activate(SystemPartnerMapping entity)
		{
			return repository.Activate(entity);
		}
		
		public SystemPartnerMapping Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public SystemPartnerMapping Deactivate(SystemPartnerMapping entity)
		{
			return repository.Deactivate(entity);
		}
		
		public SystemPartnerMapping Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<SystemPartnerMapping> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<SystemPartnerMapping> GetActive(Expression<Func<SystemPartnerMapping, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public SystemPartnerMapping FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public SystemPartnerMapping FirstOrDefault(Expression<Func<SystemPartnerMapping, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<SystemPartnerMapping> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<SystemPartnerMapping> FirstOrDefaultAsync(Expression<Func<SystemPartnerMapping, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public SystemPartnerMappingService()
		{
			repository = G.TContainer.Resolve<ISystemPartnerMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~SystemPartnerMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
