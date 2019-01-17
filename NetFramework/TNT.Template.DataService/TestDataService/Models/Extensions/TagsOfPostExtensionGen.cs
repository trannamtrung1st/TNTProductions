using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.ViewModels;
using TestDataService.Global;

namespace TestDataService.Models
{
	public partial class TagsOfPostPK
	{
		public int PostId { get; set; }
		public int TagId { get; set; }
	}
	
	public partial class TagsOfPost : BaseEntity
	{
	}
	
}
namespace TestDataService.Models.Extensions
{
	public static partial class TagsOfPostExtension
	{
		public static TagsOfPost Id(this IQueryable<TagsOfPost> query, TagsOfPostPK key)
		{
			return query.FirstOrDefault(
				e => e.PostId == key.PostId && e.TagId == key.TagId);
		}
		
		public static TagsOfPost Id(this IEnumerable<TagsOfPost> query, TagsOfPostPK key)
		{
			return query.FirstOrDefault(
				e => e.PostId == key.PostId && e.TagId == key.TagId);
		}
		
	}
}
