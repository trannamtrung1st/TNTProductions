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
	public partial interface IMachineConnectRepository : IBaseRepository<MachineConnect, int>
	{
	}
	
	public partial class MachineConnectRepository : BaseRepository<MachineConnect, int>, IMachineConnectRepository
	{
		public MachineConnectRepository(DbContext context) : base(context)
		{
		}
		
		public MachineConnectRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override MachineConnect FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override MachineConnect FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ID == key && e.Active);
			return entity;
		}
		
		public override async Task<MachineConnect> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<MachineConnect> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ID == key && e.Active);
			return entity;
		}
		
		public override MachineConnect Activate(MachineConnect entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override MachineConnect Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override MachineConnect Deactivate(MachineConnect entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override MachineConnect Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<MachineConnect> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<MachineConnect> GetActive(Expression<Func<MachineConnect, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
