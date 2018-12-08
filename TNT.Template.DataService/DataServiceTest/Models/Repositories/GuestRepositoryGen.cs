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
	public partial interface IGuestRepository : IBaseRepository<Guest, int>
	{
	}
	
	public partial class GuestRepository : BaseRepository<Guest, int>, IGuestRepository
	{
		public GuestRepository(DbContext context) : base(context)
		{
		}
		
		public GuestRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Guest FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override Guest FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Guest> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Guest> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override Guest Activate(Guest entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Guest Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Guest Deactivate(Guest entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Guest Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Guest> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<Guest> GetActive(Expression<Func<Guest, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
