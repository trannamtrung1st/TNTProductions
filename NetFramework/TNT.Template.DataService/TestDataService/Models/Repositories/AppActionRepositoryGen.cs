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
	public partial interface IAppActionRepository : IBaseRepository<AppAction, int>
	{
	}
	
	public partial class AppActionRepository : BaseRepository<AppAction, int>, IAppActionRepository
	{
		public AppActionRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		public AppActionRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override AppAction FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<AppAction> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		#endregion
	}
}
