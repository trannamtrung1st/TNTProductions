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
	public partial interface ICustomerMetadataRepository : IBaseRepository<CustomerMetadata, CustomerMetadataPK>
	{
	}
	
	public partial class CustomerMetadataRepository : BaseRepository<CustomerMetadata, CustomerMetadataPK>, ICustomerMetadataRepository
	{
		public CustomerMetadataRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		public CustomerMetadataRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override CustomerMetadata FindById(CustomerMetadataPK key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.CustomerID == key.CustomerID && e.MetadataKey == key.MetadataKey);
			return entity;
		}
		
		public override async Task<CustomerMetadata> FindByIdAsync(CustomerMetadataPK key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.CustomerID == key.CustomerID && e.MetadataKey == key.MetadataKey);
			return entity;
		}
		
		#endregion
	}
}
