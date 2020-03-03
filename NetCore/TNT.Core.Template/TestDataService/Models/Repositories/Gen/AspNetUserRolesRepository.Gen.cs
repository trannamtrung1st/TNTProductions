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
	public partial interface IAspNetUserRolesRepository : IBaseRepository<AspNetUserRoles, AspNetUserRolesPK>
	{
	}
	
	public partial class AspNetUserRolesRepository : BaseRepository<AspNetUserRoles, AspNetUserRolesPK>, IAspNetUserRolesRepository
	{
		public AspNetUserRolesRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override AspNetUserRoles FindById(AspNetUserRolesPK key)
		{
			var entity = QuerySet.FirstOrDefault(
				e => e.UserId == key.UserId && e.RoleId == key.RoleId);
			return entity;
		}
		
		public override async Task<AspNetUserRoles> FindByIdAsync(AspNetUserRolesPK key)
		{
			var entity = await QuerySet.FirstOrDefaultAsync(
				e => e.UserId == key.UserId && e.RoleId == key.RoleId);
			return entity;
		}
		
		#endregion
	}
}
