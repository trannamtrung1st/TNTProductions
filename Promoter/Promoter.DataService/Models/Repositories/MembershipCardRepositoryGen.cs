using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Promoter.DataService.Models;
using Promoter.DataService.Managers;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Promoter.DataService.Models.Repositories
{
	public partial interface IMembershipCardRepository : IBaseRepository<MembershipCard, int>
	{
	}
	
	public partial class MembershipCardRepository : BaseRepository<MembershipCard, int>, IMembershipCardRepository
	{
		public MembershipCardRepository(PromoterEntities context) : base(context)
		{
		}
		
		public MembershipCardRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override MembershipCard Add(MembershipCard entity)
		{
			
			entity = context.MembershipCards.Add(entity);
			return entity;
		}
		
		public override MembershipCard Remove(MembershipCard entity)
		{
			context.MembershipCards.Attach(entity);
			entity = context.MembershipCards.Remove(entity);
			return entity;
		}
		
		public override MembershipCard Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.MembershipCards.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<MembershipCard> RemoveIf(Expression<Func<MembershipCard, bool>> expr)
		{
			return context.MembershipCards.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<MembershipCard> RemoveRange(IEnumerable<MembershipCard> list)
		{
			return context.MembershipCards.RemoveRange(list);
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
				e => e.Id == key);
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
				e => e.Id == key);
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
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override MembershipCard Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override MembershipCard Deactivate(MembershipCard entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override MembershipCard Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<MembershipCard> GetActive()
		{
			return context.MembershipCards;
		}
		
		public override IQueryable<MembershipCard> GetActive(Expression<Func<MembershipCard, bool>> expr)
		{
			return context.MembershipCards.Where(expr);
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
			return entity;
		}
		#endregion
		
	}
}
