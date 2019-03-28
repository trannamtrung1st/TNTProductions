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
	public partial interface IAnswerRepository : IBaseRepository<Answer, AnswerPK>
	{
	}
	
	public partial class AnswerRepository : BaseRepository<Answer, AnswerPK>, IAnswerRepository
	{
		public AnswerRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		public AnswerRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override Answer FindById(AnswerPK key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.OfUserId == key.OfUserId && e.ToPostId == key.ToPostId);
			return entity;
		}
		
		public override async Task<Answer> FindByIdAsync(AnswerPK key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.OfUserId == key.OfUserId && e.ToPostId == key.ToPostId);
			return entity;
		}
		
		#endregion
	}
}
