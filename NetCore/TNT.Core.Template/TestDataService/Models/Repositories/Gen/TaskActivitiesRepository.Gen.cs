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
	public partial interface ITaskActivitiesRepository : IBaseRepository<TaskActivities, string>
	{
	}
	
	public partial class TaskActivitiesRepository : BaseRepository<TaskActivities, string>, ITaskActivitiesRepository
	{
		public TaskActivitiesRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override TaskActivities FindById(string key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<TaskActivities> FindByIdAsync(string key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		#endregion
	}
}
