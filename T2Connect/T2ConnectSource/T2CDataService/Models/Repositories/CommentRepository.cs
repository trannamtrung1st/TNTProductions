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
	public partial interface ICommentRepository : IBaseRepository<Comment, int>
	{
	}
	
	public partial class CommentRepository : BaseRepository<Comment, int>, ICommentRepository
	{
		public CommentRepository() : base()
		{
		}
		
		public CommentRepository(T2CEntities context) : base(context)
		{
		}
		
		#region CRUD Area
		public override Comment Add(Comment entity)
		{
			entity = context.Comments.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Comment> AddAsync(Comment entity)
		{
			entity = context.Comments.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Comment Delete(Comment entity)
		{
			entity = context.Comments.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Comment> DeleteAsync(Comment entity)
		{
			entity = context.Comments.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Comment Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Comments.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Comment> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Comments.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Comment FindById(int key)
		{
			var entity = context.Comments.FirstOrDefault(
				e => e.CommentId == key);
			return entity;
		}
		
		public override Comment FindActiveById(int key)
		{
			var entity = context.Comments.FirstOrDefault(
				e => e.CommentId == key && !e.Deactive);
			return entity;
		}
		
		public override async Task<Comment> FindByIdAsync(int key)
		{
			return await Task.Run(() =>
			{
				var entity = context.Comments.FirstOrDefault(
					e => e.CommentId == key);
				return entity;
			});
		}
		
		public override async Task<Comment> FindActiveByIdAsync(int key)
		{
			return await Task.Run(() =>
			{
				var entity = context.Comments.FirstOrDefault(
					e => e.CommentId == key && !e.Deactive);
				return entity;
			});
		}
		
		public override Comment FindByIdInclude<TProperty>(int key, params Expression<Func<Comment, TProperty>>[] members)
		{
			IQueryable<Comment> dbSet = context.Comments;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.CommentId == key);
		}
		
		public override async Task<Comment> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Comment, TProperty>>[] members)
		{
			return await Task.Run(() =>
			{
				IQueryable<Comment> dbSet = context.Comments;
				foreach (var m in members)
				{
					dbSet = dbSet.Include(m);
				}
				
				return dbSet.FirstOrDefault(
					e => e.CommentId == key);
			});
		}
		
		public override Comment Activate(Comment entity)
		{
			entity.Deactive = false; Update(entity); return entity;
		}
		
		public override Comment Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Deactive = false;
				Update(entity);
			}
			return entity;
		}
		
		public override Comment Deactivate(Comment entity)
		{
			entity.Deactive = true; Update(entity); return entity;
		}
		
		public override Comment Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Deactive = true;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<Comment> GetActive()
		{
			return context.Comments.Where(e => !e.Deactive);
		}
		
		public override IQueryable<Comment> GetActive(Expression<Func<Comment, bool>> expr)
		{
			return context.Comments.Where(e => !e.Deactive).Where(expr);
		}
		
		public override Comment FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Comment FirstOrDefault(Expression<Func<Comment, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Comment> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Comment> FirstOrDefaultAsync(Expression<Func<Comment, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Comment SingleOrDefault(Expression<Func<Comment, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Comment> SingleOrDefaultAsync(Expression<Func<Comment, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Comment Update(Comment entity)
		{
			entity = context.Comments.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Comment> UpdateAsync(Comment entity)
		{
			entity = context.Comments.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
