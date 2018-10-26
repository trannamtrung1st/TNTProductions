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
	public partial interface ISegmentRepository : IBaseRepository<Segment, int>
	{
	}
	
	public partial class SegmentRepository : BaseRepository<Segment, int>, ISegmentRepository
	{
		public SegmentRepository() : base()
		{
		}
		
		public SegmentRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Segment Add(Segment entity)
		{
			
			entity = context.Segments.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Segment> AddAsync(Segment entity)
		{
			
			entity = context.Segments.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Segment Delete(Segment entity)
		{
			context.Segments.Attach(entity);
			entity = context.Segments.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Segment> DeleteAsync(Segment entity)
		{
			context.Segments.Attach(entity);
			entity = context.Segments.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Segment Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Segments.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Segment> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Segments.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Segment FindById(int key)
		{
			var entity = context.Segments.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override Segment FindActiveById(int key)
		{
			var entity = context.Segments.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Segment> FindByIdAsync(int key)
		{
			var entity = await context.Segments.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Segment> FindActiveByIdAsync(int key)
		{
			var entity = await context.Segments.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override Segment FindByIdInclude<TProperty>(int key, params Expression<Func<Segment, TProperty>>[] members)
		{
			IQueryable<Segment> dbSet = context.Segments;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<Segment> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Segment, TProperty>>[] members)
		{
			IQueryable<Segment> dbSet = context.Segments;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override Segment Activate(Segment entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Segment Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Segment Deactivate(Segment entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Segment Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Segment> GetActive()
		{
			return context.Segments;
		}
		
		public override IQueryable<Segment> GetActive(Expression<Func<Segment, bool>> expr)
		{
			return context.Segments.Where(expr);
		}
		
		public override Segment FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Segment FirstOrDefault(Expression<Func<Segment, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Segment> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Segment> FirstOrDefaultAsync(Expression<Func<Segment, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Segment SingleOrDefault(Expression<Func<Segment, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Segment> SingleOrDefaultAsync(Expression<Func<Segment, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Segment Update(Segment entity)
		{
			entity = context.Segments.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Segment> UpdateAsync(Segment entity)
		{
			entity = context.Segments.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
