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
	public partial interface ILanguageValueRepository : IBaseRepository<LanguageValue, int>
	{
	}
	
	public partial class LanguageValueRepository : BaseRepository<LanguageValue, int>, ILanguageValueRepository
	{
		public LanguageValueRepository(DbContext context) : base(context)
		{
		}
		
		public LanguageValueRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override LanguageValue FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override LanguageValue FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<LanguageValue> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<LanguageValue> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override LanguageValue Activate(LanguageValue entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override LanguageValue Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override LanguageValue Deactivate(LanguageValue entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override LanguageValue Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<LanguageValue> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<LanguageValue> GetActive(Expression<Func<LanguageValue, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
