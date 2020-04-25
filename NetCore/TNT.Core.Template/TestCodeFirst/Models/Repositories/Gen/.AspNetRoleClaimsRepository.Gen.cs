using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCodeFirst.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TestCodeFirst.Models.Repositories
{
	public partial interface I.AspNetRoleClaimsRepository : IBaseRepository<.AspNetRoleClaims, int>
	{
	}
	
	public partial class .AspNetRoleClaimsRepository : BaseRepository<.AspNetRoleClaims, int>, I.AspNetRoleClaimsRepository
	{
		public .AspNetRoleClaimsRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override .AspNetRoleClaims FindById(int key)
		{
			var entity = QuerySet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<.AspNetRoleClaims> FindByIdAsync(int key)
		{
			var entity = await QuerySet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override EntityEntry<.AspNetRoleClaims> Remove(int key)
		{
			var entity = new .AspNetRoleClaims { Id = key };
			return dbSet.Remove(entity);
		}
		
		public override IEnumerable<.AspNetRoleClaims> RemoveIf(Expression<Func<.AspNetRoleClaims, bool>> expr)
		{
			var list = dbSet.Where(expr).Select(o => new .AspNetRoleClaims { Id = o.Id }).ToList();
			dbSet.RemoveRange(list);
			return list;
		}
		
		//Default DELETE command, override if there's any exception
		public override async Task<int> SqlRemoveAllAsync()
		{
			var result = await context.Database.ExecuteSqlCommandAsync("DELETE FROM .AspNetRoleClaims");
			return result;
		}
		
		#endregion
	}
}
