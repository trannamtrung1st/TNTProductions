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
	public partial interface ITagMappingRepository : IBaseRepository<TagMapping, int>
	{
	}
	
	public partial class TagMappingRepository : BaseRepository<TagMapping, int>, ITagMappingRepository
	{
		public TagMappingRepository() : base()
		{
		}
		
		public TagMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override TagMapping Add(TagMapping entity)
		{
			
			entity = context.TagMappings.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<TagMapping> AddAsync(TagMapping entity)
		{
			
			entity = context.TagMappings.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override TagMapping Delete(TagMapping entity)
		{
			context.TagMappings.Attach(entity);
			entity = context.TagMappings.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<TagMapping> DeleteAsync(TagMapping entity)
		{
			context.TagMappings.Attach(entity);
			entity = context.TagMappings.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override TagMapping Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.TagMappings.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<TagMapping> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.TagMappings.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override TagMapping FindById(int key)
		{
			var entity = context.TagMappings.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override TagMapping FindActiveById(int key)
		{
			var entity = context.TagMappings.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<TagMapping> FindByIdAsync(int key)
		{
			var entity = await context.TagMappings.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<TagMapping> FindActiveByIdAsync(int key)
		{
			var entity = await context.TagMappings.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override TagMapping FindByIdInclude<TProperty>(int key, params Expression<Func<TagMapping, TProperty>>[] members)
		{
			IQueryable<TagMapping> dbSet = context.TagMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<TagMapping> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<TagMapping, TProperty>>[] members)
		{
			IQueryable<TagMapping> dbSet = context.TagMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override TagMapping Activate(TagMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override TagMapping Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override TagMapping Deactivate(TagMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override TagMapping Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<TagMapping> GetActive()
		{
			return context.TagMappings;
		}
		
		public override IQueryable<TagMapping> GetActive(Expression<Func<TagMapping, bool>> expr)
		{
			return context.TagMappings.Where(expr);
		}
		
		public override TagMapping FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override TagMapping FirstOrDefault(Expression<Func<TagMapping, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<TagMapping> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<TagMapping> FirstOrDefaultAsync(Expression<Func<TagMapping, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override TagMapping SingleOrDefault(Expression<Func<TagMapping, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<TagMapping> SingleOrDefaultAsync(Expression<Func<TagMapping, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override TagMapping Update(TagMapping entity)
		{
			entity = context.TagMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<TagMapping> UpdateAsync(TagMapping entity)
		{
			entity = context.TagMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
