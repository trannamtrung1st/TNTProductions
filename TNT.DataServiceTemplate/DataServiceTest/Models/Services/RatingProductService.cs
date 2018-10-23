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
	public partial interface IRatingProductService : IBaseService<RatingProduct, RatingProductViewModel, int>
	{
	}
	
	public partial class RatingProductService : BaseService, IRatingProductService
	{
		private IRatingProductRepository repository;
		
		public RatingProductService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IRatingProductRepository>(uow);
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
		public RatingProduct Add(RatingProduct entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<RatingProduct> AddAsync(RatingProduct entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public RatingProduct Update(RatingProduct entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<RatingProduct> UpdateAsync(RatingProduct entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public RatingProduct Delete(RatingProduct entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<RatingProduct> DeleteAsync(RatingProduct entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public RatingProduct Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<RatingProduct> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public RatingProduct FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<RatingProduct> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public RatingProduct Activate(RatingProduct entity)
		{
			return repository.Activate(entity);
		}
		
		public RatingProduct Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public RatingProduct Deactivate(RatingProduct entity)
		{
			return repository.Deactivate(entity);
		}
		
		public RatingProduct Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<RatingProduct> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<RatingProduct> GetActive(Expression<Func<RatingProduct, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public RatingProduct FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public RatingProduct FirstOrDefault(Expression<Func<RatingProduct, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<RatingProduct> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<RatingProduct> FirstOrDefaultAsync(Expression<Func<RatingProduct, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public RatingProductService()
		{
			repository = G.TContainer.Resolve<IRatingProductRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~RatingProductService()
		{
			Dispose(false);
		}
		#endregion
	}
}
