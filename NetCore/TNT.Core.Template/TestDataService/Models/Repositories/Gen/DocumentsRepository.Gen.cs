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
	public partial interface IDocumentsRepository : IBaseRepository<Documents, string>
	{
	}
	
	public partial class DocumentsRepository : BaseRepository<Documents, string>, IDocumentsRepository
	{
		public DocumentsRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD area
		public override Documents FindById(string key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Code == key);
			return entity;
		}
		
		public override async Task<Documents> FindByIdAsync(string key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Code == key);
			return entity;
		}
		
		#endregion
	}
}
