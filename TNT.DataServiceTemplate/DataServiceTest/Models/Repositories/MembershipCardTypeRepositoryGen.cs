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
	public partial interface IMembershipCardTypeRepository : IBaseRepository<MembershipCardType, int>
	{
	}
	
	public partial class MembershipCardTypeRepository : BaseRepository<MembershipCardType, int>, IMembershipCardTypeRepository
	{
		public MembershipCardTypeRepository() : base()
		{
		}
		
		public MembershipCardTypeRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override MembershipCardType Add(MembershipCardType entity)
		{
			
			entity = context.MembershipCardTypes.Add(entity);
			return entity;
		}
		
		public override MembershipCardType Remove(MembershipCardType entity)
		{
			context.MembershipCardTypes.Attach(entity);
			entity = context.MembershipCardTypes.Remove(entity);
			return entity;
		}
		
		public override MembershipCardType Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.MembershipCardTypes.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<MembershipCardType> RemoveIf(Expression<Func<MembershipCardType, bool>> expr)
		{
			return context.MembershipCardTypes.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<MembershipCardType> RemoveRange(IEnumerable<MembershipCardType> list)
		{
			return context.MembershipCardTypes.RemoveRange(list);
		}
		
		public override MembershipCardType FindById(int key)
		{
			var entity = context.MembershipCardTypes.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override MembershipCardType FindActiveById(int key)
		{
			var entity = context.MembershipCardTypes.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<MembershipCardType> FindByIdAsync(int key)
		{
			var entity = await context.MembershipCardTypes.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<MembershipCardType> FindActiveByIdAsync(int key)
		{
			var entity = await context.MembershipCardTypes.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override MembershipCardType FindByIdInclude<TProperty>(int key, params Expression<Func<MembershipCardType, TProperty>>[] members)
		{
			IQueryable<MembershipCardType> dbSet = context.MembershipCardTypes;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<MembershipCardType> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<MembershipCardType, TProperty>>[] members)
		{
			IQueryable<MembershipCardType> dbSet = context.MembershipCardTypes;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override MembershipCardType Activate(MembershipCardType entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override MembershipCardType Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override MembershipCardType Deactivate(MembershipCardType entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override MembershipCardType Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<MembershipCardType> GetActive()
		{
			return context.MembershipCardTypes;
		}
		
		public override IQueryable<MembershipCardType> GetActive(Expression<Func<MembershipCardType, bool>> expr)
		{
			return context.MembershipCardTypes.Where(expr);
		}
		
		public override MembershipCardType FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override MembershipCardType FirstOrDefault(Expression<Func<MembershipCardType, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<MembershipCardType> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<MembershipCardType> FirstOrDefaultAsync(Expression<Func<MembershipCardType, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override MembershipCardType SingleOrDefault(Expression<Func<MembershipCardType, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<MembershipCardType> SingleOrDefaultAsync(Expression<Func<MembershipCardType, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override MembershipCardType Update(MembershipCardType entity)
		{
			entity = context.MembershipCardTypes.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
