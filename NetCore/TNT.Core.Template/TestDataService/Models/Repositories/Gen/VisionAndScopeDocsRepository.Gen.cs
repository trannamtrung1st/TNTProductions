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
	public partial interface IVisionAndScopeDocsRepository : IBaseRepository<VisionAndScopeDocs, VisionAndScopeDocsPK>
	{
	}
	
	public partial class VisionAndScopeDocsRepository : BaseRepository<VisionAndScopeDocs, VisionAndScopeDocsPK>, IVisionAndScopeDocsRepository
	{
		public VisionAndScopeDocsRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD area
		public override VisionAndScopeDocs FindById(VisionAndScopeDocsPK key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ProjectId == key.ProjectId && e.Major == key.Major && e.Minor == key.Minor);
			return entity;
		}
		
		public override async Task<VisionAndScopeDocs> FindByIdAsync(VisionAndScopeDocsPK key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ProjectId == key.ProjectId && e.Major == key.Major && e.Minor == key.Minor);
			return entity;
		}
		
		#endregion
	}
}
