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
	public partial interface IEpicsRepository : IBaseRepository<Epics, string>
	{
	}
	
	public partial class EpicsRepository : BaseRepository<Epics, string>, IEpicsRepository
	{
		public EpicsRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override Epics FindById(string key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Epics> FindByIdAsync(string key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		#endregion
	}
}
