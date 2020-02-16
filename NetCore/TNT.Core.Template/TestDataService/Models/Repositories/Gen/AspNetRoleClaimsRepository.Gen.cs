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
	public partial interface IAspNetRoleClaimsRepository : IBaseRepository<AspNetRoleClaims, int>
	{
	}
	
	public partial class AspNetRoleClaimsRepository : BaseRepository<AspNetRoleClaims, int>, IAspNetRoleClaimsRepository
	{
		public AspNetRoleClaimsRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override AspNetRoleClaims FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<AspNetRoleClaims> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		#endregion
	}
}
