using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace TestDataService.Models.Repositories
{
	public partial interface IProductsRepository : IBaseRepository<Products, string>
	{
	}
	
	public partial class ProductsRepository : BaseRepository<Products, string>, IProductsRepository
	{
		public ProductsRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override Products FindById(string key)
		{
			var entity = QuerySet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Products> FindByIdAsync(string key)
		{
			var entity = await QuerySet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		#endregion
	}
}
