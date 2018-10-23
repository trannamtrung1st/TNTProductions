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
	public partial interface IProvinceService : IBaseService<Province, ProvinceViewModel, int>
	{
	}
	
	public partial class ProvinceService : BaseService, IProvinceService
	{
		private IProvinceRepository repository;
		
		public ProvinceService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProvinceRepository>(uow);
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
		public Province Add(Province entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Province> AddAsync(Province entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Province Update(Province entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Province> UpdateAsync(Province entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Province Delete(Province entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Province> DeleteAsync(Province entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Province Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Province> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Province FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Province> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Province Activate(Province entity)
		{
			return repository.Activate(entity);
		}
		
		public Province Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Province Deactivate(Province entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Province Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Province> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Province> GetActive(Expression<Func<Province, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Province FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Province FirstOrDefault(Expression<Func<Province, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Province> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Province> FirstOrDefaultAsync(Expression<Func<Province, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public ProvinceService()
		{
			repository = G.TContainer.Resolve<IProvinceRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ProvinceService()
		{
			Dispose(false);
		}
		#endregion
	}
}
