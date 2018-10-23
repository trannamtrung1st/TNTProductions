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
	public partial interface ILanguageValueService : IBaseService<LanguageValue, LanguageValueViewModel, int>
	{
	}
	
	public partial class LanguageValueService : BaseService, ILanguageValueService
	{
		private ILanguageValueRepository repository;
		
		public LanguageValueService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ILanguageValueRepository>(uow);
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
		public LanguageValue Add(LanguageValue entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<LanguageValue> AddAsync(LanguageValue entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public LanguageValue Update(LanguageValue entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<LanguageValue> UpdateAsync(LanguageValue entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public LanguageValue Delete(LanguageValue entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<LanguageValue> DeleteAsync(LanguageValue entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public LanguageValue Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<LanguageValue> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public LanguageValue FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<LanguageValue> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public LanguageValue Activate(LanguageValue entity)
		{
			return repository.Activate(entity);
		}
		
		public LanguageValue Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public LanguageValue Deactivate(LanguageValue entity)
		{
			return repository.Deactivate(entity);
		}
		
		public LanguageValue Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<LanguageValue> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<LanguageValue> GetActive(Expression<Func<LanguageValue, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public LanguageValue FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public LanguageValue FirstOrDefault(Expression<Func<LanguageValue, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<LanguageValue> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<LanguageValue> FirstOrDefaultAsync(Expression<Func<LanguageValue, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public LanguageValueService()
		{
			repository = G.TContainer.Resolve<ILanguageValueRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~LanguageValueService()
		{
			Dispose(false);
		}
		#endregion
	}
}
