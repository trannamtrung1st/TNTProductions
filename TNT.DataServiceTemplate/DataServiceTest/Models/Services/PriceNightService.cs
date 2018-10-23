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
	public partial interface IPriceNightService : IBaseService<PriceNight, PriceNightViewModel, int>
	{
	}
	
	public partial class PriceNightService : BaseService, IPriceNightService
	{
		private IPriceNightRepository repository;
		
		public PriceNightService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPriceNightRepository>(uow);
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
		public PriceNight Add(PriceNight entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<PriceNight> AddAsync(PriceNight entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public PriceNight Update(PriceNight entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<PriceNight> UpdateAsync(PriceNight entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public PriceNight Delete(PriceNight entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<PriceNight> DeleteAsync(PriceNight entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public PriceNight Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<PriceNight> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public PriceNight FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<PriceNight> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public PriceNight Activate(PriceNight entity)
		{
			return repository.Activate(entity);
		}
		
		public PriceNight Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public PriceNight Deactivate(PriceNight entity)
		{
			return repository.Deactivate(entity);
		}
		
		public PriceNight Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<PriceNight> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<PriceNight> GetActive(Expression<Func<PriceNight, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public PriceNight FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public PriceNight FirstOrDefault(Expression<Func<PriceNight, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<PriceNight> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<PriceNight> FirstOrDefaultAsync(Expression<Func<PriceNight, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public PriceNightService()
		{
			repository = G.TContainer.Resolve<IPriceNightRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PriceNightService()
		{
			Dispose(false);
		}
		#endregion
	}
}
