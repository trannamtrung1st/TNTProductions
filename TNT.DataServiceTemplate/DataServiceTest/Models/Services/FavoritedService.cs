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
	public partial interface IFavoritedService : IBaseService<Favorited, FavoritedViewModel, int>
	{
	}
	
	public partial class FavoritedService : BaseService, IFavoritedService
	{
		private IFavoritedRepository repository;
		
		public FavoritedService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IFavoritedRepository>(uow);
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
		public Favorited Add(Favorited entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Favorited> AddAsync(Favorited entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Favorited Update(Favorited entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Favorited> UpdateAsync(Favorited entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Favorited Delete(Favorited entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Favorited> DeleteAsync(Favorited entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Favorited Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Favorited> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Favorited FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Favorited> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Favorited Activate(Favorited entity)
		{
			return repository.Activate(entity);
		}
		
		public Favorited Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Favorited Deactivate(Favorited entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Favorited Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Favorited> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Favorited> GetActive(Expression<Func<Favorited, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Favorited FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Favorited FirstOrDefault(Expression<Func<Favorited, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Favorited> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Favorited> FirstOrDefaultAsync(Expression<Func<Favorited, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public FavoritedService()
		{
			repository = G.TContainer.Resolve<IFavoritedRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~FavoritedService()
		{
			Dispose(false);
		}
		#endregion
	}
}
