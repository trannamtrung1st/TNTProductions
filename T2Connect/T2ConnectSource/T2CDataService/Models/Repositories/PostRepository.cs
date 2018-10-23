using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2CDataService.Models;
using System.Linq.Expressions;
using System.Data.Entity;

namespace T2CDataService.Models.Repositories
{
	public partial interface IPostRepository : IBaseRepository<Post, int>
	{
	}
	
	public partial class PostRepository : BaseRepository<Post, int>, IPostRepository
	{
		public PostRepository() : base()
		{
		}
		
		public PostRepository(T2CEntities context) : base(context)
		{
		}
		
		#region CRUD Area
		public override Post Add(Post entity)
		{
			entity = context.Posts.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Post> AddAsync(Post entity)
		{
			entity = context.Posts.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Post Delete(Post entity)
		{
			entity = context.Posts.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Post> DeleteAsync(Post entity)
		{
			entity = context.Posts.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Post Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Posts.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Post> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Posts.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Post FindById(int key)
		{
			var entity = context.Posts.FirstOrDefault(
				e => e.PostId == key);
			return entity;
		}
		
		public override Post FindActiveById(int key)
		{
			var entity = context.Posts.FirstOrDefault(
				e => e.PostId == key);
			return entity;
		}
		
		public override async Task<Post> FindByIdAsync(int key)
		{
			return await Task.Run(() =>
			{
				var entity = context.Posts.FirstOrDefault(
					e => e.PostId == key);
				return entity;
			});
		}
		
		public override async Task<Post> FindActiveByIdAsync(int key)
		{
			return await Task.Run(() =>
			{
				var entity = context.Posts.FirstOrDefault(
					e => e.PostId == key);
				return entity;
			});
		}
		
		public override Post FindByIdInclude<TProperty>(int key, params Expression<Func<Post, TProperty>>[] members)
		{
			IQueryable<Post> dbSet = context.Posts;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.PostId == key);
		}
		
		public override async Task<Post> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Post, TProperty>>[] members)
		{
			return await Task.Run(() =>
			{
				IQueryable<Post> dbSet = context.Posts;
				foreach (var m in members)
				{
					dbSet = dbSet.Include(m);
				}
				
				return dbSet.FirstOrDefault(
					e => e.PostId == key);
			});
		}
		
		public override Post Activate(Post entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Deactive' column");
		}
		
		public override Post Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Deactive' column");
		}
		
		public override Post Deactivate(Post entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Deactive' column");
		}
		
		public override Post Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Deactive' column");
		}
		
		public override IQueryable<Post> GetActive()
		{
			return context.Posts;
		}
		
		public override IQueryable<Post> GetActive(Expression<Func<Post, bool>> expr)
		{
			return context.Posts.Where(expr);
		}
		
		public override Post FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Post FirstOrDefault(Expression<Func<Post, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Post> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Post> FirstOrDefaultAsync(Expression<Func<Post, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Post SingleOrDefault(Expression<Func<Post, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Post> SingleOrDefaultAsync(Expression<Func<Post, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Post Update(Post entity)
		{
			entity = context.Posts.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Post> UpdateAsync(Post entity)
		{
			entity = context.Posts.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
