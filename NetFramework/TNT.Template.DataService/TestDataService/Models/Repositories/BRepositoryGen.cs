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
	public partial interface IBRepository : IBaseRepository<B, int>
	{
	}
	
	public partial class BRepository : BaseRepository<B, int>, IBRepository
	{
		public BRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		public BRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override B FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<B> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		#endregion
	}
}
