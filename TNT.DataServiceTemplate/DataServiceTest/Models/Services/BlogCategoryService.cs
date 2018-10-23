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
	public partial interface IBlogCategoryService : IBaseService<BlogCategory, BlogCategoryViewModel, int>
	{
	}
	
	public partial class BlogCategoryService : BaseService, IBlogCategoryService
	{
		private IBlogCategoryRepository repository;
		
		public BlogCategoryService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IBlogCategoryRepository>(uow);
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
		public BlogCategory Add(BlogCategory entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<BlogCategory> AddAsync(BlogCategory entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public BlogCategory Update(BlogCategory entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<BlogCategory> UpdateAsync(BlogCategory entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public BlogCategory Delete(BlogCategory entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<BlogCategory> DeleteAsync(BlogCategory entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public BlogCategory Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<BlogCategory> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public BlogCategory FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<BlogCategory> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public BlogCategory Activate(BlogCategory entity)
		{
			return repository.Activate(entity);
		}
		
		public BlogCategory Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public BlogCategory Deactivate(BlogCategory entity)
		{
			return repository.Deactivate(entity);
		}
		
		public BlogCategory Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<BlogCategory> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<BlogCategory> GetActive(Expression<Func<BlogCategory, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public BlogCategory FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public BlogCategory FirstOrDefault(Expression<Func<BlogCategory, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<BlogCategory> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<BlogCategory> FirstOrDefaultAsync(Expression<Func<BlogCategory, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public BlogCategoryService()
		{
			repository = G.TContainer.Resolve<IBlogCategoryRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~BlogCategoryService()
		{
			Dispose(false);
		}
		#endregion
	}
}
