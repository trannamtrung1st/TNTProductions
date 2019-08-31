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
	public partial interface IUserStoryRequirementsRepository : IBaseRepository<UserStoryRequirements, string>
	{
	}
	
	public partial class UserStoryRequirementsRepository : BaseRepository<UserStoryRequirements, string>, IUserStoryRequirementsRepository
	{
		public UserStoryRequirementsRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override UserStoryRequirements FindById(string key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<UserStoryRequirements> FindByIdAsync(string key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		#endregion
	}
}
