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
	public partial interface IApplicationService : IBaseService<Application, ApplicationViewModel, System.Guid>
	{
	}
	
	public partial class ApplicationService : BaseService, IApplicationService
	{
		private IApplicationRepository repository;
		
		public ApplicationService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IApplicationRepository>(uow);
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
		public Application Add(Application entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Application> AddAsync(Application entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Application Update(Application entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Application> UpdateAsync(Application entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Application Delete(Application entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Application> DeleteAsync(Application entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Application Delete(System.Guid key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Application> DeleteAsync(System.Guid key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Application FindById(System.Guid key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Application> FindByIdAsync(System.Guid key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Application Activate(Application entity)
		{
			return repository.Activate(entity);
		}
		
		public Application Activate(System.Guid key)
		{
			return repository.Activate(key);
		}
		
		public Application Deactivate(Application entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Application Deactivate(System.Guid key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Application> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Application> GetActive(Expression<Func<Application, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Application FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Application FirstOrDefault(Expression<Func<Application, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Application> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Application> FirstOrDefaultAsync(Expression<Func<Application, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public ApplicationService()
		{
			repository = G.TContainer.Resolve<IApplicationRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ApplicationService()
		{
			Dispose(false);
		}
		#endregion
	}
}
