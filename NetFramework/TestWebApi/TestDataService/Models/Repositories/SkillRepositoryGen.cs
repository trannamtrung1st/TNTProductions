using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.Models;
using TestDataService.Managers;
using System.Linq.Expressions;
using System.Data.Entity;

namespace TestDataService.Models.Repositories
{
	public partial interface ISkillRepository : IBaseRepository<Skill, int>
	{
	}
	
	public partial class SkillRepository : BaseRepository<Skill, int>, ISkillRepository
	{
		public SkillRepository(EmployeeManagerEntities context) : base(context)
		{
		}
		
		public SkillRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Skill Add(Skill entity)
		{
			
			entity = context.Skills.Add(entity);
			return entity;
		}
		
		public override Skill Remove(Skill entity)
		{
			context.Skills.Attach(entity);
			entity = context.Skills.Remove(entity);
			return entity;
		}
		
		public override Skill Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Skills.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<Skill> RemoveIf(Expression<Func<Skill, bool>> expr)
		{
			return context.Skills.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<Skill> RemoveRange(IEnumerable<Skill> list)
		{
			return context.Skills.RemoveRange(list);
		}
		
		public override Skill FindById(int key)
		{
			var entity = context.Skills.FirstOrDefault(
				e => e.SkillId == key);
			return entity;
		}
		
		public override Skill FindActiveById(int key)
		{
			var entity = context.Skills.FirstOrDefault(
				e => e.SkillId == key);
			return entity;
		}
		
		public override async Task<Skill> FindByIdAsync(int key)
		{
			var entity = await context.Skills.FirstOrDefaultAsync(
				e => e.SkillId == key);
			return entity;
		}
		
		public override async Task<Skill> FindActiveByIdAsync(int key)
		{
			var entity = await context.Skills.FirstOrDefaultAsync(
				e => e.SkillId == key);
			return entity;
		}
		
		public override Skill FindByIdInclude<TProperty>(int key, params Expression<Func<Skill, TProperty>>[] members)
		{
			IQueryable<Skill> dbSet = context.Skills;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.SkillId == key);
		}
		
		public override async Task<Skill> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Skill, TProperty>>[] members)
		{
			IQueryable<Skill> dbSet = context.Skills;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.SkillId == key);
		}
		
		public override Skill Activate(Skill entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Skill Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Skill Deactivate(Skill entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Skill Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Skill> GetActive()
		{
			return context.Skills;
		}
		
		public override IQueryable<Skill> GetActive(Expression<Func<Skill, bool>> expr)
		{
			return context.Skills.Where(expr);
		}
		
		public override Skill FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Skill FirstOrDefault(Expression<Func<Skill, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Skill> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Skill> FirstOrDefaultAsync(Expression<Func<Skill, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Skill SingleOrDefault(Expression<Func<Skill, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Skill> SingleOrDefaultAsync(Expression<Func<Skill, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Skill Update(Skill entity)
		{
			entity = context.Skills.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
