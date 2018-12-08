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
	public partial interface IDistrictRepository : IBaseRepository<District, int>
	{
	}
	
	public partial class DistrictRepository : BaseRepository<District, int>, IDistrictRepository
	{
		public DistrictRepository(DbContext context) : base(context)
		{
		}
		
		public DistrictRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override District FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.DistrictCode == key);
			return entity;
		}
		
		public override District FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.DistrictCode == key);
			return entity;
		}
		
		public override async Task<District> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.DistrictCode == key);
			return entity;
		}
		
		public override async Task<District> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.DistrictCode == key);
			return entity;
		}
		
		public override District Activate(District entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override District Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override District Deactivate(District entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override District Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<District> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<District> GetActive(Expression<Func<District, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
