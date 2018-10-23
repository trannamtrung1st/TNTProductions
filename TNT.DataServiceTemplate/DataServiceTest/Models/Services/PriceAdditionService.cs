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
	public partial interface IPriceAdditionService : IBaseService<PriceAddition, PriceAdditionViewModel, int>
	{
	}
	
	public partial class PriceAdditionService : BaseService, IPriceAdditionService
	{
		private IPriceAdditionRepository repository;
		
		public PriceAdditionService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPriceAdditionRepository>(uow);
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
		public PriceAddition Add(PriceAddition entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<PriceAddition> AddAsync(PriceAddition entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public PriceAddition Update(PriceAddition entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<PriceAddition> UpdateAsync(PriceAddition entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public PriceAddition Delete(PriceAddition entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<PriceAddition> DeleteAsync(PriceAddition entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public PriceAddition Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<PriceAddition> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public PriceAddition FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<PriceAddition> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public PriceAddition Activate(PriceAddition entity)
		{
			return repository.Activate(entity);
		}
		
		public PriceAddition Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public PriceAddition Deactivate(PriceAddition entity)
		{
			return repository.Deactivate(entity);
		}
		
		public PriceAddition Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<PriceAddition> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<PriceAddition> GetActive(Expression<Func<PriceAddition, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public PriceAddition FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public PriceAddition FirstOrDefault(Expression<Func<PriceAddition, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<PriceAddition> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<PriceAddition> FirstOrDefaultAsync(Expression<Func<PriceAddition, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public PriceAdditionService()
		{
			repository = G.TContainer.Resolve<IPriceAdditionRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PriceAdditionService()
		{
			Dispose(false);
		}
		#endregion
	}
}
