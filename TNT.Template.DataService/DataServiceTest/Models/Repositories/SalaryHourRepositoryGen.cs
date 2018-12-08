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
	public partial interface ISalaryHourRepository : IBaseRepository<SalaryHour, int>
	{
	}
	
	public partial class SalaryHourRepository : BaseRepository<SalaryHour, int>, ISalaryHourRepository
	{
		public SalaryHourRepository(DbContext context) : base(context)
		{
		}
		
		public SalaryHourRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override SalaryHour FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override SalaryHour FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<SalaryHour> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<SalaryHour> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override SalaryHour Activate(SalaryHour entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override SalaryHour Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override SalaryHour Deactivate(SalaryHour entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override SalaryHour Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<SalaryHour> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<SalaryHour> GetActive(Expression<Func<SalaryHour, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
