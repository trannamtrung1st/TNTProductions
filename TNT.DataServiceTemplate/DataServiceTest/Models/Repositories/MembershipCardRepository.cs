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
	public partial interface IMembershipCardRepository : IBaseRepository<MembershipCard, int>
	{
	}
	
	public partial class MembershipCardRepository : BaseRepository<MembershipCard, int>, IMembershipCardRepository
	{
		public MembershipCardRepository() : base()
		{
		}
		
		public MembershipCardRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override MembershipCard Add(MembershipCard entity)
		{
			entity.Active = true;
			entity = context.MembershipCards.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<MembershipCard> AddAsync(MembershipCard entity)
		{
			entity.Active = true;
			entity = context.MembershipCards.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override MembershipCard Delete(MembershipCard entity)
		{
			context.MembershipCards.Attach(entity);
			entity = context.MembershipCards.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<MembershipCard> DeleteAsync(MembershipCard entity)
		{
			context.MembershipCards.Attach(entity);
			entity = context.MembershipCards.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override MembershipCard Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.MembershipCards.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<MembershipCard> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.MembershipCards.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override MembershipCard FindById(int key)
		{
			var entity = context.MembershipCards.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override MembershipCard FindActiveById(int key)
		{
			var entity = context.MembershipCards.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<MembershipCard> FindByIdAsync(int key)
		{
			var entity = await context.MembershipCards.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<MembershipCard> FindActiveByIdAsync(int key)
		{
			var entity = await context.MembershipCards.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override MembershipCard FindByIdInclude<TProperty>(int key, params Expression<Func<MembershipCard, TProperty>>[] members)
		{
			IQueryable<MembershipCard> dbSet = context.MembershipCards;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<MembershipCard> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<MembershipCard, TProperty>>[] members)
		{
			IQueryable<MembershipCard> dbSet = context.MembershipCards;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override MembershipCard Activate(MembershipCard entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override MembershipCard Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override MembershipCard Deactivate(MembershipCard entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override MembershipCard Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<MembershipCard> GetActive()
		{
			return context.MembershipCards.Where(e => e.Active);
		}
		
		public override IQueryable<MembershipCard> GetActive(Expression<Func<MembershipCard, bool>> expr)
		{
			return context.MembershipCards.Where(e => e.Active).Where(expr);
		}
		
		public override MembershipCard FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override MembershipCard FirstOrDefault(Expression<Func<MembershipCard, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<MembershipCard> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<MembershipCard> FirstOrDefaultAsync(Expression<Func<MembershipCard, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override MembershipCard SingleOrDefault(Expression<Func<MembershipCard, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<MembershipCard> SingleOrDefaultAsync(Expression<Func<MembershipCard, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override MembershipCard Update(MembershipCard entity)
		{
			entity = context.MembershipCards.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<MembershipCard> UpdateAsync(MembershipCard entity)
		{
			entity = context.MembershipCards.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
