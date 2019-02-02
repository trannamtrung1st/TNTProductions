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
	public partial interface ICustomerFilterMetadataRepository : IBaseRepository<CustomerFilterMetadata, CustomerFilterMetadataPK>
	{
	}
	
	public partial class CustomerFilterMetadataRepository : BaseRepository<CustomerFilterMetadata, CustomerFilterMetadataPK>, ICustomerFilterMetadataRepository
	{
		public CustomerFilterMetadataRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		public CustomerFilterMetadataRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override CustomerFilterMetadata FindById(CustomerFilterMetadataPK key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.FilterID == key.FilterID && e.MetadataKey == key.MetadataKey);
			return entity;
		}
		
		public override async Task<CustomerFilterMetadata> FindByIdAsync(CustomerFilterMetadataPK key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.FilterID == key.FilterID && e.MetadataKey == key.MetadataKey);
			return entity;
		}
		
		#endregion
	}
}
