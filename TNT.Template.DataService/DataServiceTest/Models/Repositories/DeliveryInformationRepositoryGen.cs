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
	public partial interface IDeliveryInformationRepository : IBaseRepository<DeliveryInformation, int>
	{
	}
	
	public partial class DeliveryInformationRepository : BaseRepository<DeliveryInformation, int>, IDeliveryInformationRepository
	{
		public DeliveryInformationRepository(DbContext context) : base(context)
		{
		}
		
		public DeliveryInformationRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override DeliveryInformation FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override DeliveryInformation FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ID == key && e.Active);
			return entity;
		}
		
		public override async Task<DeliveryInformation> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<DeliveryInformation> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ID == key && e.Active);
			return entity;
		}
		
		public override DeliveryInformation Activate(DeliveryInformation entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override DeliveryInformation Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override DeliveryInformation Deactivate(DeliveryInformation entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override DeliveryInformation Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<DeliveryInformation> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<DeliveryInformation> GetActive(Expression<Func<DeliveryInformation, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
