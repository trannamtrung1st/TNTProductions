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
	public partial interface ITaskChecklistItemsRepository : IBaseRepository<TaskChecklistItems, string>
	{
	}
	
	public partial class TaskChecklistItemsRepository : BaseRepository<TaskChecklistItems, string>, ITaskChecklistItemsRepository
	{
		public TaskChecklistItemsRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override TaskChecklistItems FindById(string key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<TaskChecklistItems> FindByIdAsync(string key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		#endregion
	}
}
