using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.Models.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace TestDataService.Models.Repositories
{
	public partial interface IProjectsRepository : IBaseRepository<Projects, int>
	{
	}
	
	public partial class ProjectsRepository : BaseRepository<Projects, int>, IProjectsRepository
	{
		public ProjectsRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD area
		public override Projects FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Projects> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		#endregion
	}
}
