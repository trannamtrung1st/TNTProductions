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
	public partial interface IPartnerMappingService : IBaseService<PartnerMapping, PartnerMappingViewModel, int>
	{
	}
	
	public partial class PartnerMappingService : BaseService, IPartnerMappingService
	{
		private IPartnerMappingRepository repository;
		
		public PartnerMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPartnerMappingRepository>(uow);
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
		public PartnerMapping Add(PartnerMapping entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<PartnerMapping> AddAsync(PartnerMapping entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public PartnerMapping Update(PartnerMapping entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<PartnerMapping> UpdateAsync(PartnerMapping entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public PartnerMapping Delete(PartnerMapping entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<PartnerMapping> DeleteAsync(PartnerMapping entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public PartnerMapping Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<PartnerMapping> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public PartnerMapping FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<PartnerMapping> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public PartnerMapping Activate(PartnerMapping entity)
		{
			return repository.Activate(entity);
		}
		
		public PartnerMapping Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public PartnerMapping Deactivate(PartnerMapping entity)
		{
			return repository.Deactivate(entity);
		}
		
		public PartnerMapping Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<PartnerMapping> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<PartnerMapping> GetActive(Expression<Func<PartnerMapping, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public PartnerMapping FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public PartnerMapping FirstOrDefault(Expression<Func<PartnerMapping, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<PartnerMapping> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<PartnerMapping> FirstOrDefaultAsync(Expression<Func<PartnerMapping, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public PartnerMappingService()
		{
			repository = G.TContainer.Resolve<IPartnerMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PartnerMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
