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
	public partial interface ISubRentGroupRepository : IBaseRepository<SubRentGroup, int>
	{
	}
	
	public partial class SubRentGroupRepository : BaseRepository<SubRentGroup, int>, ISubRentGroupRepository
	{
		public SubRentGroupRepository() : base()
		{
		}
		
		public SubRentGroupRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override SubRentGroup Add(SubRentGroup entity)
		{
			
			entity = context.SubRentGroups.Add(entity);
			return entity;
		}
		
		public override SubRentGroup Remove(SubRentGroup entity)
		{
			context.SubRentGroups.Attach(entity);
			entity = context.SubRentGroups.Remove(entity);
			return entity;
		}
		
		public override SubRentGroup Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.SubRentGroups.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<SubRentGroup> RemoveIf(Expression<Func<SubRentGroup, bool>> expr)
		{
			return context.SubRentGroups.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<SubRentGroup> RemoveRange(IEnumerable<SubRentGroup> list)
		{
			return context.SubRentGroups.RemoveRange(list);
		}
		
		public override SubRentGroup FindById(int key)
		{
			var entity = context.SubRentGroups.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override SubRentGroup FindActiveById(int key)
		{
			var entity = context.SubRentGroups.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<SubRentGroup> FindByIdAsync(int key)
		{
			var entity = await context.SubRentGroups.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<SubRentGroup> FindActiveByIdAsync(int key)
		{
			var entity = await context.SubRentGroups.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override SubRentGroup FindByIdInclude<TProperty>(int key, params Expression<Func<SubRentGroup, TProperty>>[] members)
		{
			IQueryable<SubRentGroup> dbSet = context.SubRentGroups;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<SubRentGroup> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<SubRentGroup, TProperty>>[] members)
		{
			IQueryable<SubRentGroup> dbSet = context.SubRentGroups;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override SubRentGroup Activate(SubRentGroup entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override SubRentGroup Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override SubRentGroup Deactivate(SubRentGroup entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override SubRentGroup Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<SubRentGroup> GetActive()
		{
			return context.SubRentGroups;
		}
		
		public override IQueryable<SubRentGroup> GetActive(Expression<Func<SubRentGroup, bool>> expr)
		{
			return context.SubRentGroups.Where(expr);
		}
		
		public override SubRentGroup FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override SubRentGroup FirstOrDefault(Expression<Func<SubRentGroup, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<SubRentGroup> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<SubRentGroup> FirstOrDefaultAsync(Expression<Func<SubRentGroup, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override SubRentGroup SingleOrDefault(Expression<Func<SubRentGroup, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<SubRentGroup> SingleOrDefaultAsync(Expression<Func<SubRentGroup, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override SubRentGroup Update(SubRentGroup entity)
		{
			entity = context.SubRentGroups.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
