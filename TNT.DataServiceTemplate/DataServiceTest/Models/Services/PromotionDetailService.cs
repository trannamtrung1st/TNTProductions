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
	public partial interface IPromotionDetailService : IBaseService<PromotionDetail, PromotionDetailViewModel, int>
	{
	}
	
	public partial class PromotionDetailService : BaseService, IPromotionDetailService
	{
		private IPromotionDetailRepository repository;
		
		public PromotionDetailService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPromotionDetailRepository>(uow);
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
		public PromotionDetail Add(PromotionDetail entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<PromotionDetail> AddAsync(PromotionDetail entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public PromotionDetail Update(PromotionDetail entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<PromotionDetail> UpdateAsync(PromotionDetail entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public PromotionDetail Delete(PromotionDetail entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<PromotionDetail> DeleteAsync(PromotionDetail entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public PromotionDetail Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<PromotionDetail> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public PromotionDetail FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<PromotionDetail> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public PromotionDetail Activate(PromotionDetail entity)
		{
			return repository.Activate(entity);
		}
		
		public PromotionDetail Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public PromotionDetail Deactivate(PromotionDetail entity)
		{
			return repository.Deactivate(entity);
		}
		
		public PromotionDetail Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<PromotionDetail> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<PromotionDetail> GetActive(Expression<Func<PromotionDetail, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public PromotionDetail FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public PromotionDetail FirstOrDefault(Expression<Func<PromotionDetail, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<PromotionDetail> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<PromotionDetail> FirstOrDefaultAsync(Expression<Func<PromotionDetail, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public PromotionDetailService()
		{
			repository = G.TContainer.Resolve<IPromotionDetailRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PromotionDetailService()
		{
			Dispose(false);
		}
		#endregion
	}
}
