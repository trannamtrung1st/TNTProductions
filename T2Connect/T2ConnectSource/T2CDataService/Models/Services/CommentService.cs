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
	public partial interface ICommentService : IBaseService<Comment, CommentViewModel, int>
	{
	}
	
	public partial class CommentService : BaseService, ICommentService
	{
		private ICommentRepository repository;
		
		public CommentService(T2CEntities context)
		{
			repository = G.TContainer.Resolve<ICommentRepository>(context);
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
		public Comment Add(Comment entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Comment> AddAsync(Comment entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Comment Update(Comment entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Comment> UpdateAsync(Comment entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Comment Delete(Comment entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Comment> DeleteAsync(Comment entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Comment Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Comment> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Comment FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Comment> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Comment Activate(Comment entity)
		{
			return repository.Activate(entity);
		}
		
		public Comment Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Comment Deactivate(Comment entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Comment Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Comment> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Comment> GetActive(Expression<Func<Comment, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Comment FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Comment FirstOrDefault(Expression<Func<Comment, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Comment> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Comment> FirstOrDefaultAsync(Expression<Func<Comment, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
	}
}
