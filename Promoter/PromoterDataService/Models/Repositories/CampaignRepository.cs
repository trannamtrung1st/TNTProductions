﻿using System;
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
	public partial interface ICampaignRepository : IBaseRepository<Campaign, int>
	{
	}
	
	public partial class CampaignRepository : BaseRepository<Campaign, int>, ICampaignRepository
	{
		public CampaignRepository() : base()
		{
		}
		
		public CampaignRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Campaign Add(Campaign entity)
		{
			
			entity = context.Campaigns.Add(entity);
			return entity;
		}
		
		public override Campaign Remove(Campaign entity)
		{
			context.Campaigns.Attach(entity);
			entity = context.Campaigns.Remove(entity);
			return entity;
		}
		
		public override Campaign Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Campaigns.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<Campaign> RemoveIf(Expression<Func<Campaign, bool>> expr)
		{
			return context.Campaigns.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<Campaign> RemoveRange(IEnumerable<Campaign> list)
		{
			return context.Campaigns.RemoveRange(list);
		}
		
		public override Campaign FindById(int key)
		{
			var entity = context.Campaigns.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override Campaign FindActiveById(int key)
		{
			var entity = context.Campaigns.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<Campaign> FindByIdAsync(int key)
		{
			var entity = await context.Campaigns.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<Campaign> FindActiveByIdAsync(int key)
		{
			var entity = await context.Campaigns.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override Campaign FindByIdInclude<TProperty>(int key, params Expression<Func<Campaign, TProperty>>[] members)
		{
			IQueryable<Campaign> dbSet = context.Campaigns;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ID == key);
		}
		
		public override async Task<Campaign> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Campaign, TProperty>>[] members)
		{
			IQueryable<Campaign> dbSet = context.Campaigns;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
		}
		
		public override Campaign Activate(Campaign entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Campaign Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Campaign Deactivate(Campaign entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Campaign Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Campaign> GetActive()
		{
			return context.Campaigns;
		}
		
		public override IQueryable<Campaign> GetActive(Expression<Func<Campaign, bool>> expr)
		{
			return context.Campaigns.Where(expr);
		}
		
		public override Campaign FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Campaign FirstOrDefault(Expression<Func<Campaign, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Campaign> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Campaign> FirstOrDefaultAsync(Expression<Func<Campaign, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Campaign SingleOrDefault(Expression<Func<Campaign, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Campaign> SingleOrDefaultAsync(Expression<Func<Campaign, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Campaign Update(Campaign entity)
		{
			entity = context.Campaigns.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
