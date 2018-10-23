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
	public partial interface ILanguageService : IBaseService<Language, LanguageViewModel, int>
	{
	}
	
	public partial class LanguageService : BaseService, ILanguageService
	{
		private ILanguageRepository repository;
		
		public LanguageService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ILanguageRepository>(uow);
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
		public Language Add(Language entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Language> AddAsync(Language entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Language Update(Language entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Language> UpdateAsync(Language entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Language Delete(Language entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Language> DeleteAsync(Language entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Language Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Language> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Language FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Language> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Language Activate(Language entity)
		{
			return repository.Activate(entity);
		}
		
		public Language Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Language Deactivate(Language entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Language Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Language> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Language> GetActive(Expression<Func<Language, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Language FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Language FirstOrDefault(Expression<Func<Language, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Language> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Language> FirstOrDefaultAsync(Expression<Func<Language, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public LanguageService()
		{
			repository = G.TContainer.Resolve<ILanguageRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~LanguageService()
		{
			Dispose(false);
		}
		#endregion
	}
}
