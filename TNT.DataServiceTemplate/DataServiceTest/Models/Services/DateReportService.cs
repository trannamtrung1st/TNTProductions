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
	public partial interface IDateReportService : IBaseService<DateReport, DateReportViewModel, int>
	{
	}
	
	public partial class DateReportService : BaseService, IDateReportService
	{
		private IDateReportRepository repository;
		
		public DateReportService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IDateReportRepository>(uow);
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
		public DateReport Add(DateReport entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<DateReport> AddAsync(DateReport entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public DateReport Update(DateReport entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<DateReport> UpdateAsync(DateReport entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public DateReport Delete(DateReport entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<DateReport> DeleteAsync(DateReport entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public DateReport Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<DateReport> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public DateReport FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<DateReport> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public DateReport Activate(DateReport entity)
		{
			return repository.Activate(entity);
		}
		
		public DateReport Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public DateReport Deactivate(DateReport entity)
		{
			return repository.Deactivate(entity);
		}
		
		public DateReport Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<DateReport> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<DateReport> GetActive(Expression<Func<DateReport, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public DateReport FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public DateReport FirstOrDefault(Expression<Func<DateReport, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<DateReport> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<DateReport> FirstOrDefaultAsync(Expression<Func<DateReport, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public DateReportService()
		{
			repository = G.TContainer.Resolve<IDateReportRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~DateReportService()
		{
			Dispose(false);
		}
		#endregion
	}
}
