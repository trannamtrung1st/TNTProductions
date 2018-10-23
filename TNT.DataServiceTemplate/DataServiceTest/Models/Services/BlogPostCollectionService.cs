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
	public partial interface IBlogPostCollectionService : IBaseService<BlogPostCollection, BlogPostCollectionViewModel, int>
	{
	}
	
	public partial class BlogPostCollectionService : BaseService, IBlogPostCollectionService
	{
		private IBlogPostCollectionRepository repository;
		
		public BlogPostCollectionService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IBlogPostCollectionRepository>(uow);
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
		public BlogPostCollection Add(BlogPostCollection entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<BlogPostCollection> AddAsync(BlogPostCollection entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public BlogPostCollection Update(BlogPostCollection entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<BlogPostCollection> UpdateAsync(BlogPostCollection entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public BlogPostCollection Delete(BlogPostCollection entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<BlogPostCollection> DeleteAsync(BlogPostCollection entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public BlogPostCollection Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<BlogPostCollection> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public BlogPostCollection FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<BlogPostCollection> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public BlogPostCollection Activate(BlogPostCollection entity)
		{
			return repository.Activate(entity);
		}
		
		public BlogPostCollection Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public BlogPostCollection Deactivate(BlogPostCollection entity)
		{
			return repository.Deactivate(entity);
		}
		
		public BlogPostCollection Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<BlogPostCollection> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<BlogPostCollection> GetActive(Expression<Func<BlogPostCollection, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public BlogPostCollection FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public BlogPostCollection FirstOrDefault(Expression<Func<BlogPostCollection, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<BlogPostCollection> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<BlogPostCollection> FirstOrDefaultAsync(Expression<Func<BlogPostCollection, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public BlogPostCollectionService()
		{
			repository = G.TContainer.Resolve<IBlogPostCollectionRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~BlogPostCollectionService()
		{
			Dispose(false);
		}
		#endregion
	}
}
