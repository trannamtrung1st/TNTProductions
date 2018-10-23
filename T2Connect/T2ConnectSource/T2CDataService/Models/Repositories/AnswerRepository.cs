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
	public partial interface IAnswerRepository : IBaseRepository<Answer, int>
	{
	}
	
	public partial class AnswerRepository : BaseRepository<Answer, int>, IAnswerRepository
	{
		public AnswerRepository() : base()
		{
		}
		
		public AnswerRepository(T2CEntities context) : base(context)
		{
		}
		
		#region CRUD Area
		public override Answer Add(Answer entity)
		{
			entity = context.Answers.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Answer> AddAsync(Answer entity)
		{
			entity = context.Answers.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Answer Delete(Answer entity)
		{
			entity = context.Answers.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Answer> DeleteAsync(Answer entity)
		{
			entity = context.Answers.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Answer Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Answers.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Answer> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Answers.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Answer FindById(int key)
		{
			var entity = context.Answers.FirstOrDefault(
				e => e.AnswerId == key);
			return entity;
		}
		
		public override Answer FindActiveById(int key)
		{
			var entity = context.Answers.FirstOrDefault(
				e => e.AnswerId == key && !e.Deactive);
			return entity;
		}
		
		public override async Task<Answer> FindByIdAsync(int key)
		{
			return await Task.Run(() =>
			{
				var entity = context.Answers.FirstOrDefault(
					e => e.AnswerId == key);
				return entity;
			});
		}
		
		public override async Task<Answer> FindActiveByIdAsync(int key)
		{
			return await Task.Run(() =>
			{
				var entity = context.Answers.FirstOrDefault(
					e => e.AnswerId == key && !e.Deactive);
				return entity;
			});
		}
		
		public override Answer FindByIdInclude<TProperty>(int key, params Expression<Func<Answer, TProperty>>[] members)
		{
			IQueryable<Answer> dbSet = context.Answers;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.AnswerId == key);
		}
		
		public override async Task<Answer> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Answer, TProperty>>[] members)
		{
			return await Task.Run(() =>
			{
				IQueryable<Answer> dbSet = context.Answers;
				foreach (var m in members)
				{
					dbSet = dbSet.Include(m);
				}
				
				return dbSet.FirstOrDefault(
					e => e.AnswerId == key);
			});
		}
		
		public override Answer Activate(Answer entity)
		{
			entity.Deactive = false; Update(entity); return entity;
		}
		
		public override Answer Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Deactive = false;
				Update(entity);
			}
			return entity;
		}
		
		public override Answer Deactivate(Answer entity)
		{
			entity.Deactive = true; Update(entity); return entity;
		}
		
		public override Answer Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Deactive = true;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<Answer> GetActive()
		{
			return context.Answers.Where(e => !e.Deactive);
		}
		
		public override IQueryable<Answer> GetActive(Expression<Func<Answer, bool>> expr)
		{
			return context.Answers.Where(e => !e.Deactive).Where(expr);
		}
		
		public override Answer FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Answer FirstOrDefault(Expression<Func<Answer, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Answer> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Answer> FirstOrDefaultAsync(Expression<Func<Answer, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Answer SingleOrDefault(Expression<Func<Answer, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Answer> SingleOrDefaultAsync(Expression<Func<Answer, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Answer Update(Answer entity)
		{
			entity = context.Answers.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Answer> UpdateAsync(Answer entity)
		{
			entity = context.Answers.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
