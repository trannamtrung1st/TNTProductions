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
	public partial interface ITaskAttachmentsRepository : IBaseRepository<TaskAttachments, string>
	{
	}
	
	public partial class TaskAttachmentsRepository : BaseRepository<TaskAttachments, string>, ITaskAttachmentsRepository
	{
		public TaskAttachmentsRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override TaskAttachments FindById(string key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<TaskAttachments> FindByIdAsync(string key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		#endregion
	}
}
