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
	public partial interface IQuestionRepository : IBaseRepository<Question, int>
	{
	}
	
	public partial class QuestionRepository : BaseRepository<Question, int>, IQuestionRepository
	{
		public QuestionRepository() : base()
		{
		}
		
		public QuestionRepository(T2CEntities context) : base(context)
		{
		}
		
		#region CRUD Area
		public override Question Add(Question entity)
		{
			entity = context.Questions.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Question> AddAsync(Question entity)
		{
			entity = context.Questions.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Question Delete(Question entity)
		{
			entity = context.Questions.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Question> DeleteAsync(Question entity)
		{
			entity = context.Questions.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Question Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Questions.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Question> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Questions.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Question FindById(int key)
		{
			var entity = context.Questions.FirstOrDefault(
				e => e.QuestionId == key);
			return entity;
		}
		
		public override Question FindActiveById(int key)
		{
			var entity = context.Questions.FirstOrDefault(
				e => e.QuestionId == key && !e.Deactive);
			return entity;
		}
		
		public override async Task<Question> FindByIdAsync(int key)
		{
			return await Task.Run(() =>
			{
				var entity = context.Questions.FirstOrDefault(
					e => e.QuestionId == key);
				return entity;
			});
		}
		
		public override async Task<Question> FindActiveByIdAsync(int key)
		{
			return await Task.Run(() =>
			{
				var entity = context.Questions.FirstOrDefault(
					e => e.QuestionId == key && !e.Deactive);
				return entity;
			});
		}
		
		public override Question FindByIdInclude<TProperty>(int key, params Expression<Func<Question, TProperty>>[] members)
		{
			IQueryable<Question> dbSet = context.Questions;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.QuestionId == key);
		}
		
		public override async Task<Question> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Question, TProperty>>[] members)
		{
			return await Task.Run(() =>
			{
				IQueryable<Question> dbSet = context.Questions;
				foreach (var m in members)
				{
					dbSet = dbSet.Include(m);
				}
				
				return dbSet.FirstOrDefault(
					e => e.QuestionId == key);
			});
		}
		
		public override Question Activate(Question entity)
		{
			entity.Deactive = false; Update(entity); return entity;
		}
		
		public override Question Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Deactive = false;
				Update(entity);
			}
			return entity;
		}
		
		public override Question Deactivate(Question entity)
		{
			entity.Deactive = true; Update(entity); return entity;
		}
		
		public override Question Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Deactive = true;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<Question> GetActive()
		{
			return context.Questions.Where(e => !e.Deactive);
		}
		
		public override IQueryable<Question> GetActive(Expression<Func<Question, bool>> expr)
		{
			return context.Questions.Where(e => !e.Deactive).Where(expr);
		}
		
		public override Question FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Question FirstOrDefault(Expression<Func<Question, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Question> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Question> FirstOrDefaultAsync(Expression<Func<Question, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Question SingleOrDefault(Expression<Func<Question, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Question> SingleOrDefaultAsync(Expression<Func<Question, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Question Update(Question entity)
		{
			entity = context.Questions.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Question> UpdateAsync(Question entity)
		{
			entity = context.Questions.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
