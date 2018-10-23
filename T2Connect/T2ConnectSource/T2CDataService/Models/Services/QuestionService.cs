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
	public partial interface IQuestionService : IBaseService<Question, QuestionViewModel, int>
	{
	}
	
	public partial class QuestionService : BaseService, IQuestionService
	{
		private IQuestionRepository repository;
		
		public QuestionService(T2CEntities context)
		{
			repository = G.TContainer.Resolve<IQuestionRepository>(context);
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
		public Question Add(Question entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Question> AddAsync(Question entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Question Update(Question entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Question> UpdateAsync(Question entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Question Delete(Question entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Question> DeleteAsync(Question entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Question Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Question> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Question FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Question> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Question Activate(Question entity)
		{
			return repository.Activate(entity);
		}
		
		public Question Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Question Deactivate(Question entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Question Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Question> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Question> GetActive(Expression<Func<Question, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Question FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Question FirstOrDefault(Expression<Func<Question, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Question> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Question> FirstOrDefaultAsync(Expression<Func<Question, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
	}
}
