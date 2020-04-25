using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCodeFirst.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TestCodeFirst.Models.Repositories
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
			var entity = QuerySet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Logs> FindByIdAsync(int key)
		{
			var entity = await QuerySet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override EntityEntry<Logs> Remove(int key)
		{
			var entity = new Logs { Id = key };
			return dbSet.Remove(entity);
		}
		
		public override IEnumerable<Logs> RemoveIf(Expression<Func<Logs, bool>> expr)
		{
			var list = dbSet.Where(expr).Select(o => new Logs { Id = o.Id }).ToList();
			dbSet.RemoveRange(list);
			return list;
		}
		
		//Default DELETE command, override if there's any exception
		public override async Task<int> SqlRemoveAllAsync()
		{
			var result = await context.Database.ExecuteSqlRawAsync("DELETE FROM Logs");
			return result;
		}
		
		#endregion
	}
}
