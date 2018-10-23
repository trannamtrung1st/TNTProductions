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
	public partial interface IAspNetUserClaimService : IBaseService<AspNetUserClaim, AspNetUserClaimViewModel, int>
	{
	}
	
	public partial class AspNetUserClaimService : BaseService, IAspNetUserClaimService
	{
		private IAspNetUserClaimRepository repository;
		
		public AspNetUserClaimService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IAspNetUserClaimRepository>(uow);
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
		public AspNetUserClaim Add(AspNetUserClaim entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<AspNetUserClaim> AddAsync(AspNetUserClaim entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public AspNetUserClaim Update(AspNetUserClaim entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<AspNetUserClaim> UpdateAsync(AspNetUserClaim entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public AspNetUserClaim Delete(AspNetUserClaim entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<AspNetUserClaim> DeleteAsync(AspNetUserClaim entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public AspNetUserClaim Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<AspNetUserClaim> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public AspNetUserClaim FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<AspNetUserClaim> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public AspNetUserClaim Activate(AspNetUserClaim entity)
		{
			return repository.Activate(entity);
		}
		
		public AspNetUserClaim Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public AspNetUserClaim Deactivate(AspNetUserClaim entity)
		{
			return repository.Deactivate(entity);
		}
		
		public AspNetUserClaim Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<AspNetUserClaim> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<AspNetUserClaim> GetActive(Expression<Func<AspNetUserClaim, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public AspNetUserClaim FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public AspNetUserClaim FirstOrDefault(Expression<Func<AspNetUserClaim, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<AspNetUserClaim> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<AspNetUserClaim> FirstOrDefaultAsync(Expression<Func<AspNetUserClaim, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public AspNetUserClaimService()
		{
			repository = G.TContainer.Resolve<IAspNetUserClaimRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~AspNetUserClaimService()
		{
			Dispose(false);
		}
		#endregion
	}
}
