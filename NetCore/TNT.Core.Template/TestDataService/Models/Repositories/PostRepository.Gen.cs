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
	public partial interface IPostRepository : IBaseRepository<Post, int>
	{
		Post FindActiveById(int key);
		Task<Post> FindActiveByIdAsync(int key);
		IQueryable<Post> GetActive();
		IQueryable<Post> GetActive(Expression<Func<Post, bool>> expr);
	}
	
	public partial class PostRepository : BaseRepository<Post, int>, IPostRepository
	{
		public PostRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		public PostRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override Post FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Post> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public Post FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active == true);
			return entity;
		}
		
		public async Task<Post> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active == true);
			return entity;
		}
		
		public IQueryable<Post> GetActive()
		{
			return dbSet.Where(e => e.Active == true);
		}
		
		public IQueryable<Post> GetActive(Expression<Func<Post, bool>> expr)
		{
			return dbSet.Where(e => e.Active == true).Where(expr);
		}
		
		#endregion
	}
}
