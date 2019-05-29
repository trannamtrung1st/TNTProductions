using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.ViewModels;
using TestDataService.Models.Entities;
using TestDataService.Global;

namespace TestDataService.Models.Entities
{
	public partial class VisionAndScopeDocsPK
	{
		public int ProjectId { get; set; }
		public int Major { get; set; }
		public int Minor { get; set; }
	}
	
	public partial class VisionAndScopeDocs : BaseEntity
	{
	}
	
}


namespace TestDataService.Models.Extensions
{
	public static partial class VisionAndScopeDocsExtension
	{
		public static VisionAndScopeDocs Id(this IQueryable<VisionAndScopeDocs> query, VisionAndScopeDocsPK key)
		{
			return query.FirstOrDefault(
				e => e.ProjectId == key.ProjectId && e.Major == key.Major && e.Minor == key.Minor);
		}
		
		public static VisionAndScopeDocs Id(this IEnumerable<VisionAndScopeDocs> query, VisionAndScopeDocsPK key)
		{
			return query.FirstOrDefault(
				e => e.ProjectId == key.ProjectId && e.Major == key.Major && e.Minor == key.Minor);
		}
		
		public static bool Existed(this IQueryable<VisionAndScopeDocs> query, VisionAndScopeDocsPK key)
		{
			return query.Any(
				e => e.ProjectId == key.ProjectId && e.Major == key.Major && e.Minor == key.Minor);
		}
		
	}
}
