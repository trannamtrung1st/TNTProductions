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
		public DeliveryInformationRepository() : base()
		{
		}
		
		public DeliveryInformationRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override DeliveryInformation Add(DeliveryInformation entity)
		{
			entity.Active = true;
			entity = context.DeliveryInformations.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<DeliveryInformation> AddAsync(DeliveryInformation entity)
		{
			entity.Active = true;
			entity = context.DeliveryInformations.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override DeliveryInformation Delete(DeliveryInformation entity)
		{
			context.DeliveryInformations.Attach(entity);
			entity = context.DeliveryInformations.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<DeliveryInformation> DeleteAsync(DeliveryInformation entity)
		{
			context.DeliveryInformations.Attach(entity);
			entity = context.DeliveryInformations.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override DeliveryInformation Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.DeliveryInformations.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<DeliveryInformation> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.DeliveryInformations.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override DeliveryInformation FindById(int key)
		{
			var entity = context.DeliveryInformations.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override DeliveryInformation FindActiveById(int key)
		{
			var entity = context.DeliveryInformations.FirstOrDefault(
				e => e.ID == key && e.Active);
			return entity;
		}
		
		public override async Task<DeliveryInformation> FindByIdAsync(int key)
		{
			var entity = await context.DeliveryInformations.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<DeliveryInformation> FindActiveByIdAsync(int key)
		{
			var entity = await context.DeliveryInformations.FirstOrDefaultAsync(
				e => e.ID == key && e.Active);
			return entity;
		}
		
		public override DeliveryInformation FindByIdInclude<TProperty>(int key, params Expression<Func<DeliveryInformation, TProperty>>[] members)
		{
			IQueryable<DeliveryInformation> dbSet = context.DeliveryInformations;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ID == key);
		}
		
		public override async Task<DeliveryInformation> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<DeliveryInformation, TProperty>>[] members)
		{
			IQueryable<DeliveryInformation> dbSet = context.DeliveryInformations;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
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
			return context.DeliveryInformations.Where(e => e.Active);
		}
		
		public override IQueryable<DeliveryInformation> GetActive(Expression<Func<DeliveryInformation, bool>> expr)
		{
			return context.DeliveryInformations.Where(e => e.Active).Where(expr);
		}
		
		public override DeliveryInformation FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override DeliveryInformation FirstOrDefault(Expression<Func<DeliveryInformation, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<DeliveryInformation> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<DeliveryInformation> FirstOrDefaultAsync(Expression<Func<DeliveryInformation, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override DeliveryInformation SingleOrDefault(Expression<Func<DeliveryInformation, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<DeliveryInformation> SingleOrDefaultAsync(Expression<Func<DeliveryInformation, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override DeliveryInformation Update(DeliveryInformation entity)
		{
			entity = context.DeliveryInformations.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<DeliveryInformation> UpdateAsync(DeliveryInformation entity)
		{
			entity = context.DeliveryInformations.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
