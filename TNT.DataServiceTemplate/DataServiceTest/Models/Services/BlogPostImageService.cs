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
	public partial interface IBlogPostImageService : IBaseService<BlogPostImage, BlogPostImageViewModel, int>
	{
	}
	
	public partial class BlogPostImageService : BaseService, IBlogPostImageService
	{
		private IBlogPostImageRepository repository;
		
		public BlogPostImageService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IBlogPostImageRepository>(uow);
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
		public BlogPostImage Add(BlogPostImage entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<BlogPostImage> AddAsync(BlogPostImage entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public BlogPostImage Update(BlogPostImage entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<BlogPostImage> UpdateAsync(BlogPostImage entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public BlogPostImage Delete(BlogPostImage entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<BlogPostImage> DeleteAsync(BlogPostImage entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public BlogPostImage Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<BlogPostImage> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public BlogPostImage FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<BlogPostImage> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public BlogPostImage Activate(BlogPostImage entity)
		{
			return repository.Activate(entity);
		}
		
		public BlogPostImage Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public BlogPostImage Deactivate(BlogPostImage entity)
		{
			return repository.Deactivate(entity);
		}
		
		public BlogPostImage Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<BlogPostImage> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<BlogPostImage> GetActive(Expression<Func<BlogPostImage, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public BlogPostImage FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public BlogPostImage FirstOrDefault(Expression<Func<BlogPostImage, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<BlogPostImage> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<BlogPostImage> FirstOrDefaultAsync(Expression<Func<BlogPostImage, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public BlogPostImageService()
		{
			repository = G.TContainer.Resolve<IBlogPostImageRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~BlogPostImageService()
		{
			Dispose(false);
		}
		#endregion
	}
}
