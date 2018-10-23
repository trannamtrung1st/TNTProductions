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
	public partial interface ITimeModeTypeService : IBaseService<TimeModeType, TimeModeTypeViewModel, int>
	{
	}
	
	public partial class TimeModeTypeService : BaseService, ITimeModeTypeService
	{
		private ITimeModeTypeRepository repository;
		
		public TimeModeTypeService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ITimeModeTypeRepository>(uow);
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
		public TimeModeType Add(TimeModeType entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<TimeModeType> AddAsync(TimeModeType entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public TimeModeType Update(TimeModeType entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<TimeModeType> UpdateAsync(TimeModeType entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public TimeModeType Delete(TimeModeType entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<TimeModeType> DeleteAsync(TimeModeType entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public TimeModeType Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<TimeModeType> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public TimeModeType FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<TimeModeType> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public TimeModeType Activate(TimeModeType entity)
		{
			return repository.Activate(entity);
		}
		
		public TimeModeType Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public TimeModeType Deactivate(TimeModeType entity)
		{
			return repository.Deactivate(entity);
		}
		
		public TimeModeType Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<TimeModeType> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<TimeModeType> GetActive(Expression<Func<TimeModeType, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public TimeModeType FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public TimeModeType FirstOrDefault(Expression<Func<TimeModeType, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<TimeModeType> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<TimeModeType> FirstOrDefaultAsync(Expression<Func<TimeModeType, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public TimeModeTypeService()
		{
			repository = G.TContainer.Resolve<ITimeModeTypeRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~TimeModeTypeService()
		{
			Dispose(false);
		}
		#endregion
	}
}
