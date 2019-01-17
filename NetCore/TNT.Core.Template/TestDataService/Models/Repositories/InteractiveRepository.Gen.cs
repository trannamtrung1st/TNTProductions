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
	public partial interface IInteractiveRepository : IBaseRepository<Interactive, int>
	{
		Interactive FindActiveById(int key);
		Task<Interactive> FindActiveByIdAsync(int key);
		IQueryable<Interactive> GetActive();
		IQueryable<Interactive> GetActive(Expression<Func<Interactive, bool>> expr);
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
		
		public Interactive FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active == true);
			return entity;
		}
		
		public async Task<Interactive> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active == true);
			return entity;
		}
		
		public IQueryable<Interactive> GetActive()
		{
			return dbSet.Where(e => e.Active == true);
		}
		
		public IQueryable<Interactive> GetActive(Expression<Func<Interactive, bool>> expr)
		{
			return dbSet.Where(e => e.Active == true).Where(expr);
		}
		
		#endregion
	}
}
