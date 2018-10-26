using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoterDataService.Models;
using PromoterDataService.Managers;
using System.Linq.Expressions;
using System.Data.Entity;

namespace PromoterDataService.Models.Repositories
{
	public partial interface ICustomerSegmentRepository : IBaseRepository<CustomerSegment, CustomerSegmentPK>
	{
	}
	
	public partial class CustomerSegmentRepository : BaseRepository<CustomerSegment, CustomerSegmentPK>, ICustomerSegmentRepository
	{
		public CustomerSegmentRepository() : base()
		{
		}
		
		public CustomerSegmentRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override CustomerSegment Add(CustomerSegment entity)
		{
			
			entity = context.CustomerSegments.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CustomerSegment> AddAsync(CustomerSegment entity)
		{
			
			entity = context.CustomerSegments.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override CustomerSegment Delete(CustomerSegment entity)
		{
			context.CustomerSegments.Attach(entity);
			entity = context.CustomerSegments.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CustomerSegment> DeleteAsync(CustomerSegment entity)
		{
			context.CustomerSegments.Attach(entity);
			entity = context.CustomerSegments.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override CustomerSegment Delete(CustomerSegmentPK key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.CustomerSegments.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CustomerSegment> DeleteAsync(CustomerSegmentPK key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.CustomerSegments.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override CustomerSegment FindById(CustomerSegmentPK key)
		{
			var entity = context.CustomerSegments.FirstOrDefault(
				e => e.CustomerId == key.CustomerId && e.SegmentId == key.SegmentId);
			return entity;
		}
		
		public override CustomerSegment FindActiveById(CustomerSegmentPK key)
		{
			var entity = context.CustomerSegments.FirstOrDefault(
				e => e.CustomerId == key.CustomerId && e.SegmentId == key.SegmentId);
			return entity;
		}
		
		public override async Task<CustomerSegment> FindByIdAsync(CustomerSegmentPK key)
		{
			var entity = await context.CustomerSegments.FirstOrDefaultAsync(
				e => e.CustomerId == key.CustomerId && e.SegmentId == key.SegmentId);
			return entity;
		}
		
		public override async Task<CustomerSegment> FindActiveByIdAsync(CustomerSegmentPK key)
		{
			var entity = await context.CustomerSegments.FirstOrDefaultAsync(
				e => e.CustomerId == key.CustomerId && e.SegmentId == key.SegmentId);
			return entity;
		}
		
		public override CustomerSegment FindByIdInclude<TProperty>(CustomerSegmentPK key, params Expression<Func<CustomerSegment, TProperty>>[] members)
		{
			IQueryable<CustomerSegment> dbSet = context.CustomerSegments;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.CustomerId == key.CustomerId && e.SegmentId == key.SegmentId);
		}
		
		public override async Task<CustomerSegment> FindByIdIncludeAsync<TProperty>(CustomerSegmentPK key, params Expression<Func<CustomerSegment, TProperty>>[] members)
		{
			IQueryable<CustomerSegment> dbSet = context.CustomerSegments;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.CustomerId == key.CustomerId && e.SegmentId == key.SegmentId);
		}
		
		public override CustomerSegment Activate(CustomerSegment entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CustomerSegment Activate(CustomerSegmentPK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CustomerSegment Deactivate(CustomerSegment entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CustomerSegment Deactivate(CustomerSegmentPK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<CustomerSegment> GetActive()
		{
			return context.CustomerSegments;
		}
		
		public override IQueryable<CustomerSegment> GetActive(Expression<Func<CustomerSegment, bool>> expr)
		{
			return context.CustomerSegments.Where(expr);
		}
		
		public override CustomerSegment FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override CustomerSegment FirstOrDefault(Expression<Func<CustomerSegment, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<CustomerSegment> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<CustomerSegment> FirstOrDefaultAsync(Expression<Func<CustomerSegment, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override CustomerSegment SingleOrDefault(Expression<Func<CustomerSegment, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<CustomerSegment> SingleOrDefaultAsync(Expression<Func<CustomerSegment, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override CustomerSegment Update(CustomerSegment entity)
		{
			entity = context.CustomerSegments.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CustomerSegment> UpdateAsync(CustomerSegment entity)
		{
			entity = context.CustomerSegments.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
