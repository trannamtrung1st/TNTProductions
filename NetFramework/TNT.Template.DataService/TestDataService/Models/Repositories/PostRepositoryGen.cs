using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.Models;
using TNT.IoC.Attributes;
using System.Linq.Expressions;
using System.Data.Entity;

namespace TestDataService.Models.Repositories
{
	public partial interface IPostRepository : IBaseRepository<Post, int>
	{
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
		
		#endregion
	}
}
