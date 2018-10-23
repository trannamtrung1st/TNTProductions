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
	public partial interface IImageCollectionService : IBaseService<ImageCollection, ImageCollectionViewModel, int>
	{
	}
	
	public partial class ImageCollectionService : BaseService, IImageCollectionService
	{
		private IImageCollectionRepository repository;
		
		public ImageCollectionService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IImageCollectionRepository>(uow);
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
		public ImageCollection Add(ImageCollection entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<ImageCollection> AddAsync(ImageCollection entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public ImageCollection Update(ImageCollection entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<ImageCollection> UpdateAsync(ImageCollection entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public ImageCollection Delete(ImageCollection entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<ImageCollection> DeleteAsync(ImageCollection entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public ImageCollection Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<ImageCollection> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public ImageCollection FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<ImageCollection> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public ImageCollection Activate(ImageCollection entity)
		{
			return repository.Activate(entity);
		}
		
		public ImageCollection Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public ImageCollection Deactivate(ImageCollection entity)
		{
			return repository.Deactivate(entity);
		}
		
		public ImageCollection Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<ImageCollection> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<ImageCollection> GetActive(Expression<Func<ImageCollection, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public ImageCollection FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public ImageCollection FirstOrDefault(Expression<Func<ImageCollection, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<ImageCollection> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<ImageCollection> FirstOrDefaultAsync(Expression<Func<ImageCollection, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public ImageCollectionService()
		{
			repository = G.TContainer.Resolve<IImageCollectionRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ImageCollectionService()
		{
			Dispose(false);
		}
		#endregion
	}
}
