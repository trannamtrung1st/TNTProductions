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
	public partial interface IPromotionService : IBaseService<Promotion, PromotionViewModel, int>
	{
	}
	
	public partial class PromotionService : BaseService, IPromotionService
	{
		private IPromotionRepository repository;
		
		public PromotionService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPromotionRepository>(uow);
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
		public Promotion Add(Promotion entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Promotion> AddAsync(Promotion entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Promotion Update(Promotion entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Promotion> UpdateAsync(Promotion entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Promotion Delete(Promotion entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Promotion> DeleteAsync(Promotion entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Promotion Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Promotion> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Promotion FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Promotion> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Promotion Activate(Promotion entity)
		{
			return repository.Activate(entity);
		}
		
		public Promotion Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Promotion Deactivate(Promotion entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Promotion Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Promotion> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Promotion> GetActive(Expression<Func<Promotion, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Promotion FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Promotion FirstOrDefault(Expression<Func<Promotion, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Promotion> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Promotion> FirstOrDefaultAsync(Expression<Func<Promotion, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public PromotionService()
		{
			repository = G.TContainer.Resolve<IPromotionRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PromotionService()
		{
			Dispose(false);
		}
		#endregion
	}
}
