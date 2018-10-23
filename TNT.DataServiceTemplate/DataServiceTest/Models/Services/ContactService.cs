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
	public partial interface IContactService : IBaseService<Contact, ContactViewModel, int>
	{
	}
	
	public partial class ContactService : BaseService, IContactService
	{
		private IContactRepository repository;
		
		public ContactService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IContactRepository>(uow);
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
		public Contact Add(Contact entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Contact> AddAsync(Contact entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Contact Update(Contact entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Contact> UpdateAsync(Contact entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Contact Delete(Contact entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Contact> DeleteAsync(Contact entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Contact Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Contact> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Contact FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Contact> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Contact Activate(Contact entity)
		{
			return repository.Activate(entity);
		}
		
		public Contact Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Contact Deactivate(Contact entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Contact Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Contact> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Contact> GetActive(Expression<Func<Contact, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Contact FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Contact FirstOrDefault(Expression<Func<Contact, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Contact> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Contact> FirstOrDefaultAsync(Expression<Func<Contact, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public ContactService()
		{
			repository = G.TContainer.Resolve<IContactRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ContactService()
		{
			Dispose(false);
		}
		#endregion
	}
}
