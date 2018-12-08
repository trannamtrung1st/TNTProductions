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
		public TagRepository(DbContext context) : base(context)
		{
		}
		
		public TagRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Tag FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override Tag FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Tag> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Tag> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
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
			return dbSet;
		}
		
		public override IQueryable<Tag> GetActive(Expression<Func<Tag, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
