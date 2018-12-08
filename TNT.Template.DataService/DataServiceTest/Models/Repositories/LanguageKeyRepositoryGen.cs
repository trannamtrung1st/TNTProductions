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
	public partial interface ILanguageKeyRepository : IBaseRepository<LanguageKey, int>
	{
	}
	
	public partial class LanguageKeyRepository : BaseRepository<LanguageKey, int>, ILanguageKeyRepository
	{
		public LanguageKeyRepository(DbContext context) : base(context)
		{
		}
		
		public LanguageKeyRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override LanguageKey FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override LanguageKey FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<LanguageKey> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<LanguageKey> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override LanguageKey Activate(LanguageKey entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override LanguageKey Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override LanguageKey Deactivate(LanguageKey entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override LanguageKey Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<LanguageKey> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<LanguageKey> GetActive(Expression<Func<LanguageKey, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
