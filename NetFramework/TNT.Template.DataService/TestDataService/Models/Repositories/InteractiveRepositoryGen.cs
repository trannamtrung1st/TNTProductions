using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.Models;
using TNT.IoC.Attributes;
using System.Linq.Expressions;
using System.Data.Entity;

namespace TestDataService.Models.Repositories
{
	public partial interface IInteractiveRepository : IBaseRepository<Interactive, int>
	{
	}
	
	public partial class InteractiveRepository : BaseRepository<Interactive, int>, IInteractiveRepository
	{
		public InteractiveRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		public InteractiveRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override Interactive FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Interactive> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		#endregion
	}
}
