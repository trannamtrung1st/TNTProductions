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
	public partial interface IImageCollectionItemService : IBaseService<ImageCollectionItem, ImageCollectionItemViewModel, int>
	{
	}
	
	public partial class ImageCollectionItemService : BaseService, IImageCollectionItemService
	{
		private IImageCollectionItemRepository repository;
		
		public ImageCollectionItemService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IImageCollectionItemRepository>(uow);
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
		public ImageCollectionItem Add(ImageCollectionItem entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<ImageCollectionItem> AddAsync(ImageCollectionItem entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public ImageCollectionItem Update(ImageCollectionItem entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<ImageCollectionItem> UpdateAsync(ImageCollectionItem entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public ImageCollectionItem Delete(ImageCollectionItem entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<ImageCollectionItem> DeleteAsync(ImageCollectionItem entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public ImageCollectionItem Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<ImageCollectionItem> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public ImageCollectionItem FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<ImageCollectionItem> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public ImageCollectionItem Activate(ImageCollectionItem entity)
		{
			return repository.Activate(entity);
		}
		
		public ImageCollectionItem Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public ImageCollectionItem Deactivate(ImageCollectionItem entity)
		{
			return repository.Deactivate(entity);
		}
		
		public ImageCollectionItem Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<ImageCollectionItem> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<ImageCollectionItem> GetActive(Expression<Func<ImageCollectionItem, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public ImageCollectionItem FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public ImageCollectionItem FirstOrDefault(Expression<Func<ImageCollectionItem, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<ImageCollectionItem> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<ImageCollectionItem> FirstOrDefaultAsync(Expression<Func<ImageCollectionItem, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public ImageCollectionItemService()
		{
			repository = G.TContainer.Resolve<IImageCollectionItemRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ImageCollectionItemService()
		{
			Dispose(false);
		}
		#endregion
	}
}
