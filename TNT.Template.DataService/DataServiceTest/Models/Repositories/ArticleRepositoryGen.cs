using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.Models;
using DataServiceTest.Managers;
using System.Linq.Expressions;
using System.Data.Entity;

namespace DataServiceTest.Models.Repositories
{
	public partial interface IArticleRepository : IBaseRepository<Article, int>
	{
	}
	
	public partial class ArticleRepository : BaseRepository<Article, int>, IArticleRepository
	{
		public ArticleRepository(DbContext context) : base(context)
		{
		}
		
		public ArticleRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Article FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override Article FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<Article> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<Article> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override Article Activate(Article entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Article Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Article Deactivate(Article entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Article Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Article> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<Article> GetActive(Expression<Func<Article, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
