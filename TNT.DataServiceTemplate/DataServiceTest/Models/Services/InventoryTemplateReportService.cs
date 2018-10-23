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
	public partial interface IInventoryTemplateReportService : IBaseService<InventoryTemplateReport, InventoryTemplateReportViewModel, int>
	{
	}
	
	public partial class InventoryTemplateReportService : BaseService, IInventoryTemplateReportService
	{
		private IInventoryTemplateReportRepository repository;
		
		public InventoryTemplateReportService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IInventoryTemplateReportRepository>(uow);
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
		public InventoryTemplateReport Add(InventoryTemplateReport entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<InventoryTemplateReport> AddAsync(InventoryTemplateReport entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public InventoryTemplateReport Update(InventoryTemplateReport entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<InventoryTemplateReport> UpdateAsync(InventoryTemplateReport entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public InventoryTemplateReport Delete(InventoryTemplateReport entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<InventoryTemplateReport> DeleteAsync(InventoryTemplateReport entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public InventoryTemplateReport Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<InventoryTemplateReport> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public InventoryTemplateReport FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<InventoryTemplateReport> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public InventoryTemplateReport Activate(InventoryTemplateReport entity)
		{
			return repository.Activate(entity);
		}
		
		public InventoryTemplateReport Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public InventoryTemplateReport Deactivate(InventoryTemplateReport entity)
		{
			return repository.Deactivate(entity);
		}
		
		public InventoryTemplateReport Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<InventoryTemplateReport> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<InventoryTemplateReport> GetActive(Expression<Func<InventoryTemplateReport, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public InventoryTemplateReport FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public InventoryTemplateReport FirstOrDefault(Expression<Func<InventoryTemplateReport, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<InventoryTemplateReport> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<InventoryTemplateReport> FirstOrDefaultAsync(Expression<Func<InventoryTemplateReport, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public InventoryTemplateReportService()
		{
			repository = G.TContainer.Resolve<IInventoryTemplateReportRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~InventoryTemplateReportService()
		{
			Dispose(false);
		}
		#endregion
	}
}
