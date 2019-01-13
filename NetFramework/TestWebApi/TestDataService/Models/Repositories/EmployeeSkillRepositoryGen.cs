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
	public partial interface IEmployeeSkillRepository : IBaseRepository<EmployeeSkill, EmployeeSkillPK>
	{
	}
	
	public partial class EmployeeSkillRepository : BaseRepository<EmployeeSkill, EmployeeSkillPK>, IEmployeeSkillRepository
	{
		public EmployeeSkillRepository(EmployeeManagerEntities context) : base(context)
		{
		}
		
		public EmployeeSkillRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override EmployeeSkill Add(EmployeeSkill entity)
		{
			
			entity = context.EmployeeSkills.Add(entity);
			return entity;
		}
		
		public override EmployeeSkill Remove(EmployeeSkill entity)
		{
			context.EmployeeSkills.Attach(entity);
			entity = context.EmployeeSkills.Remove(entity);
			return entity;
		}
		
		public override EmployeeSkill Remove(EmployeeSkillPK key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.EmployeeSkills.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<EmployeeSkill> RemoveIf(Expression<Func<EmployeeSkill, bool>> expr)
		{
			return context.EmployeeSkills.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<EmployeeSkill> RemoveRange(IEnumerable<EmployeeSkill> list)
		{
			return context.EmployeeSkills.RemoveRange(list);
		}
		
		public override EmployeeSkill FindById(EmployeeSkillPK key)
		{
			var entity = context.EmployeeSkills.FirstOrDefault(
				e => e.EmpCode == key.EmpCode && e.SkillId == key.SkillId);
			return entity;
		}
		
		public override EmployeeSkill FindActiveById(EmployeeSkillPK key)
		{
			var entity = context.EmployeeSkills.FirstOrDefault(
				e => e.EmpCode == key.EmpCode && e.SkillId == key.SkillId);
			return entity;
		}
		
		public override async Task<EmployeeSkill> FindByIdAsync(EmployeeSkillPK key)
		{
			var entity = await context.EmployeeSkills.FirstOrDefaultAsync(
				e => e.EmpCode == key.EmpCode && e.SkillId == key.SkillId);
			return entity;
		}
		
		public override async Task<EmployeeSkill> FindActiveByIdAsync(EmployeeSkillPK key)
		{
			var entity = await context.EmployeeSkills.FirstOrDefaultAsync(
				e => e.EmpCode == key.EmpCode && e.SkillId == key.SkillId);
			return entity;
		}
		
		public override EmployeeSkill FindByIdInclude<TProperty>(EmployeeSkillPK key, params Expression<Func<EmployeeSkill, TProperty>>[] members)
		{
			IQueryable<EmployeeSkill> dbSet = context.EmployeeSkills;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.EmpCode == key.EmpCode && e.SkillId == key.SkillId);
		}
		
		public override async Task<EmployeeSkill> FindByIdIncludeAsync<TProperty>(EmployeeSkillPK key, params Expression<Func<EmployeeSkill, TProperty>>[] members)
		{
			IQueryable<EmployeeSkill> dbSet = context.EmployeeSkills;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.EmpCode == key.EmpCode && e.SkillId == key.SkillId);
		}
		
		public override EmployeeSkill Activate(EmployeeSkill entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override EmployeeSkill Activate(EmployeeSkillPK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override EmployeeSkill Deactivate(EmployeeSkill entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override EmployeeSkill Deactivate(EmployeeSkillPK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<EmployeeSkill> GetActive()
		{
			return context.EmployeeSkills;
		}
		
		public override IQueryable<EmployeeSkill> GetActive(Expression<Func<EmployeeSkill, bool>> expr)
		{
			return context.EmployeeSkills.Where(expr);
		}
		
		public override EmployeeSkill FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override EmployeeSkill FirstOrDefault(Expression<Func<EmployeeSkill, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<EmployeeSkill> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<EmployeeSkill> FirstOrDefaultAsync(Expression<Func<EmployeeSkill, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override EmployeeSkill SingleOrDefault(Expression<Func<EmployeeSkill, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<EmployeeSkill> SingleOrDefaultAsync(Expression<Func<EmployeeSkill, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override EmployeeSkill Update(EmployeeSkill entity)
		{
			entity = context.EmployeeSkills.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
