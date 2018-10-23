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
	public partial interface IVATOrderMappingService : IBaseService<VATOrderMapping, VATOrderMappingViewModel, int>
	{
	}
	
	public partial class VATOrderMappingService : BaseService, IVATOrderMappingService
	{
		private IVATOrderMappingRepository repository;
		
		public VATOrderMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IVATOrderMappingRepository>(uow);
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
		public VATOrderMapping Add(VATOrderMapping entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<VATOrderMapping> AddAsync(VATOrderMapping entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public VATOrderMapping Update(VATOrderMapping entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<VATOrderMapping> UpdateAsync(VATOrderMapping entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public VATOrderMapping Delete(VATOrderMapping entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<VATOrderMapping> DeleteAsync(VATOrderMapping entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public VATOrderMapping Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<VATOrderMapping> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public VATOrderMapping FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<VATOrderMapping> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public VATOrderMapping Activate(VATOrderMapping entity)
		{
			return repository.Activate(entity);
		}
		
		public VATOrderMapping Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public VATOrderMapping Deactivate(VATOrderMapping entity)
		{
			return repository.Deactivate(entity);
		}
		
		public VATOrderMapping Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<VATOrderMapping> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<VATOrderMapping> GetActive(Expression<Func<VATOrderMapping, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public VATOrderMapping FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public VATOrderMapping FirstOrDefault(Expression<Func<VATOrderMapping, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<VATOrderMapping> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<VATOrderMapping> FirstOrDefaultAsync(Expression<Func<VATOrderMapping, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public VATOrderMappingService()
		{
			repository = G.TContainer.Resolve<IVATOrderMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~VATOrderMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
