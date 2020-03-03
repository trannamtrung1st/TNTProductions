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
	public partial interface IAspNetUserClaimsRepository : IBaseRepository<AspNetUserClaims, int>
	{
	}
	
	public partial class AspNetUserClaimsRepository : BaseRepository<AspNetUserClaims, int>, IAspNetUserClaimsRepository
	{
		public AspNetUserClaimsRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override AspNetUserClaims FindById(int key)
		{
			var entity = QuerySet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<AspNetUserClaims> FindByIdAsync(int key)
		{
			var entity = await QuerySet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		#endregion
	}
}
