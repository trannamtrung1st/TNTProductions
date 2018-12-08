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
	public partial interface ITemplateDetailMappingRepository : IBaseRepository<TemplateDetailMapping, int>
	{
	}
	
	public partial class TemplateDetailMappingRepository : BaseRepository<TemplateDetailMapping, int>, ITemplateDetailMappingRepository
	{
		public TemplateDetailMappingRepository(DbContext context) : base(context)
		{
		}
		
		public TemplateDetailMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override TemplateDetailMapping FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override TemplateDetailMapping FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<TemplateDetailMapping> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<TemplateDetailMapping> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override TemplateDetailMapping Activate(TemplateDetailMapping entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override TemplateDetailMapping Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override TemplateDetailMapping Deactivate(TemplateDetailMapping entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override TemplateDetailMapping Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<TemplateDetailMapping> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<TemplateDetailMapping> GetActive(Expression<Func<TemplateDetailMapping, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
