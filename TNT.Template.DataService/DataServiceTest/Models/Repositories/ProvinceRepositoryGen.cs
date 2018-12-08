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
	public partial interface IProvinceRepository : IBaseRepository<Province, int>
	{
	}
	
	public partial class ProvinceRepository : BaseRepository<Province, int>, IProvinceRepository
	{
		public ProvinceRepository(DbContext context) : base(context)
		{
		}
		
		public ProvinceRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Province FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ProvinceCode == key);
			return entity;
		}
		
		public override Province FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ProvinceCode == key);
			return entity;
		}
		
		public override async Task<Province> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ProvinceCode == key);
			return entity;
		}
		
		public override async Task<Province> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ProvinceCode == key);
			return entity;
		}
		
		public override Province Activate(Province entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Province Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Province Deactivate(Province entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Province Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Province> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<Province> GetActive(Expression<Func<Province, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
