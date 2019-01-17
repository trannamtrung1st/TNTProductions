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
	public partial interface IAppUserRepository : IBaseRepository<AppUser, int>
	{
	}
	
	public partial class AppUserRepository : BaseRepository<AppUser, int>, IAppUserRepository
	{
		public AppUserRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		public AppUserRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override AppUser FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<AppUser> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		#endregion
	}
}
