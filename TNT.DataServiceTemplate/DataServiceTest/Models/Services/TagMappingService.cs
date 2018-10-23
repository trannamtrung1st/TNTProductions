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
	public partial interface ITagMappingService : IBaseService<TagMapping, TagMappingViewModel, int>
	{
	}
	
	public partial class TagMappingService : BaseService, ITagMappingService
	{
		private ITagMappingRepository repository;
		
		public TagMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ITagMappingRepository>(uow);
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
		public TagMapping Add(TagMapping entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<TagMapping> AddAsync(TagMapping entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public TagMapping Update(TagMapping entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<TagMapping> UpdateAsync(TagMapping entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public TagMapping Delete(TagMapping entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<TagMapping> DeleteAsync(TagMapping entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public TagMapping Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<TagMapping> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public TagMapping FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<TagMapping> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public TagMapping Activate(TagMapping entity)
		{
			return repository.Activate(entity);
		}
		
		public TagMapping Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public TagMapping Deactivate(TagMapping entity)
		{
			return repository.Deactivate(entity);
		}
		
		public TagMapping Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<TagMapping> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<TagMapping> GetActive(Expression<Func<TagMapping, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public TagMapping FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public TagMapping FirstOrDefault(Expression<Func<TagMapping, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<TagMapping> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<TagMapping> FirstOrDefaultAsync(Expression<Func<TagMapping, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public TagMappingService()
		{
			repository = G.TContainer.Resolve<ITagMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~TagMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
