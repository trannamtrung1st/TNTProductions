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
	public partial interface IContactRepository : IBaseRepository<Contact, int>
	{
	}
	
	public partial class ContactRepository : BaseRepository<Contact, int>, IContactRepository
	{
		public ContactRepository(DbContext context) : base(context)
		{
		}
		
		public ContactRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Contact FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override Contact FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ID == key && e.Active);
			return entity;
		}
		
		public override async Task<Contact> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<Contact> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ID == key && e.Active);
			return entity;
		}
		
		public override Contact Activate(Contact entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override Contact Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override Contact Deactivate(Contact entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override Contact Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<Contact> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<Contact> GetActive(Expression<Func<Contact, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
