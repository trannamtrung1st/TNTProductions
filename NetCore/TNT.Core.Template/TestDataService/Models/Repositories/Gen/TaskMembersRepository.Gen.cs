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
	public partial interface ITaskMembersRepository : IBaseRepository<TaskMembers, TaskMembersPK>
	{
	}
	
	public partial class TaskMembersRepository : BaseRepository<TaskMembers, TaskMembersPK>, ITaskMembersRepository
	{
		public TaskMembersRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override TaskMembers FindById(TaskMembersPK key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.UserId == key.UserId && e.TaskId == key.TaskId);
			return entity;
		}
		
		public override async Task<TaskMembers> FindByIdAsync(TaskMembersPK key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.UserId == key.UserId && e.TaskId == key.TaskId);
			return entity;
		}
		
		#endregion
	}
}
