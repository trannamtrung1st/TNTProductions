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
	public partial interface IsysdiagramService : IBaseService<sysdiagram, sysdiagramViewModel, int>
	{
	}
	
	public partial class sysdiagramService : BaseService, IsysdiagramService
	{
		private IsysdiagramRepository repository;
		
		public sysdiagramService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IsysdiagramRepository>(uow);
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
		public sysdiagram Add(sysdiagram entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<sysdiagram> AddAsync(sysdiagram entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public sysdiagram Update(sysdiagram entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<sysdiagram> UpdateAsync(sysdiagram entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public sysdiagram Delete(sysdiagram entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<sysdiagram> DeleteAsync(sysdiagram entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public sysdiagram Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<sysdiagram> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public sysdiagram FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<sysdiagram> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public sysdiagram Activate(sysdiagram entity)
		{
			return repository.Activate(entity);
		}
		
		public sysdiagram Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public sysdiagram Deactivate(sysdiagram entity)
		{
			return repository.Deactivate(entity);
		}
		
		public sysdiagram Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<sysdiagram> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<sysdiagram> GetActive(Expression<Func<sysdiagram, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public sysdiagram FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public sysdiagram FirstOrDefault(Expression<Func<sysdiagram, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<sysdiagram> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<sysdiagram> FirstOrDefaultAsync(Expression<Func<sysdiagram, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public sysdiagramService()
		{
			repository = G.TContainer.Resolve<IsysdiagramRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~sysdiagramService()
		{
			Dispose(false);
		}
		#endregion
	}
}
