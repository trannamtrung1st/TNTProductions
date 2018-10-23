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
	public partial interface ILanguageKeyService : IBaseService<LanguageKey, LanguageKeyViewModel, int>
	{
	}
	
	public partial class LanguageKeyService : BaseService, ILanguageKeyService
	{
		private ILanguageKeyRepository repository;
		
		public LanguageKeyService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ILanguageKeyRepository>(uow);
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
		public LanguageKey Add(LanguageKey entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<LanguageKey> AddAsync(LanguageKey entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public LanguageKey Update(LanguageKey entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<LanguageKey> UpdateAsync(LanguageKey entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public LanguageKey Delete(LanguageKey entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<LanguageKey> DeleteAsync(LanguageKey entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public LanguageKey Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<LanguageKey> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public LanguageKey FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<LanguageKey> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public LanguageKey Activate(LanguageKey entity)
		{
			return repository.Activate(entity);
		}
		
		public LanguageKey Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public LanguageKey Deactivate(LanguageKey entity)
		{
			return repository.Deactivate(entity);
		}
		
		public LanguageKey Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<LanguageKey> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<LanguageKey> GetActive(Expression<Func<LanguageKey, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public LanguageKey FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public LanguageKey FirstOrDefault(Expression<Func<LanguageKey, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<LanguageKey> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<LanguageKey> FirstOrDefaultAsync(Expression<Func<LanguageKey, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public LanguageKeyService()
		{
			repository = G.TContainer.Resolve<ILanguageKeyRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~LanguageKeyService()
		{
			Dispose(false);
		}
		#endregion
	}
}
