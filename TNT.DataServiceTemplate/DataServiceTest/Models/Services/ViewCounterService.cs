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
	public partial interface IViewCounterService : IBaseService<ViewCounter, ViewCounterViewModel, int>
	{
	}
	
	public partial class ViewCounterService : BaseService, IViewCounterService
	{
		private IViewCounterRepository repository;
		
		public ViewCounterService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IViewCounterRepository>(uow);
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
		public ViewCounter Add(ViewCounter entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<ViewCounter> AddAsync(ViewCounter entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public ViewCounter Update(ViewCounter entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<ViewCounter> UpdateAsync(ViewCounter entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public ViewCounter Delete(ViewCounter entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<ViewCounter> DeleteAsync(ViewCounter entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public ViewCounter Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<ViewCounter> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public ViewCounter FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<ViewCounter> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public ViewCounter Activate(ViewCounter entity)
		{
			return repository.Activate(entity);
		}
		
		public ViewCounter Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public ViewCounter Deactivate(ViewCounter entity)
		{
			return repository.Deactivate(entity);
		}
		
		public ViewCounter Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<ViewCounter> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<ViewCounter> GetActive(Expression<Func<ViewCounter, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public ViewCounter FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public ViewCounter FirstOrDefault(Expression<Func<ViewCounter, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<ViewCounter> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<ViewCounter> FirstOrDefaultAsync(Expression<Func<ViewCounter, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public ViewCounterService()
		{
			repository = G.TContainer.Resolve<IViewCounterRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ViewCounterService()
		{
			Dispose(false);
		}
		#endregion
	}
}
