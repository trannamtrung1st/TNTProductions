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
	public partial interface IDistrictService : IBaseService<District, DistrictViewModel, int>
	{
	}
	
	public partial class DistrictService : BaseService, IDistrictService
	{
		private IDistrictRepository repository;
		
		public DistrictService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IDistrictRepository>(uow);
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
		public District Add(District entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<District> AddAsync(District entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public District Update(District entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<District> UpdateAsync(District entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public District Delete(District entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<District> DeleteAsync(District entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public District Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<District> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public District FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<District> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public District Activate(District entity)
		{
			return repository.Activate(entity);
		}
		
		public District Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public District Deactivate(District entity)
		{
			return repository.Deactivate(entity);
		}
		
		public District Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<District> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<District> GetActive(Expression<Func<District, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public District FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public District FirstOrDefault(Expression<Func<District, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<District> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<District> FirstOrDefaultAsync(Expression<Func<District, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public DistrictService()
		{
			repository = G.TContainer.Resolve<IDistrictRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~DistrictService()
		{
			Dispose(false);
		}
		#endregion
	}
}
