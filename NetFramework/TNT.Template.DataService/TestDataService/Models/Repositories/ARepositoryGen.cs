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
	public partial interface IARepository : IBaseRepository<A, int>
	{
	}
	
	public partial class ARepository : BaseRepository<A, int>, IARepository
	{
		public ARepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		public ARepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override A FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<A> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		#endregion
	}
}
