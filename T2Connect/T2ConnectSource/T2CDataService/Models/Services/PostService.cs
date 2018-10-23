using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using T2CDataService.Utilities;
using T2CDataService.ViewModels;
using T2CDataService.Models.Repositories;
using T2CDataService.Global;
using TNT.IoContainer.Wrapper;

namespace T2CDataService.Models.Services
{
	public partial interface IPostService : IBaseService<Post, PostViewModel, int>
	{
	}
	
	public partial class PostService : BaseService, IPostService
	{
		private IPostRepository repository;
		
		public PostService(T2CEntities context)
		{
			repository = G.TContainer.Resolve<IPostRepository>(context);
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
		public Post Add(Post entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Post> AddAsync(Post entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Post Update(Post entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Post> UpdateAsync(Post entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Post Delete(Post entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Post> DeleteAsync(Post entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Post Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Post> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Post FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Post> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Post Activate(Post entity)
		{
			return repository.Activate(entity);
		}
		
		public Post Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Post Deactivate(Post entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Post Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Post> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Post> GetActive(Expression<Func<Post, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Post FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Post FirstOrDefault(Expression<Func<Post, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Post> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Post> FirstOrDefaultAsync(Expression<Func<Post, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
	}
}
