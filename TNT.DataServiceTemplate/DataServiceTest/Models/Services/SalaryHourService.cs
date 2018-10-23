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
	public partial interface ISalaryHourService : IBaseService<SalaryHour, SalaryHourViewModel, int>
	{
	}
	
	public partial class SalaryHourService : BaseService, ISalaryHourService
	{
		private ISalaryHourRepository repository;
		
		public SalaryHourService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ISalaryHourRepository>(uow);
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
		public SalaryHour Add(SalaryHour entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<SalaryHour> AddAsync(SalaryHour entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public SalaryHour Update(SalaryHour entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<SalaryHour> UpdateAsync(SalaryHour entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public SalaryHour Delete(SalaryHour entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<SalaryHour> DeleteAsync(SalaryHour entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public SalaryHour Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<SalaryHour> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public SalaryHour FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<SalaryHour> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public SalaryHour Activate(SalaryHour entity)
		{
			return repository.Activate(entity);
		}
		
		public SalaryHour Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public SalaryHour Deactivate(SalaryHour entity)
		{
			return repository.Deactivate(entity);
		}
		
		public SalaryHour Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<SalaryHour> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<SalaryHour> GetActive(Expression<Func<SalaryHour, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public SalaryHour FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public SalaryHour FirstOrDefault(Expression<Func<SalaryHour, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<SalaryHour> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<SalaryHour> FirstOrDefaultAsync(Expression<Func<SalaryHour, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public SalaryHourService()
		{
			repository = G.TContainer.Resolve<ISalaryHourRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~SalaryHourService()
		{
			Dispose(false);
		}
		#endregion
	}
}
