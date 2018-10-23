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
	public partial interface IPartnerService : IBaseService<Partner, PartnerViewModel, int>
	{
	}
	
	public partial class PartnerService : BaseService, IPartnerService
	{
		private IPartnerRepository repository;
		
		public PartnerService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPartnerRepository>(uow);
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
		public Partner Add(Partner entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Partner> AddAsync(Partner entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Partner Update(Partner entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Partner> UpdateAsync(Partner entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Partner Delete(Partner entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Partner> DeleteAsync(Partner entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Partner Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Partner> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Partner FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Partner> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Partner Activate(Partner entity)
		{
			return repository.Activate(entity);
		}
		
		public Partner Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Partner Deactivate(Partner entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Partner Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Partner> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Partner> GetActive(Expression<Func<Partner, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Partner FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Partner FirstOrDefault(Expression<Func<Partner, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Partner> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Partner> FirstOrDefaultAsync(Expression<Func<Partner, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public PartnerService()
		{
			repository = G.TContainer.Resolve<IPartnerRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PartnerService()
		{
			Dispose(false);
		}
		#endregion
	}
}
