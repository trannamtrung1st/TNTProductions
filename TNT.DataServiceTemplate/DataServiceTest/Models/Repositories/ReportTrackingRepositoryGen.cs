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
	public partial interface IReportTrackingRepository : IBaseRepository<ReportTracking, int>
	{
	}
	
	public partial class ReportTrackingRepository : BaseRepository<ReportTracking, int>, IReportTrackingRepository
	{
		public ReportTrackingRepository() : base()
		{
		}
		
		public ReportTrackingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override ReportTracking Add(ReportTracking entity)
		{
			
			entity = context.ReportTrackings.Add(entity);
			return entity;
		}
		
		public override ReportTracking Remove(ReportTracking entity)
		{
			context.ReportTrackings.Attach(entity);
			entity = context.ReportTrackings.Remove(entity);
			return entity;
		}
		
		public override ReportTracking Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.ReportTrackings.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<ReportTracking> RemoveIf(Expression<Func<ReportTracking, bool>> expr)
		{
			return context.ReportTrackings.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<ReportTracking> RemoveRange(IEnumerable<ReportTracking> list)
		{
			return context.ReportTrackings.RemoveRange(list);
		}
		
		public override ReportTracking FindById(int key)
		{
			var entity = context.ReportTrackings.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override ReportTracking FindActiveById(int key)
		{
			var entity = context.ReportTrackings.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<ReportTracking> FindByIdAsync(int key)
		{
			var entity = await context.ReportTrackings.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<ReportTracking> FindActiveByIdAsync(int key)
		{
			var entity = await context.ReportTrackings.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override ReportTracking FindByIdInclude<TProperty>(int key, params Expression<Func<ReportTracking, TProperty>>[] members)
		{
			IQueryable<ReportTracking> dbSet = context.ReportTrackings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<ReportTracking> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<ReportTracking, TProperty>>[] members)
		{
			IQueryable<ReportTracking> dbSet = context.ReportTrackings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override ReportTracking Activate(ReportTracking entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override ReportTracking Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override ReportTracking Deactivate(ReportTracking entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override ReportTracking Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<ReportTracking> GetActive()
		{
			return context.ReportTrackings;
		}
		
		public override IQueryable<ReportTracking> GetActive(Expression<Func<ReportTracking, bool>> expr)
		{
			return context.ReportTrackings.Where(expr);
		}
		
		public override ReportTracking FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override ReportTracking FirstOrDefault(Expression<Func<ReportTracking, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<ReportTracking> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<ReportTracking> FirstOrDefaultAsync(Expression<Func<ReportTracking, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override ReportTracking SingleOrDefault(Expression<Func<ReportTracking, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<ReportTracking> SingleOrDefaultAsync(Expression<Func<ReportTracking, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override ReportTracking Update(ReportTracking entity)
		{
			entity = context.ReportTrackings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
