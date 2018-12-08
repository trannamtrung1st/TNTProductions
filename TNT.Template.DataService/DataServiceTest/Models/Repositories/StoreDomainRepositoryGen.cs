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
	public partial interface IStoreDomainRepository : IBaseRepository<StoreDomain, int>
	{
	}
	
	public partial class StoreDomainRepository : BaseRepository<StoreDomain, int>, IStoreDomainRepository
	{
		public StoreDomainRepository(DbContext context) : base(context)
		{
		}
		
		public StoreDomainRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override StoreDomain FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override StoreDomain FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<StoreDomain> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<StoreDomain> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override StoreDomain Activate(StoreDomain entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override StoreDomain Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override StoreDomain Deactivate(StoreDomain entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override StoreDomain Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<StoreDomain> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<StoreDomain> GetActive(Expression<Func<StoreDomain, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
