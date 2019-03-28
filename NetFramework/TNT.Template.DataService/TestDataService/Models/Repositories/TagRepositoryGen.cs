using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.Models;
using TNT.IoC.Attributes;
using System.Linq.Expressions;
using System.Data.Entity;

namespace TestDataService.Models.Repositories
{
	public partial interface ITagRepository : IBaseRepository<Tag, int>
	{
	}
	
	public partial class TagRepository : BaseRepository<Tag, int>, ITagRepository
	{
		public TagRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		public TagRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override Tag FindById(int key)
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
		
		#endregion
	}
}
