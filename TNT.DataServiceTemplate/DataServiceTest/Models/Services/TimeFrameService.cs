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
	public partial interface ITimeFrameService : IBaseService<TimeFrame, TimeFrameViewModel, int>
	{
	}
	
	public partial class TimeFrameService : BaseService, ITimeFrameService
	{
		private ITimeFrameRepository repository;
		
		public TimeFrameService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ITimeFrameRepository>(uow);
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
		public TimeFrame Add(TimeFrame entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<TimeFrame> AddAsync(TimeFrame entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public TimeFrame Update(TimeFrame entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<TimeFrame> UpdateAsync(TimeFrame entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public TimeFrame Delete(TimeFrame entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<TimeFrame> DeleteAsync(TimeFrame entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public TimeFrame Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<TimeFrame> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public TimeFrame FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<TimeFrame> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public TimeFrame Activate(TimeFrame entity)
		{
			return repository.Activate(entity);
		}
		
		public TimeFrame Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public TimeFrame Deactivate(TimeFrame entity)
		{
			return repository.Deactivate(entity);
		}
		
		public TimeFrame Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<TimeFrame> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<TimeFrame> GetActive(Expression<Func<TimeFrame, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public TimeFrame FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public TimeFrame FirstOrDefault(Expression<Func<TimeFrame, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<TimeFrame> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<TimeFrame> FirstOrDefaultAsync(Expression<Func<TimeFrame, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public TimeFrameService()
		{
			repository = G.TContainer.Resolve<ITimeFrameRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~TimeFrameService()
		{
			Dispose(false);
		}
		#endregion
	}
}
