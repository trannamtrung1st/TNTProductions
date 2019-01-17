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
	public partial interface ICommentRepository : IBaseRepository<Comment, int>
	{
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
		
		#endregion
	}
}
