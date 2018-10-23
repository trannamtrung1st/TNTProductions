using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DataServiceTest.Utilities;
using DataServiceTest.Managers;
using DataServiceTest.ViewModels;
using DataServiceTest.Models.Repositories;
using DataServiceTest.Global;
using TNT.IoContainer.Wrapper;

namespace DataServiceTest.Models.Services
{
	public partial interface ITokenUserService : IBaseService<TokenUser, TokenUserViewModel, int>
	{
	}
	
	public partial class TokenUserService : BaseService, ITokenUserService
	{
		private ITokenUserRepository repository;
		
		public TokenUserService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ITokenUserRepository>(uow);
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
		public TokenUser Add(TokenUser entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<TokenUser> AddAsync(TokenUser entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public TokenUser Update(TokenUser entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<TokenUser> UpdateAsync(TokenUser entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public TokenUser Delete(TokenUser entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<TokenUser> DeleteAsync(TokenUser entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public TokenUser Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<TokenUser> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public TokenUser FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<TokenUser> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public TokenUser Activate(TokenUser entity)
		{
			return repository.Activate(entity);
		}
		
		public TokenUser Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public TokenUser Deactivate(TokenUser entity)
		{
			return repository.Deactivate(entity);
		}
		
		public TokenUser Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<TokenUser> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<TokenUser> GetActive(Expression<Func<TokenUser, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public TokenUser FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public TokenUser FirstOrDefault(Expression<Func<TokenUser, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<TokenUser> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<TokenUser> FirstOrDefaultAsync(Expression<Func<TokenUser, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public TokenUserService()
		{
			repository = G.TContainer.Resolve<ITokenUserRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~TokenUserService()
		{
			Dispose(false);
		}
		#endregion
	}
}
