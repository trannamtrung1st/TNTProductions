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
	public partial interface ISubRentGroupService : IBaseService<SubRentGroup, SubRentGroupViewModel, int>
	{
	}
	
	public partial class SubRentGroupService : BaseService, ISubRentGroupService
	{
		private ISubRentGroupRepository repository;
		
		public SubRentGroupService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ISubRentGroupRepository>(uow);
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
		public SubRentGroup Add(SubRentGroup entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<SubRentGroup> AddAsync(SubRentGroup entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public SubRentGroup Update(SubRentGroup entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<SubRentGroup> UpdateAsync(SubRentGroup entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public SubRentGroup Delete(SubRentGroup entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<SubRentGroup> DeleteAsync(SubRentGroup entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public SubRentGroup Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<SubRentGroup> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public SubRentGroup FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<SubRentGroup> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public SubRentGroup Activate(SubRentGroup entity)
		{
			return repository.Activate(entity);
		}
		
		public SubRentGroup Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public SubRentGroup Deactivate(SubRentGroup entity)
		{
			return repository.Deactivate(entity);
		}
		
		public SubRentGroup Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<SubRentGroup> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<SubRentGroup> GetActive(Expression<Func<SubRentGroup, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public SubRentGroup FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public SubRentGroup FirstOrDefault(Expression<Func<SubRentGroup, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<SubRentGroup> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<SubRentGroup> FirstOrDefaultAsync(Expression<Func<SubRentGroup, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public SubRentGroupService()
		{
			repository = G.TContainer.Resolve<ISubRentGroupRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~SubRentGroupService()
		{
			Dispose(false);
		}
		#endregion
	}
}
