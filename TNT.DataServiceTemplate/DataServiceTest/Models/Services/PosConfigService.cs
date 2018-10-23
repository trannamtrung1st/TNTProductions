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
	public partial interface IPosConfigService : IBaseService<PosConfig, PosConfigViewModel, int>
	{
	}
	
	public partial class PosConfigService : BaseService, IPosConfigService
	{
		private IPosConfigRepository repository;
		
		public PosConfigService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPosConfigRepository>(uow);
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
		public PosConfig Add(PosConfig entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<PosConfig> AddAsync(PosConfig entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public PosConfig Update(PosConfig entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<PosConfig> UpdateAsync(PosConfig entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public PosConfig Delete(PosConfig entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<PosConfig> DeleteAsync(PosConfig entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public PosConfig Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<PosConfig> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public PosConfig FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<PosConfig> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public PosConfig Activate(PosConfig entity)
		{
			return repository.Activate(entity);
		}
		
		public PosConfig Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public PosConfig Deactivate(PosConfig entity)
		{
			return repository.Deactivate(entity);
		}
		
		public PosConfig Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<PosConfig> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<PosConfig> GetActive(Expression<Func<PosConfig, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public PosConfig FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public PosConfig FirstOrDefault(Expression<Func<PosConfig, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<PosConfig> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<PosConfig> FirstOrDefaultAsync(Expression<Func<PosConfig, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public PosConfigService()
		{
			repository = G.TContainer.Resolve<IPosConfigRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PosConfigService()
		{
			Dispose(false);
		}
		#endregion
	}
}
