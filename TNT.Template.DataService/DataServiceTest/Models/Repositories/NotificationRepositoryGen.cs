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
	public partial interface INotificationRepository : IBaseRepository<Notification, int>
	{
	}
	
	public partial class NotificationRepository : BaseRepository<Notification, int>, INotificationRepository
	{
		public NotificationRepository(DbContext context) : base(context)
		{
		}
		
		public NotificationRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Notification FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override Notification FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Notification> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Notification> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override Notification Activate(Notification entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Notification Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Notification Deactivate(Notification entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Notification Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Notification> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<Notification> GetActive(Expression<Func<Notification, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
