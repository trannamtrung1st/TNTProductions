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
	public partial interface IWardService : IBaseService<Ward, WardViewModel, int>
	{
	}
	
	public partial class WardService : BaseService, IWardService
	{
		private IWardRepository repository;
		
		public WardService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IWardRepository>(uow);
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
		public Ward Add(Ward entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Ward> AddAsync(Ward entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Ward Update(Ward entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Ward> UpdateAsync(Ward entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Ward Delete(Ward entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Ward> DeleteAsync(Ward entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Ward Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Ward> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Ward FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Ward> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Ward Activate(Ward entity)
		{
			return repository.Activate(entity);
		}
		
		public Ward Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Ward Deactivate(Ward entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Ward Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Ward> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Ward> GetActive(Expression<Func<Ward, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Ward FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Ward FirstOrDefault(Expression<Func<Ward, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Ward> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Ward> FirstOrDefaultAsync(Expression<Func<Ward, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public WardService()
		{
			repository = G.TContainer.Resolve<IWardRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~WardService()
		{
			Dispose(false);
		}
		#endregion
	}
}
