using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.ViewModels;
using TestDataService.Global;

namespace TestDataService.Models
{
	public partial class CustomerFilterMetadataPK
	{
		public int FilterID { get; set; }
		public string MetadataKey { get; set; }
	}
	
	public partial class CustomerFilterMetadata : BaseEntity
	{
	}
	
}
namespace TestDataService.Models.Extensions
{
	public static partial class CustomerFilterMetadataExtension
	{
		public static CustomerFilterMetadata Id(this IQueryable<CustomerFilterMetadata> query, CustomerFilterMetadataPK key)
		{
			return query.FirstOrDefault(
				e => e.FilterID == key.FilterID && e.MetadataKey == key.MetadataKey);
		}
		
		public static CustomerFilterMetadata Id(this IEnumerable<CustomerFilterMetadata> query, CustomerFilterMetadataPK key)
		{
			return query.FirstOrDefault(
				e => e.FilterID == key.FilterID && e.MetadataKey == key.MetadataKey);
		}
		
		public static IQueryable<CustomerFilterMetadata> Active(this IQueryable<CustomerFilterMetadata> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IQueryable<CustomerFilterMetadata> NotActive(this IQueryable<CustomerFilterMetadata> query)
		{
			return query.Where(e => e.Active == false);
		}
		
		public static IEnumerable<CustomerFilterMetadata> Active(this IEnumerable<CustomerFilterMetadata> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IEnumerable<CustomerFilterMetadata> NotActive(this IEnumerable<CustomerFilterMetadata> query)
		{
			return query.Where(e => e.Active == false);
		}
		
	}
}
