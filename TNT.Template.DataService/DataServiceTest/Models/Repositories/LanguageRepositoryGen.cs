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
	public partial interface ILanguageRepository : IBaseRepository<Language, int>
	{
	}
	
	public partial class LanguageRepository : BaseRepository<Language, int>, ILanguageRepository
	{
		public LanguageRepository(DbContext context) : base(context)
		{
		}
		
		public LanguageRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Language FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override Language FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<Language> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Language> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override Language Activate(Language entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override Language Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override Language Deactivate(Language entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override Language Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<Language> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<Language> GetActive(Expression<Func<Language, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
