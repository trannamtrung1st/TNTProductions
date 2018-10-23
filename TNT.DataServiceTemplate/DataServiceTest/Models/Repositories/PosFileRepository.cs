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
	public partial interface IPosFileRepository : IBaseRepository<PosFile, int>
	{
	}
	
	public partial class PosFileRepository : BaseRepository<PosFile, int>, IPosFileRepository
	{
		public PosFileRepository() : base()
		{
		}
		
		public PosFileRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PosFile Add(PosFile entity)
		{
			
			entity = context.PosFiles.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PosFile> AddAsync(PosFile entity)
		{
			
			entity = context.PosFiles.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override PosFile Delete(PosFile entity)
		{
			context.PosFiles.Attach(entity);
			entity = context.PosFiles.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PosFile> DeleteAsync(PosFile entity)
		{
			context.PosFiles.Attach(entity);
			entity = context.PosFiles.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override PosFile Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.PosFiles.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PosFile> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.PosFiles.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override PosFile FindById(int key)
		{
			var entity = context.PosFiles.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override PosFile FindActiveById(int key)
		{
			var entity = context.PosFiles.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<PosFile> FindByIdAsync(int key)
		{
			var entity = await context.PosFiles.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<PosFile> FindActiveByIdAsync(int key)
		{
			var entity = await context.PosFiles.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override PosFile FindByIdInclude<TProperty>(int key, params Expression<Func<PosFile, TProperty>>[] members)
		{
			IQueryable<PosFile> dbSet = context.PosFiles;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<PosFile> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<PosFile, TProperty>>[] members)
		{
			IQueryable<PosFile> dbSet = context.PosFiles;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override PosFile Activate(PosFile entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PosFile Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PosFile Deactivate(PosFile entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PosFile Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<PosFile> GetActive()
		{
			return context.PosFiles;
		}
		
		public override IQueryable<PosFile> GetActive(Expression<Func<PosFile, bool>> expr)
		{
			return context.PosFiles.Where(expr);
		}
		
		public override PosFile FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override PosFile FirstOrDefault(Expression<Func<PosFile, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<PosFile> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<PosFile> FirstOrDefaultAsync(Expression<Func<PosFile, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override PosFile SingleOrDefault(Expression<Func<PosFile, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<PosFile> SingleOrDefaultAsync(Expression<Func<PosFile, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override PosFile Update(PosFile entity)
		{
			entity = context.PosFiles.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PosFile> UpdateAsync(PosFile entity)
		{
			entity = context.PosFiles.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
