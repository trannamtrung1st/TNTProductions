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
		public ContactRepository() : base()
		{
		}
		
		public ContactRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Contact Add(Contact entity)
		{
			entity.Active = true;
			entity = context.Contacts.Add(entity);
			return entity;
		}
		
		public override Contact Remove(Contact entity)
		{
			context.Contacts.Attach(entity);
			entity = context.Contacts.Remove(entity);
			return entity;
		}
		
		public override Contact Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Contacts.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<Contact> RemoveIf(Expression<Func<Contact, bool>> expr)
		{
			return context.Contacts.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<Contact> RemoveRange(IEnumerable<Contact> list)
		{
			return context.Contacts.RemoveRange(list);
		}
		
		public override Contact FindById(int key)
		{
			var entity = context.Contacts.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override Contact FindActiveById(int key)
		{
			var entity = context.Contacts.FirstOrDefault(
				e => e.ID == key && e.Active);
			return entity;
		}
		
		public override async Task<Contact> FindByIdAsync(int key)
		{
			var entity = await context.Contacts.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<Contact> FindActiveByIdAsync(int key)
		{
			var entity = await context.Contacts.FirstOrDefaultAsync(
				e => e.ID == key && e.Active);
			return entity;
		}
		
		public override Contact FindByIdInclude<TProperty>(int key, params Expression<Func<Contact, TProperty>>[] members)
		{
			IQueryable<Contact> dbSet = context.Contacts;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ID == key);
		}
		
		public override async Task<Contact> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Contact, TProperty>>[] members)
		{
			IQueryable<Contact> dbSet = context.Contacts;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
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
			return context.Contacts.Where(e => e.Active);
		}
		
		public override IQueryable<Contact> GetActive(Expression<Func<Contact, bool>> expr)
		{
			return context.Contacts.Where(e => e.Active).Where(expr);
		}
		
		public override Contact FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Contact FirstOrDefault(Expression<Func<Contact, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Contact> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Contact> FirstOrDefaultAsync(Expression<Func<Contact, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Contact SingleOrDefault(Expression<Func<Contact, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Contact> SingleOrDefaultAsync(Expression<Func<Contact, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Contact Update(Contact entity)
		{
			entity = context.Contacts.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
