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
	public partial interface IInventoryDateReportService : IBaseService<InventoryDateReport, InventoryDateReportViewModel, int>
	{
	}
	
	public partial class InventoryDateReportService : BaseService, IInventoryDateReportService
	{
		private IInventoryDateReportRepository repository;
		
		public InventoryDateReportService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IInventoryDateReportRepository>(uow);
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
		public InventoryDateReport Add(InventoryDateReport entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<InventoryDateReport> AddAsync(InventoryDateReport entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public InventoryDateReport Update(InventoryDateReport entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<InventoryDateReport> UpdateAsync(InventoryDateReport entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public InventoryDateReport Delete(InventoryDateReport entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<InventoryDateReport> DeleteAsync(InventoryDateReport entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public InventoryDateReport Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<InventoryDateReport> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public InventoryDateReport FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<InventoryDateReport> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public InventoryDateReport Activate(InventoryDateReport entity)
		{
			return repository.Activate(entity);
		}
		
		public InventoryDateReport Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public InventoryDateReport Deactivate(InventoryDateReport entity)
		{
			return repository.Deactivate(entity);
		}
		
		public InventoryDateReport Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<InventoryDateReport> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<InventoryDateReport> GetActive(Expression<Func<InventoryDateReport, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public InventoryDateReport FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public InventoryDateReport FirstOrDefault(Expression<Func<InventoryDateReport, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<InventoryDateReport> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<InventoryDateReport> FirstOrDefaultAsync(Expression<Func<InventoryDateReport, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public InventoryDateReportService()
		{
			repository = G.TContainer.Resolve<IInventoryDateReportRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~InventoryDateReportService()
		{
			Dispose(false);
		}
		#endregion
	}
}
