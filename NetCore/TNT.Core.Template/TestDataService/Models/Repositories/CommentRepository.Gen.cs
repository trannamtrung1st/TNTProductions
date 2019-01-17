using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace TestDataService.Models.Repositories
{
	public partial interface ICommentRepository : IBaseRepository<Comment, int>
	{
		Comment FindActiveById(int key);
		Task<Comment> FindActiveByIdAsync(int key);
		IQueryable<Comment> GetActive();
		IQueryable<Comment> GetActive(Expression<Func<Comment, bool>> expr);
	}
	
	public partial class CommentRepository : BaseRepository<Comment, int>, ICommentRepository
	{
		public CommentRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		public CommentRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override Comment FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Comment> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public Comment FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active == true);
			return entity;
		}
		
		public async Task<Comment> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active == true);
			return entity;
		}
		
		public IQueryable<Comment> GetActive()
		{
			return dbSet.Where(e => e.Active == true);
		}
		
		public IQueryable<Comment> GetActive(Expression<Func<Comment, bool>> expr)
		{
			return dbSet.Where(e => e.Active == true).Where(expr);
		}
		
		#endregion
	}
}
