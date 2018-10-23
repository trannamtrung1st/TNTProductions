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
	public partial interface IBlogPostService : IBaseService<BlogPost, BlogPostViewModel, int>
	{
	}
	
	public partial class BlogPostService : BaseService, IBlogPostService
	{
		private IBlogPostRepository repository;
		
		public BlogPostService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IBlogPostRepository>(uow);
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
		public BlogPost Add(BlogPost entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<BlogPost> AddAsync(BlogPost entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public BlogPost Update(BlogPost entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<BlogPost> UpdateAsync(BlogPost entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public BlogPost Delete(BlogPost entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<BlogPost> DeleteAsync(BlogPost entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public BlogPost Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<BlogPost> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public BlogPost FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<BlogPost> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public BlogPost Activate(BlogPost entity)
		{
			return repository.Activate(entity);
		}
		
		public BlogPost Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public BlogPost Deactivate(BlogPost entity)
		{
			return repository.Deactivate(entity);
		}
		
		public BlogPost Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<BlogPost> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<BlogPost> GetActive(Expression<Func<BlogPost, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public BlogPost FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public BlogPost FirstOrDefault(Expression<Func<BlogPost, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<BlogPost> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<BlogPost> FirstOrDefaultAsync(Expression<Func<BlogPost, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public BlogPostService()
		{
			repository = G.TContainer.Resolve<IBlogPostRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~BlogPostService()
		{
			Dispose(false);
		}
		#endregion
	}
}
