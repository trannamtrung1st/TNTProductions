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
	public partial interface ISprintsRepository : IBaseRepository<Sprints, string>
	{
	}
	
	public partial class SprintsRepository : BaseRepository<Sprints, string>, ISprintsRepository
	{
		public SprintsRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override Sprints FindById(string key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Sprints> FindByIdAsync(string key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		#endregion
	}
}
