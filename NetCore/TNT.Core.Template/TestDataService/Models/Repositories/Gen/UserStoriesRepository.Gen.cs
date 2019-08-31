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
	public partial interface IUserStoriesRepository : IBaseRepository<UserStories, string>
	{
	}
	
	public partial class UserStoriesRepository : BaseRepository<UserStories, string>, IUserStoriesRepository
	{
		public UserStoriesRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override UserStories FindById(string key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<UserStories> FindByIdAsync(string key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		#endregion
	}
}
