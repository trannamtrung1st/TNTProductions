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
	public partial interface IPriceGroupService : IBaseService<PriceGroup, PriceGroupViewModel, int>
	{
	}
	
	public partial class PriceGroupService : BaseService, IPriceGroupService
	{
		private IPriceGroupRepository repository;
		
		public PriceGroupService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPriceGroupRepository>(uow);
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
		public PriceGroup Add(PriceGroup entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<PriceGroup> AddAsync(PriceGroup entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public PriceGroup Update(PriceGroup entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<PriceGroup> UpdateAsync(PriceGroup entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public PriceGroup Delete(PriceGroup entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<PriceGroup> DeleteAsync(PriceGroup entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public PriceGroup Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<PriceGroup> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public PriceGroup FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<PriceGroup> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public PriceGroup Activate(PriceGroup entity)
		{
			return repository.Activate(entity);
		}
		
		public PriceGroup Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public PriceGroup Deactivate(PriceGroup entity)
		{
			return repository.Deactivate(entity);
		}
		
		public PriceGroup Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<PriceGroup> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<PriceGroup> GetActive(Expression<Func<PriceGroup, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public PriceGroup FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public PriceGroup FirstOrDefault(Expression<Func<PriceGroup, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<PriceGroup> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<PriceGroup> FirstOrDefaultAsync(Expression<Func<PriceGroup, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public PriceGroupService()
		{
			repository = G.TContainer.Resolve<IPriceGroupRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PriceGroupService()
		{
			Dispose(false);
		}
		#endregion
	}
}
