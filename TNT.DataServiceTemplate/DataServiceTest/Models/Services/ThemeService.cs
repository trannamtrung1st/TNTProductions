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
	public partial interface IThemeService : IBaseService<Theme, ThemeViewModel, int>
	{
	}
	
	public partial class ThemeService : BaseService, IThemeService
	{
		private IThemeRepository repository;
		
		public ThemeService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IThemeRepository>(uow);
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
		public Theme Add(Theme entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Theme> AddAsync(Theme entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Theme Update(Theme entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Theme> UpdateAsync(Theme entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Theme Delete(Theme entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Theme> DeleteAsync(Theme entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Theme Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Theme> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Theme FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Theme> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Theme Activate(Theme entity)
		{
			return repository.Activate(entity);
		}
		
		public Theme Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Theme Deactivate(Theme entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Theme Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Theme> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Theme> GetActive(Expression<Func<Theme, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Theme FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Theme FirstOrDefault(Expression<Func<Theme, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Theme> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Theme> FirstOrDefaultAsync(Expression<Func<Theme, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public ThemeService()
		{
			repository = G.TContainer.Resolve<IThemeRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ThemeService()
		{
			Dispose(false);
		}
		#endregion
	}
}
