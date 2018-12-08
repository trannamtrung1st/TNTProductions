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
	public partial interface IFingerScanMachineRepository : IBaseRepository<FingerScanMachine, int>
	{
	}
	
	public partial class FingerScanMachineRepository : BaseRepository<FingerScanMachine, int>, IFingerScanMachineRepository
	{
		public FingerScanMachineRepository(DbContext context) : base(context)
		{
		}
		
		public FingerScanMachineRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override FingerScanMachine FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override FingerScanMachine FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<FingerScanMachine> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<FingerScanMachine> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override FingerScanMachine Activate(FingerScanMachine entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override FingerScanMachine Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override FingerScanMachine Deactivate(FingerScanMachine entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override FingerScanMachine Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<FingerScanMachine> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<FingerScanMachine> GetActive(Expression<Func<FingerScanMachine, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
