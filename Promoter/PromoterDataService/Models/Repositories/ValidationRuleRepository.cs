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
	public partial interface IValidationRuleRepository : IBaseRepository<ValidationRule, int>
	{
	}
	
	public partial class ValidationRuleRepository : BaseRepository<ValidationRule, int>, IValidationRuleRepository
	{
		public ValidationRuleRepository() : base()
		{
		}
		
		public ValidationRuleRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override ValidationRule Add(ValidationRule entity)
		{
			
			entity = context.ValidationRules.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ValidationRule> AddAsync(ValidationRule entity)
		{
			
			entity = context.ValidationRules.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override ValidationRule Delete(ValidationRule entity)
		{
			context.ValidationRules.Attach(entity);
			entity = context.ValidationRules.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ValidationRule> DeleteAsync(ValidationRule entity)
		{
			context.ValidationRules.Attach(entity);
			entity = context.ValidationRules.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override ValidationRule Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.ValidationRules.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ValidationRule> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.ValidationRules.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override ValidationRule FindById(int key)
		{
			var entity = context.ValidationRules.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override ValidationRule FindActiveById(int key)
		{
			var entity = context.ValidationRules.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<ValidationRule> FindByIdAsync(int key)
		{
			var entity = await context.ValidationRules.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<ValidationRule> FindActiveByIdAsync(int key)
		{
			var entity = await context.ValidationRules.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override ValidationRule FindByIdInclude<TProperty>(int key, params Expression<Func<ValidationRule, TProperty>>[] members)
		{
			IQueryable<ValidationRule> dbSet = context.ValidationRules;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<ValidationRule> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<ValidationRule, TProperty>>[] members)
		{
			IQueryable<ValidationRule> dbSet = context.ValidationRules;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override ValidationRule Activate(ValidationRule entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override ValidationRule Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override ValidationRule Deactivate(ValidationRule entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override ValidationRule Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<ValidationRule> GetActive()
		{
			return context.ValidationRules;
		}
		
		public override IQueryable<ValidationRule> GetActive(Expression<Func<ValidationRule, bool>> expr)
		{
			return context.ValidationRules.Where(expr);
		}
		
		public override ValidationRule FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override ValidationRule FirstOrDefault(Expression<Func<ValidationRule, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<ValidationRule> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<ValidationRule> FirstOrDefaultAsync(Expression<Func<ValidationRule, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override ValidationRule SingleOrDefault(Expression<Func<ValidationRule, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<ValidationRule> SingleOrDefaultAsync(Expression<Func<ValidationRule, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override ValidationRule Update(ValidationRule entity)
		{
			entity = context.ValidationRules.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ValidationRule> UpdateAsync(ValidationRule entity)
		{
			entity = context.ValidationRules.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
