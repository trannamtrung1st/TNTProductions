using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DataService.Models.Repositories
{
	public partial interface ITagsOfPostRepository : IBaseRepository<TagsOfPost, TagsOfPostPK>
	{
	}
	
	public partial class TagsOfPostRepository : BaseRepository<TagsOfPost, TagsOfPostPK>, ITagsOfPostRepository
	{
		public TagsOfPostRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD area
		public override TagsOfPost FindById(TagsOfPostPK key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.PostId == key.PostId && e.TagId == key.TagId);
			return entity;
		}
		
		public override async Task<TagsOfPost> FindByIdAsync(TagsOfPostPK key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.PostId == key.PostId && e.TagId == key.TagId);
			return entity;
		}
		
		#endregion
	}
}
