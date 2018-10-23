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
	public partial interface ITemplateReportProductItemMappingService : IBaseService<TemplateReportProductItemMapping, TemplateReportProductItemMappingViewModel, int>
	{
	}
	
	public partial class TemplateReportProductItemMappingService : BaseService, ITemplateReportProductItemMappingService
	{
		private ITemplateReportProductItemMappingRepository repository;
		
		public TemplateReportProductItemMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ITemplateReportProductItemMappingRepository>(uow);
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
		public TemplateReportProductItemMapping Add(TemplateReportProductItemMapping entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<TemplateReportProductItemMapping> AddAsync(TemplateReportProductItemMapping entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public TemplateReportProductItemMapping Update(TemplateReportProductItemMapping entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<TemplateReportProductItemMapping> UpdateAsync(TemplateReportProductItemMapping entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public TemplateReportProductItemMapping Delete(TemplateReportProductItemMapping entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<TemplateReportProductItemMapping> DeleteAsync(TemplateReportProductItemMapping entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public TemplateReportProductItemMapping Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<TemplateReportProductItemMapping> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public TemplateReportProductItemMapping FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<TemplateReportProductItemMapping> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public TemplateReportProductItemMapping Activate(TemplateReportProductItemMapping entity)
		{
			return repository.Activate(entity);
		}
		
		public TemplateReportProductItemMapping Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public TemplateReportProductItemMapping Deactivate(TemplateReportProductItemMapping entity)
		{
			return repository.Deactivate(entity);
		}
		
		public TemplateReportProductItemMapping Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<TemplateReportProductItemMapping> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<TemplateReportProductItemMapping> GetActive(Expression<Func<TemplateReportProductItemMapping, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public TemplateReportProductItemMapping FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public TemplateReportProductItemMapping FirstOrDefault(Expression<Func<TemplateReportProductItemMapping, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<TemplateReportProductItemMapping> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<TemplateReportProductItemMapping> FirstOrDefaultAsync(Expression<Func<TemplateReportProductItemMapping, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public TemplateReportProductItemMappingService()
		{
			repository = G.TContainer.Resolve<ITemplateReportProductItemMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~TemplateReportProductItemMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
