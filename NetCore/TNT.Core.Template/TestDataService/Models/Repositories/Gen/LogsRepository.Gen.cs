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
	public partial interface ILogsRepository : IBaseRepository<Logs, int>
	{
	}
	
	public partial class LogsRepository : BaseRepository<Logs, int>, ILogsRepository
	{
		public LogsRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override Logs FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Logs> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		#endregion
	}
}
