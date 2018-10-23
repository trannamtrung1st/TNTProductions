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
	public partial interface IDayModeService : IBaseService<DayMode, DayModeViewModel, int>
	{
	}
	
	public partial class DayModeService : BaseService, IDayModeService
	{
		private IDayModeRepository repository;
		
		public DayModeService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IDayModeRepository>(uow);
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
		public DayMode Add(DayMode entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<DayMode> AddAsync(DayMode entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public DayMode Update(DayMode entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<DayMode> UpdateAsync(DayMode entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public DayMode Delete(DayMode entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<DayMode> DeleteAsync(DayMode entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public DayMode Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<DayMode> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public DayMode FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<DayMode> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public DayMode Activate(DayMode entity)
		{
			return repository.Activate(entity);
		}
		
		public DayMode Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public DayMode Deactivate(DayMode entity)
		{
			return repository.Deactivate(entity);
		}
		
		public DayMode Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<DayMode> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<DayMode> GetActive(Expression<Func<DayMode, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public DayMode FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public DayMode FirstOrDefault(Expression<Func<DayMode, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<DayMode> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<DayMode> FirstOrDefaultAsync(Expression<Func<DayMode, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public DayModeService()
		{
			repository = G.TContainer.Resolve<IDayModeRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~DayModeService()
		{
			Dispose(false);
		}
		#endregion
	}
}
