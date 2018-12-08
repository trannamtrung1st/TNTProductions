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
		public SubRentGroupRepository(DbContext context) : base(context)
		{
		}
		
		public SubRentGroupRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override SubRentGroup FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override SubRentGroup FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<SubRentGroup> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<SubRentGroup> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
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
			return dbSet;
		}
		
		public override IQueryable<SubRentGroup> GetActive(Expression<Func<SubRentGroup, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
