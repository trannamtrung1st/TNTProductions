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
	public partial interface IC__MigrationHistoryService : IBaseService<C__MigrationHistory, C__MigrationHistoryViewModel, C__MigrationHistoryPK>
	{
	}
	
	public partial class C__MigrationHistoryService : BaseService, IC__MigrationHistoryService
	{
		private IC__MigrationHistoryRepository repository;
		
		public C__MigrationHistoryService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IC__MigrationHistoryRepository>(uow);
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
		public C__MigrationHistory Add(C__MigrationHistory entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<C__MigrationHistory> AddAsync(C__MigrationHistory entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public C__MigrationHistory Update(C__MigrationHistory entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<C__MigrationHistory> UpdateAsync(C__MigrationHistory entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public C__MigrationHistory Delete(C__MigrationHistory entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<C__MigrationHistory> DeleteAsync(C__MigrationHistory entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public C__MigrationHistory Delete(C__MigrationHistoryPK key)
		{
			return repository.Delete(key);
		}
		
		public async Task<C__MigrationHistory> DeleteAsync(C__MigrationHistoryPK key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public C__MigrationHistory FindById(C__MigrationHistoryPK key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<C__MigrationHistory> FindByIdAsync(C__MigrationHistoryPK key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public C__MigrationHistory Activate(C__MigrationHistory entity)
		{
			return repository.Activate(entity);
		}
		
		public C__MigrationHistory Activate(C__MigrationHistoryPK key)
		{
			return repository.Activate(key);
		}
		
		public C__MigrationHistory Deactivate(C__MigrationHistory entity)
		{
			return repository.Deactivate(entity);
		}
		
		public C__MigrationHistory Deactivate(C__MigrationHistoryPK key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<C__MigrationHistory> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<C__MigrationHistory> GetActive(Expression<Func<C__MigrationHistory, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public C__MigrationHistory FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public C__MigrationHistory FirstOrDefault(Expression<Func<C__MigrationHistory, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<C__MigrationHistory> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<C__MigrationHistory> FirstOrDefaultAsync(Expression<Func<C__MigrationHistory, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public C__MigrationHistoryService()
		{
			repository = G.TContainer.Resolve<IC__MigrationHistoryRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~C__MigrationHistoryService()
		{
			Dispose(false);
		}
		#endregion
	}
}
