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
	public partial interface IBlogPostCollectionItemMappingService : IBaseService<BlogPostCollectionItemMapping, BlogPostCollectionItemMappingViewModel, int>
	{
	}
	
	public partial class BlogPostCollectionItemMappingService : BaseService, IBlogPostCollectionItemMappingService
	{
		private IBlogPostCollectionItemMappingRepository repository;
		
		public BlogPostCollectionItemMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IBlogPostCollectionItemMappingRepository>(uow);
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
		public BlogPostCollectionItemMapping Add(BlogPostCollectionItemMapping entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<BlogPostCollectionItemMapping> AddAsync(BlogPostCollectionItemMapping entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public BlogPostCollectionItemMapping Update(BlogPostCollectionItemMapping entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<BlogPostCollectionItemMapping> UpdateAsync(BlogPostCollectionItemMapping entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public BlogPostCollectionItemMapping Delete(BlogPostCollectionItemMapping entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<BlogPostCollectionItemMapping> DeleteAsync(BlogPostCollectionItemMapping entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public BlogPostCollectionItemMapping Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<BlogPostCollectionItemMapping> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public BlogPostCollectionItemMapping FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<BlogPostCollectionItemMapping> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public BlogPostCollectionItemMapping Activate(BlogPostCollectionItemMapping entity)
		{
			return repository.Activate(entity);
		}
		
		public BlogPostCollectionItemMapping Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public BlogPostCollectionItemMapping Deactivate(BlogPostCollectionItemMapping entity)
		{
			return repository.Deactivate(entity);
		}
		
		public BlogPostCollectionItemMapping Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<BlogPostCollectionItemMapping> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<BlogPostCollectionItemMapping> GetActive(Expression<Func<BlogPostCollectionItemMapping, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public BlogPostCollectionItemMapping FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public BlogPostCollectionItemMapping FirstOrDefault(Expression<Func<BlogPostCollectionItemMapping, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<BlogPostCollectionItemMapping> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<BlogPostCollectionItemMapping> FirstOrDefaultAsync(Expression<Func<BlogPostCollectionItemMapping, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public BlogPostCollectionItemMappingService()
		{
			repository = G.TContainer.Resolve<IBlogPostCollectionItemMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~BlogPostCollectionItemMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
