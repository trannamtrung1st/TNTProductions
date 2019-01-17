using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.Models;
using TNT.Core.IoC.Attributes;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace TestDataService.Models.Repositories
{
	public partial interface ITagsOfPostRepository : IBaseRepository<TagsOfPost, TagsOfPostPK>
	{
	}
	
	public partial class TagsOfPostRepository : BaseRepository<TagsOfPost, TagsOfPostPK>, ITagsOfPostRepository
	{
		public TagsOfPostRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		public TagsOfPostRepository(DbContext context) : base(context)
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
