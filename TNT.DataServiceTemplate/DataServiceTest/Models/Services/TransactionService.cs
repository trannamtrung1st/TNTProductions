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
	public partial interface ITransactionService : IBaseService<Transaction, TransactionViewModel, int>
	{
	}
	
	public partial class TransactionService : BaseService, ITransactionService
	{
		private ITransactionRepository repository;
		
		public TransactionService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ITransactionRepository>(uow);
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
		public Transaction Add(Transaction entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Transaction> AddAsync(Transaction entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Transaction Update(Transaction entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Transaction> UpdateAsync(Transaction entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Transaction Delete(Transaction entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Transaction> DeleteAsync(Transaction entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Transaction Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Transaction> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Transaction FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Transaction> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Transaction Activate(Transaction entity)
		{
			return repository.Activate(entity);
		}
		
		public Transaction Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Transaction Deactivate(Transaction entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Transaction Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Transaction> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Transaction> GetActive(Expression<Func<Transaction, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Transaction FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Transaction FirstOrDefault(Expression<Func<Transaction, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Transaction> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Transaction> FirstOrDefaultAsync(Expression<Func<Transaction, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public TransactionService()
		{
			repository = G.TContainer.Resolve<ITransactionRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~TransactionService()
		{
			Dispose(false);
		}
		#endregion
	}
}
