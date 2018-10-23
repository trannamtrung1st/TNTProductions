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
	public partial interface IBlogPostCollectionItemService : IBaseService<BlogPostCollectionItem, BlogPostCollectionItemViewModel, int>
	{
	}
	
	public partial class BlogPostCollectionItemService : BaseService, IBlogPostCollectionItemService
	{
		private IBlogPostCollectionItemRepository repository;
		
		public BlogPostCollectionItemService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IBlogPostCollectionItemRepository>(uow);
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
		public BlogPostCollectionItem Add(BlogPostCollectionItem entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<BlogPostCollectionItem> AddAsync(BlogPostCollectionItem entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public BlogPostCollectionItem Update(BlogPostCollectionItem entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<BlogPostCollectionItem> UpdateAsync(BlogPostCollectionItem entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public BlogPostCollectionItem Delete(BlogPostCollectionItem entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<BlogPostCollectionItem> DeleteAsync(BlogPostCollectionItem entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public BlogPostCollectionItem Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<BlogPostCollectionItem> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public BlogPostCollectionItem FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<BlogPostCollectionItem> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public BlogPostCollectionItem Activate(BlogPostCollectionItem entity)
		{
			return repository.Activate(entity);
		}
		
		public BlogPostCollectionItem Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public BlogPostCollectionItem Deactivate(BlogPostCollectionItem entity)
		{
			return repository.Deactivate(entity);
		}
		
		public BlogPostCollectionItem Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<BlogPostCollectionItem> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<BlogPostCollectionItem> GetActive(Expression<Func<BlogPostCollectionItem, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public BlogPostCollectionItem FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public BlogPostCollectionItem FirstOrDefault(Expression<Func<BlogPostCollectionItem, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<BlogPostCollectionItem> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<BlogPostCollectionItem> FirstOrDefaultAsync(Expression<Func<BlogPostCollectionItem, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public BlogPostCollectionItemService()
		{
			repository = G.TContainer.Resolve<IBlogPostCollectionItemRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~BlogPostCollectionItemService()
		{
			Dispose(false);
		}
		#endregion
	}
}
