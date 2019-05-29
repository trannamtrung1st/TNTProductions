using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.Models.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace TestDataService.Models.Repositories
{
	public partial interface IAspNetRolesRepository : IBaseRepository<AspNetRoles, string>
	{
	}
	
	public partial class AspNetRolesRepository : BaseRepository<AspNetRoles, string>, IAspNetRolesRepository
	{
		public AspNetRolesRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD area
		public override AspNetRoles FindById(string key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<AspNetRoles> FindByIdAsync(string key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		#endregion
	}
}
