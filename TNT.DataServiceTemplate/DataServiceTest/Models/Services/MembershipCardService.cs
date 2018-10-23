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
	public partial interface IMembershipCardService : IBaseService<MembershipCard, MembershipCardViewModel, int>
	{
	}
	
	public partial class MembershipCardService : BaseService, IMembershipCardService
	{
		private IMembershipCardRepository repository;
		
		public MembershipCardService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IMembershipCardRepository>(uow);
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
		public MembershipCard Add(MembershipCard entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<MembershipCard> AddAsync(MembershipCard entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public MembershipCard Update(MembershipCard entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<MembershipCard> UpdateAsync(MembershipCard entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public MembershipCard Delete(MembershipCard entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<MembershipCard> DeleteAsync(MembershipCard entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public MembershipCard Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<MembershipCard> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public MembershipCard FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<MembershipCard> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public MembershipCard Activate(MembershipCard entity)
		{
			return repository.Activate(entity);
		}
		
		public MembershipCard Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public MembershipCard Deactivate(MembershipCard entity)
		{
			return repository.Deactivate(entity);
		}
		
		public MembershipCard Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<MembershipCard> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<MembershipCard> GetActive(Expression<Func<MembershipCard, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public MembershipCard FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public MembershipCard FirstOrDefault(Expression<Func<MembershipCard, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<MembershipCard> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<MembershipCard> FirstOrDefaultAsync(Expression<Func<MembershipCard, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public MembershipCardService()
		{
			repository = G.TContainer.Resolve<IMembershipCardRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~MembershipCardService()
		{
			Dispose(false);
		}
		#endregion
	}
}
