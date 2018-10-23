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
	public partial interface IArticleService : IBaseService<Article, ArticleViewModel, int>
	{
	}
	
	public partial class ArticleService : BaseService, IArticleService
	{
		private IArticleRepository repository;
		
		public ArticleService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IArticleRepository>(uow);
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
		public Article Add(Article entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Article> AddAsync(Article entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Article Update(Article entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Article> UpdateAsync(Article entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Article Delete(Article entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Article> DeleteAsync(Article entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Article Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Article> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Article FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Article> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Article Activate(Article entity)
		{
			return repository.Activate(entity);
		}
		
		public Article Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Article Deactivate(Article entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Article Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Article> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Article> GetActive(Expression<Func<Article, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Article FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Article FirstOrDefault(Expression<Func<Article, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Article> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Article> FirstOrDefaultAsync(Expression<Func<Article, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public ArticleService()
		{
			repository = G.TContainer.Resolve<IArticleRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ArticleService()
		{
			Dispose(false);
		}
		#endregion
	}
}
