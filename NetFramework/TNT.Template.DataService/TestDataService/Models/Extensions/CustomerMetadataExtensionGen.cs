using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.ViewModels;
using TestDataService.Global;

namespace TestDataService.Models
{
	public partial class CustomerMetadataPK
	{
		public int CustomerID { get; set; }
		public string MetadataKey { get; set; }
	}
	
	public partial class CustomerMetadata : BaseEntity
	{
	}
	
}
namespace TestDataService.Models.Extensions
{
	public static partial class CustomerMetadataExtension
	{
		public static CustomerMetadata Id(this IQueryable<CustomerMetadata> query, CustomerMetadataPK key)
		{
			return query.FirstOrDefault(
				e => e.CustomerID == key.CustomerID && e.MetadataKey == key.MetadataKey);
		}
		
		public static CustomerMetadata Id(this IEnumerable<CustomerMetadata> query, CustomerMetadataPK key)
		{
			return query.FirstOrDefault(
				e => e.CustomerID == key.CustomerID && e.MetadataKey == key.MetadataKey);
		}
		
		public static IQueryable<CustomerMetadata> Active(this IQueryable<CustomerMetadata> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IQueryable<CustomerMetadata> NotActive(this IQueryable<CustomerMetadata> query)
		{
			return query.Where(e => e.Active == false);
		}
		
		public static IEnumerable<CustomerMetadata> Active(this IEnumerable<CustomerMetadata> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IEnumerable<CustomerMetadata> NotActive(this IEnumerable<CustomerMetadata> query)
		{
			return query.Where(e => e.Active == false);
		}
		
	}
}
