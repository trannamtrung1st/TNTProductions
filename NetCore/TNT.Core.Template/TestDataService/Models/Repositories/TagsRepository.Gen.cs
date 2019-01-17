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
	public partial interface ITagsRepository : IBaseRepository<Tags, int>
	{
		Tags FindActiveById(int key);
		Task<Tags> FindActiveByIdAsync(int key);
		IQueryable<Tags> GetActive();
		IQueryable<Tags> GetActive(Expression<Func<Tags, bool>> expr);
	}
	
	public partial class TagsRepository : BaseRepository<Tags, int>, ITagsRepository
	{
		public TagsRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		public TagsRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override Tags FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Tags> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public Tags FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active == true);
			return entity;
		}
		
		public async Task<Tags> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active == true);
			return entity;
		}
		
		public IQueryable<Tags> GetActive()
		{
			return dbSet.Where(e => e.Active == true);
		}
		
		public IQueryable<Tags> GetActive(Expression<Func<Tags, bool>> expr)
		{
			return dbSet.Where(e => e.Active == true).Where(expr);
		}
		
		#endregion
	}
}
