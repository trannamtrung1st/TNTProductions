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
	public partial interface IBrandService : IBaseService<Brand, BrandViewModel, int>
	{
	}
	
	public partial class BrandService : BaseService, IBrandService
	{
		private IBrandRepository repository;
		
		public BrandService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IBrandRepository>(uow);
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
		public Brand Add(Brand entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Brand> AddAsync(Brand entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Brand Update(Brand entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Brand> UpdateAsync(Brand entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Brand Delete(Brand entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Brand> DeleteAsync(Brand entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Brand Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Brand> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Brand FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Brand> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Brand Activate(Brand entity)
		{
			return repository.Activate(entity);
		}
		
		public Brand Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Brand Deactivate(Brand entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Brand Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Brand> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Brand> GetActive(Expression<Func<Brand, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Brand FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Brand FirstOrDefault(Expression<Func<Brand, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Brand> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Brand> FirstOrDefaultAsync(Expression<Func<Brand, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public BrandService()
		{
			repository = G.TContainer.Resolve<IBrandRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~BrandService()
		{
			Dispose(false);
		}
		#endregion
	}
}
