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
	public partial interface IUserStoryAcceptanceCriteriasRepository : IBaseRepository<UserStoryAcceptanceCriterias, string>
	{
	}
	
	public partial class UserStoryAcceptanceCriteriasRepository : BaseRepository<UserStoryAcceptanceCriterias, string>, IUserStoryAcceptanceCriteriasRepository
	{
		public UserStoryAcceptanceCriteriasRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override UserStoryAcceptanceCriterias FindById(string key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<UserStoryAcceptanceCriterias> FindByIdAsync(string key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		#endregion
	}
}
