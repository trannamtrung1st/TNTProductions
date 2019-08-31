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
	public partial interface ITasksRepository : IBaseRepository<Tasks, string>
	{
	}
	
	public partial class TasksRepository : BaseRepository<Tasks, string>, ITasksRepository
	{
		public TasksRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override Tasks FindById(string key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Tasks> FindByIdAsync(string key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		#endregion
	}
}
