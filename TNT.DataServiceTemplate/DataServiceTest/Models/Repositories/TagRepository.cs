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
	public partial interface ITagRepository : IBaseRepository<Tag, int>
	{
	}
	
	public partial class TagRepository : BaseRepository<Tag, int>, ITagRepository
	{
		public TagRepository() : base()
		{
		}
		
		public TagRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Tag Add(Tag entity)
		{
			
			entity = context.Tags.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Tag> AddAsync(Tag entity)
		{
			
			entity = context.Tags.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Tag Delete(Tag entity)
		{
			context.Tags.Attach(entity);
			entity = context.Tags.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Tag> DeleteAsync(Tag entity)
		{
			context.Tags.Attach(entity);
			entity = context.Tags.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Tag Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Tags.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Tag> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Tags.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Tag FindById(int key)
		{
			var entity = context.Tags.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override Tag FindActiveById(int key)
		{
			var entity = context.Tags.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Tag> FindByIdAsync(int key)
		{
			var entity = await context.Tags.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Tag> FindActiveByIdAsync(int key)
		{
			var entity = await context.Tags.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override Tag FindByIdInclude<TProperty>(int key, params Expression<Func<Tag, TProperty>>[] members)
		{
			IQueryable<Tag> dbSet = context.Tags;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<Tag> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Tag, TProperty>>[] members)
		{
			IQueryable<Tag> dbSet = context.Tags;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override Tag Activate(Tag entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Tag Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Tag Deactivate(Tag entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Tag Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Tag> GetActive()
		{
			return context.Tags;
		}
		
		public override IQueryable<Tag> GetActive(Expression<Func<Tag, bool>> expr)
		{
			return context.Tags.Where(expr);
		}
		
		public override Tag FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Tag FirstOrDefault(Expression<Func<Tag, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Tag> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Tag> FirstOrDefaultAsync(Expression<Func<Tag, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Tag SingleOrDefault(Expression<Func<Tag, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Tag> SingleOrDefaultAsync(Expression<Func<Tag, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Tag Update(Tag entity)
		{
			entity = context.Tags.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Tag> UpdateAsync(Tag entity)
		{
			entity = context.Tags.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
