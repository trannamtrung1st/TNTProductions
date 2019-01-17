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
	public partial interface IAppUserRepository : IBaseRepository<AppUser, int>
	{
		AppUser FindActiveById(int key);
		Task<AppUser> FindActiveByIdAsync(int key);
		IQueryable<AppUser> GetActive();
		IQueryable<AppUser> GetActive(Expression<Func<AppUser, bool>> expr);
	}
	
	public partial class AppUserRepository : BaseRepository<AppUser, int>, IAppUserRepository
	{
		public AppUserRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		public AppUserRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override AppUser FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<AppUser> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public AppUser FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active == true);
			return entity;
		}
		
		public async Task<AppUser> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active == true);
			return entity;
		}
		
		public IQueryable<AppUser> GetActive()
		{
			return dbSet.Where(e => e.Active == true);
		}
		
		public IQueryable<AppUser> GetActive(Expression<Func<AppUser, bool>> expr)
		{
			return dbSet.Where(e => e.Active == true).Where(expr);
		}
		
		#endregion
	}
}
