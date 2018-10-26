using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using PromoterDataService.Utilities;
using PromoterDataService.Managers;
using PromoterDataService.ViewModels;
using PromoterDataService.Models.Repositories;
using PromoterDataService.Global;
using TNT.IoContainer.Wrapper;

namespace PromoterDataService.Models.Services
{
	public partial interface ICustomerSegmentService : IBaseService<CustomerSegment, CustomerSegmentViewModel, CustomerSegmentPK>
	{
	}
	
	public partial class CustomerSegmentService : BaseService, ICustomerSegmentService
	{
		private ICustomerSegmentRepository repository;
		
		public CustomerSegmentService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICustomerSegmentRepository>(uow);
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
		public CustomerSegment Add(CustomerSegment entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<CustomerSegment> AddAsync(CustomerSegment entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public CustomerSegment Update(CustomerSegment entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<CustomerSegment> UpdateAsync(CustomerSegment entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public CustomerSegment Delete(CustomerSegment entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<CustomerSegment> DeleteAsync(CustomerSegment entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public CustomerSegment Delete(CustomerSegmentPK key)
		{
			return repository.Delete(key);
		}
		
		public async Task<CustomerSegment> DeleteAsync(CustomerSegmentPK key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public CustomerSegment FindById(CustomerSegmentPK key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<CustomerSegment> FindByIdAsync(CustomerSegmentPK key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public CustomerSegment Activate(CustomerSegment entity)
		{
			return repository.Activate(entity);
		}
		
		public CustomerSegment Activate(CustomerSegmentPK key)
		{
			return repository.Activate(key);
		}
		
		public CustomerSegment Deactivate(CustomerSegment entity)
		{
			return repository.Deactivate(entity);
		}
		
		public CustomerSegment Deactivate(CustomerSegmentPK key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<CustomerSegment> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<CustomerSegment> GetActive(Expression<Func<CustomerSegment, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public CustomerSegment FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public CustomerSegment FirstOrDefault(Expression<Func<CustomerSegment, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<CustomerSegment> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<CustomerSegment> FirstOrDefaultAsync(Expression<Func<CustomerSegment, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
	}
}
