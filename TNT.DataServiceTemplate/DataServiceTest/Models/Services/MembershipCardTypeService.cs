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
	public partial interface IMembershipCardTypeService : IBaseService<MembershipCardType, MembershipCardTypeViewModel, int>
	{
	}
	
	public partial class MembershipCardTypeService : BaseService, IMembershipCardTypeService
	{
		private IMembershipCardTypeRepository repository;
		
		public MembershipCardTypeService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IMembershipCardTypeRepository>(uow);
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
		public MembershipCardType Add(MembershipCardType entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<MembershipCardType> AddAsync(MembershipCardType entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public MembershipCardType Update(MembershipCardType entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<MembershipCardType> UpdateAsync(MembershipCardType entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public MembershipCardType Delete(MembershipCardType entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<MembershipCardType> DeleteAsync(MembershipCardType entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public MembershipCardType Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<MembershipCardType> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public MembershipCardType FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<MembershipCardType> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public MembershipCardType Activate(MembershipCardType entity)
		{
			return repository.Activate(entity);
		}
		
		public MembershipCardType Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public MembershipCardType Deactivate(MembershipCardType entity)
		{
			return repository.Deactivate(entity);
		}
		
		public MembershipCardType Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<MembershipCardType> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<MembershipCardType> GetActive(Expression<Func<MembershipCardType, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public MembershipCardType FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public MembershipCardType FirstOrDefault(Expression<Func<MembershipCardType, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<MembershipCardType> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<MembershipCardType> FirstOrDefaultAsync(Expression<Func<MembershipCardType, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public MembershipCardTypeService()
		{
			repository = G.TContainer.Resolve<IMembershipCardTypeRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~MembershipCardTypeService()
		{
			Dispose(false);
		}
		#endregion
	}
}
