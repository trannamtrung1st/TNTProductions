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
	public partial interface IOrganizationsRepository : IBaseRepository<Organizations, int>
	{
	}
	
	public partial class OrganizationsRepository : BaseRepository<Organizations, int>, IOrganizationsRepository
	{
		public OrganizationsRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD area
		public override Organizations FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Organizations> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		#endregion
	}
}
