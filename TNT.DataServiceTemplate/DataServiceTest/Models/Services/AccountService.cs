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
	public partial interface IAccountService : IBaseService<Account, AccountViewModel, int>
	{
	}
	
	public partial class AccountService : BaseService, IAccountService
	{
		private IAccountRepository repository;
		
		public AccountService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IAccountRepository>(uow);
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
		public Account Add(Account entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Account> AddAsync(Account entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Account Update(Account entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Account> UpdateAsync(Account entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Account Delete(Account entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Account> DeleteAsync(Account entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Account Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Account> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Account FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Account> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Account Activate(Account entity)
		{
			return repository.Activate(entity);
		}
		
		public Account Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Account Deactivate(Account entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Account Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Account> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Account> GetActive(Expression<Func<Account, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Account FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Account FirstOrDefault(Expression<Func<Account, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Account> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Account> FirstOrDefaultAsync(Expression<Func<Account, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public AccountService()
		{
			repository = G.TContainer.Resolve<IAccountRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~AccountService()
		{
			Dispose(false);
		}
		#endregion
	}
}
