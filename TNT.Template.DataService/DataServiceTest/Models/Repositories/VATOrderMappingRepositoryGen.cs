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
	public partial interface IVATOrderMappingRepository : IBaseRepository<VATOrderMapping, int>
	{
	}
	
	public partial class VATOrderMappingRepository : BaseRepository<VATOrderMapping, int>, IVATOrderMappingRepository
	{
		public VATOrderMappingRepository(DbContext context) : base(context)
		{
		}
		
		public VATOrderMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override VATOrderMapping FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override VATOrderMapping FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<VATOrderMapping> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<VATOrderMapping> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override VATOrderMapping Activate(VATOrderMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override VATOrderMapping Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override VATOrderMapping Deactivate(VATOrderMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override VATOrderMapping Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<VATOrderMapping> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<VATOrderMapping> GetActive(Expression<Func<VATOrderMapping, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
