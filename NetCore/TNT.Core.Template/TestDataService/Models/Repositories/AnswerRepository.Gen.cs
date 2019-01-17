using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace TestDataService.Models.Repositories
{
	public partial interface IAnswerRepository : IBaseRepository<Answer, AnswerPK>
	{
		Answer FindActiveById(AnswerPK key);
		Task<Answer> FindActiveByIdAsync(AnswerPK key);
		IQueryable<Answer> GetActive();
		IQueryable<Answer> GetActive(Expression<Func<Answer, bool>> expr);
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
		
		public Answer FindActiveById(AnswerPK key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.OfUserId == key.OfUserId && e.ToPostId == key.ToPostId && e.Active == true);
			return entity;
		}
		
		public async Task<Answer> FindActiveByIdAsync(AnswerPK key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.OfUserId == key.OfUserId && e.ToPostId == key.ToPostId && e.Active == true);
			return entity;
		}
		
		public IQueryable<Answer> GetActive()
		{
			return dbSet.Where(e => e.Active == true);
		}
		
		public IQueryable<Answer> GetActive(Expression<Func<Answer, bool>> expr)
		{
			return dbSet.Where(e => e.Active == true).Where(expr);
		}
		
		#endregion
	}
}
