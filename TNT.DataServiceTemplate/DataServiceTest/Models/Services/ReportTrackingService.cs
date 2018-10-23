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
	public partial interface IReportTrackingService : IBaseService<ReportTracking, ReportTrackingViewModel, int>
	{
	}
	
	public partial class ReportTrackingService : BaseService, IReportTrackingService
	{
		private IReportTrackingRepository repository;
		
		public ReportTrackingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IReportTrackingRepository>(uow);
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
		public ReportTracking Add(ReportTracking entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<ReportTracking> AddAsync(ReportTracking entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public ReportTracking Update(ReportTracking entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<ReportTracking> UpdateAsync(ReportTracking entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public ReportTracking Delete(ReportTracking entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<ReportTracking> DeleteAsync(ReportTracking entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public ReportTracking Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<ReportTracking> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public ReportTracking FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<ReportTracking> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public ReportTracking Activate(ReportTracking entity)
		{
			return repository.Activate(entity);
		}
		
		public ReportTracking Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public ReportTracking Deactivate(ReportTracking entity)
		{
			return repository.Deactivate(entity);
		}
		
		public ReportTracking Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<ReportTracking> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<ReportTracking> GetActive(Expression<Func<ReportTracking, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public ReportTracking FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public ReportTracking FirstOrDefault(Expression<Func<ReportTracking, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<ReportTracking> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<ReportTracking> FirstOrDefaultAsync(Expression<Func<ReportTracking, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public ReportTrackingService()
		{
			repository = G.TContainer.Resolve<IReportTrackingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ReportTrackingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
