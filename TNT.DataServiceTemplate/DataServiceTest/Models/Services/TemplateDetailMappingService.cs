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
	public partial interface ITemplateDetailMappingService : IBaseService<TemplateDetailMapping, TemplateDetailMappingViewModel, int>
	{
	}
	
	public partial class TemplateDetailMappingService : BaseService, ITemplateDetailMappingService
	{
		private ITemplateDetailMappingRepository repository;
		
		public TemplateDetailMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ITemplateDetailMappingRepository>(uow);
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
		public TemplateDetailMapping Add(TemplateDetailMapping entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<TemplateDetailMapping> AddAsync(TemplateDetailMapping entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public TemplateDetailMapping Update(TemplateDetailMapping entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<TemplateDetailMapping> UpdateAsync(TemplateDetailMapping entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public TemplateDetailMapping Delete(TemplateDetailMapping entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<TemplateDetailMapping> DeleteAsync(TemplateDetailMapping entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public TemplateDetailMapping Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<TemplateDetailMapping> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public TemplateDetailMapping FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<TemplateDetailMapping> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public TemplateDetailMapping Activate(TemplateDetailMapping entity)
		{
			return repository.Activate(entity);
		}
		
		public TemplateDetailMapping Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public TemplateDetailMapping Deactivate(TemplateDetailMapping entity)
		{
			return repository.Deactivate(entity);
		}
		
		public TemplateDetailMapping Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<TemplateDetailMapping> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<TemplateDetailMapping> GetActive(Expression<Func<TemplateDetailMapping, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public TemplateDetailMapping FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public TemplateDetailMapping FirstOrDefault(Expression<Func<TemplateDetailMapping, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<TemplateDetailMapping> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<TemplateDetailMapping> FirstOrDefaultAsync(Expression<Func<TemplateDetailMapping, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public TemplateDetailMappingService()
		{
			repository = G.TContainer.Resolve<ITemplateDetailMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~TemplateDetailMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
