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
	public partial interface IDateHotelReportService : IBaseService<DateHotelReport, DateHotelReportViewModel, int>
	{
	}
	
	public partial class DateHotelReportService : BaseService, IDateHotelReportService
	{
		private IDateHotelReportRepository repository;
		
		public DateHotelReportService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IDateHotelReportRepository>(uow);
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
		public DateHotelReport Add(DateHotelReport entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<DateHotelReport> AddAsync(DateHotelReport entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public DateHotelReport Update(DateHotelReport entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<DateHotelReport> UpdateAsync(DateHotelReport entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public DateHotelReport Delete(DateHotelReport entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<DateHotelReport> DeleteAsync(DateHotelReport entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public DateHotelReport Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<DateHotelReport> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public DateHotelReport FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<DateHotelReport> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public DateHotelReport Activate(DateHotelReport entity)
		{
			return repository.Activate(entity);
		}
		
		public DateHotelReport Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public DateHotelReport Deactivate(DateHotelReport entity)
		{
			return repository.Deactivate(entity);
		}
		
		public DateHotelReport Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<DateHotelReport> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<DateHotelReport> GetActive(Expression<Func<DateHotelReport, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public DateHotelReport FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public DateHotelReport FirstOrDefault(Expression<Func<DateHotelReport, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<DateHotelReport> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<DateHotelReport> FirstOrDefaultAsync(Expression<Func<DateHotelReport, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public DateHotelReportService()
		{
			repository = G.TContainer.Resolve<IDateHotelReportRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~DateHotelReportService()
		{
			Dispose(false);
		}
		#endregion
	}
}
