using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoterDataService.Models;
using PromoterDataService.Managers;
using System.Linq.Expressions;
using System.Data.Entity;

namespace PromoterDataService.Models.Repositories
{
	public partial interface IPartnerRepository : IBaseRepository<Partner, int>
	{
	}
	
	public partial class PartnerRepository : BaseRepository<Partner, int>, IPartnerRepository
	{
		public PartnerRepository() : base()
		{
		}
		
		public PartnerRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Partner Add(Partner entity)
		{
			
			entity = context.Partners.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Partner> AddAsync(Partner entity)
		{
			
			entity = context.Partners.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Partner Delete(Partner entity)
		{
			context.Partners.Attach(entity);
			entity = context.Partners.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Partner> DeleteAsync(Partner entity)
		{
			context.Partners.Attach(entity);
			entity = context.Partners.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Partner Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Partners.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Partner> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Partners.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Partner FindById(int key)
		{
			var entity = context.Partners.FirstOrDefault(
				e => e.IID == key);
			return entity;
		}
		
		public override Partner FindActiveById(int key)
		{
			var entity = context.Partners.FirstOrDefault(
				e => e.IID == key);
			return entity;
		}
		
		public override async Task<Partner> FindByIdAsync(int key)
		{
			var entity = await context.Partners.FirstOrDefaultAsync(
				e => e.IID == key);
			return entity;
		}
		
		public override async Task<Partner> FindActiveByIdAsync(int key)
		{
			var entity = await context.Partners.FirstOrDefaultAsync(
				e => e.IID == key);
			return entity;
		}
		
		public override Partner FindByIdInclude<TProperty>(int key, params Expression<Func<Partner, TProperty>>[] members)
		{
			IQueryable<Partner> dbSet = context.Partners;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.IID == key);
		}
		
		public override async Task<Partner> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Partner, TProperty>>[] members)
		{
			IQueryable<Partner> dbSet = context.Partners;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.IID == key);
		}
		
		public override Partner Activate(Partner entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Partner Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Partner Deactivate(Partner entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Partner Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Partner> GetActive()
		{
			return context.Partners;
		}
		
		public override IQueryable<Partner> GetActive(Expression<Func<Partner, bool>> expr)
		{
			return context.Partners.Where(expr);
		}
		
		public override Partner FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Partner FirstOrDefault(Expression<Func<Partner, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Partner> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Partner> FirstOrDefaultAsync(Expression<Func<Partner, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Partner SingleOrDefault(Expression<Func<Partner, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Partner> SingleOrDefaultAsync(Expression<Func<Partner, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Partner Update(Partner entity)
		{
			entity = context.Partners.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Partner> UpdateAsync(Partner entity)
		{
			entity = context.Partners.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
