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
	public partial interface IAspNetUsersRepository : IBaseRepository<AspNetUsers, string>
	{
	}
	
	public partial class AspNetUsersRepository : BaseRepository<AspNetUsers, string>, IAspNetUsersRepository
	{
		public AspNetUsersRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override AspNetUsers FindById(string key)
		{
			var entity = QuerySet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<AspNetUsers> FindByIdAsync(string key)
		{
			var entity = await QuerySet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		#endregion
	}
}
