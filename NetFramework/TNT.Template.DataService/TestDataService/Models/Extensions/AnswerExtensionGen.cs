using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.ViewModels;
using TestDataService.Global;

namespace TestDataService.Models
{
	public partial class AnswerPK
	{
		public int OfUserId { get; set; }
		public int ToPostId { get; set; }
	}
	
	public partial class Answer : BaseEntity
	{
	}
	
}
namespace TestDataService.Models.Extensions
{
	public static partial class AnswerExtension
	{
		public static Answer Id(this IQueryable<Answer> query, AnswerPK key)
		{
			return query.FirstOrDefault(
				e => e.OfUserId == key.OfUserId && e.ToPostId == key.ToPostId);
		}
		
		public static Answer Id(this IEnumerable<Answer> query, AnswerPK key)
		{
			return query.FirstOrDefault(
				e => e.OfUserId == key.OfUserId && e.ToPostId == key.ToPostId);
		}
		
		public static IQueryable<Answer> Active(this IQueryable<Answer> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IQueryable<Answer> NotActive(this IQueryable<Answer> query)
		{
			return query.Where(e => e.Active == false);
		}
		
		public static IEnumerable<Answer> Active(this IEnumerable<Answer> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IEnumerable<Answer> NotActive(this IEnumerable<Answer> query)
		{
			return query.Where(e => e.Active == false);
		}
		
	}
}
