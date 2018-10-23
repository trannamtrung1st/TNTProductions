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
	public partial interface IRatingStarService : IBaseService<RatingStar, RatingStarViewModel, int>
	{
	}
	
	public partial class RatingStarService : BaseService, IRatingStarService
	{
		private IRatingStarRepository repository;
		
		public RatingStarService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IRatingStarRepository>(uow);
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
		public RatingStar Add(RatingStar entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<RatingStar> AddAsync(RatingStar entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public RatingStar Update(RatingStar entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<RatingStar> UpdateAsync(RatingStar entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public RatingStar Delete(RatingStar entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<RatingStar> DeleteAsync(RatingStar entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public RatingStar Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<RatingStar> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public RatingStar FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<RatingStar> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public RatingStar Activate(RatingStar entity)
		{
			return repository.Activate(entity);
		}
		
		public RatingStar Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public RatingStar Deactivate(RatingStar entity)
		{
			return repository.Deactivate(entity);
		}
		
		public RatingStar Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<RatingStar> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<RatingStar> GetActive(Expression<Func<RatingStar, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public RatingStar FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public RatingStar FirstOrDefault(Expression<Func<RatingStar, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<RatingStar> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<RatingStar> FirstOrDefaultAsync(Expression<Func<RatingStar, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public RatingStarService()
		{
			repository = G.TContainer.Resolve<IRatingStarRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~RatingStarService()
		{
			Dispose(false);
		}
		#endregion
	}
}
