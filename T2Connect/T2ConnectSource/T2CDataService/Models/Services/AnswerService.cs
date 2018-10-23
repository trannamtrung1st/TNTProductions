using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using T2CDataService.Utilities;
using T2CDataService.ViewModels;
using T2CDataService.Models.Repositories;
using T2CDataService.Global;
using TNT.IoContainer.Wrapper;

namespace T2CDataService.Models.Services
{
	public partial interface IAnswerService : IBaseService<Answer, AnswerViewModel, int>
	{
	}
	
	public partial class AnswerService : BaseService, IAnswerService
	{
		private IAnswerRepository repository;
		
		public AnswerService(T2CEntities context)
		{
			repository = G.TContainer.Resolve<IAnswerRepository>(context);
		}
		
		public override bool AutoSave
		{
			get
			{
				return repository.AutoSave;
			}
			set
			{
				repository.AutoSave = value;
			}
		}
		
		#region CRUD Area
		public Answer Add(Answer entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Answer> AddAsync(Answer entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Answer Update(Answer entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Answer> UpdateAsync(Answer entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Answer Delete(Answer entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Answer> DeleteAsync(Answer entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Answer Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Answer> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Answer FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Answer> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Answer Activate(Answer entity)
		{
			return repository.Activate(entity);
		}
		
		public Answer Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Answer Deactivate(Answer entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Answer Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Answer> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Answer> GetActive(Expression<Func<Answer, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Answer FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Answer FirstOrDefault(Expression<Func<Answer, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Answer> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Answer> FirstOrDefaultAsync(Expression<Func<Answer, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
	}
}
