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
	public partial interface ITaskChecklistsRepository : IBaseRepository<TaskChecklists, string>
	{
	}
	
	public partial class TaskChecklistsRepository : BaseRepository<TaskChecklists, string>, ITaskChecklistsRepository
	{
		public TaskChecklistsRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override TaskChecklists FindById(string key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<TaskChecklists> FindByIdAsync(string key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		#endregion
	}
}
