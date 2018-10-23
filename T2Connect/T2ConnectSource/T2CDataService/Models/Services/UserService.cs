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
	public partial interface IUserService : IBaseService<User, UserViewModel, int>
	{
	}
	
	public partial class UserService : BaseService, IUserService
	{
		private IUserRepository repository;
		
		public UserService(T2CEntities context)
		{
			repository = G.TContainer.Resolve<IUserRepository>(context);
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
		public User Add(User entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<User> AddAsync(User entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public User Update(User entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<User> UpdateAsync(User entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public User Delete(User entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<User> DeleteAsync(User entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public User Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<User> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public User FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<User> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public User Activate(User entity)
		{
			return repository.Activate(entity);
		}
		
		public User Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public User Deactivate(User entity)
		{
			return repository.Deactivate(entity);
		}
		
		public User Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<User> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<User> GetActive(Expression<Func<User, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public User FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public User FirstOrDefault(Expression<Func<User, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<User> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<User> FirstOrDefaultAsync(Expression<Func<User, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
	}
}
