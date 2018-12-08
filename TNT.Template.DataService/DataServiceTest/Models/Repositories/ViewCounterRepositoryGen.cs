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
	public partial interface IViewCounterRepository : IBaseRepository<ViewCounter, int>
	{
	}
	
	public partial class ViewCounterRepository : BaseRepository<ViewCounter, int>, IViewCounterRepository
	{
		public ViewCounterRepository(DbContext context) : base(context)
		{
		}
		
		public ViewCounterRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override ViewCounter FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override ViewCounter FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<ViewCounter> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<ViewCounter> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override ViewCounter Activate(ViewCounter entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override ViewCounter Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override ViewCounter Deactivate(ViewCounter entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override ViewCounter Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<ViewCounter> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<ViewCounter> GetActive(Expression<Func<ViewCounter, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
