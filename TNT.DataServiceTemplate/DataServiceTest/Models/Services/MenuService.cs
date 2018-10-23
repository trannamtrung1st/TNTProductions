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
	public partial interface IMenuService : IBaseService<Menu, MenuViewModel, int>
	{
	}
	
	public partial class MenuService : BaseService, IMenuService
	{
		private IMenuRepository repository;
		
		public MenuService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IMenuRepository>(uow);
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
		public Menu Add(Menu entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Menu> AddAsync(Menu entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Menu Update(Menu entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Menu> UpdateAsync(Menu entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Menu Delete(Menu entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Menu> DeleteAsync(Menu entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Menu Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Menu> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Menu FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Menu> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Menu Activate(Menu entity)
		{
			return repository.Activate(entity);
		}
		
		public Menu Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Menu Deactivate(Menu entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Menu Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Menu> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Menu> GetActive(Expression<Func<Menu, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Menu FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Menu FirstOrDefault(Expression<Func<Menu, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Menu> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Menu> FirstOrDefaultAsync(Expression<Func<Menu, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public MenuService()
		{
			repository = G.TContainer.Resolve<IMenuRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~MenuService()
		{
			Dispose(false);
		}
		#endregion
	}
}
