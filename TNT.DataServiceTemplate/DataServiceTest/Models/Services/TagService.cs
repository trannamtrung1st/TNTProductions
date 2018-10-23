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
	public partial interface ITagService : IBaseService<Tag, TagViewModel, int>
	{
	}
	
	public partial class TagService : BaseService, ITagService
	{
		private ITagRepository repository;
		
		public TagService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ITagRepository>(uow);
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
		public Tag Add(Tag entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Tag> AddAsync(Tag entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Tag Update(Tag entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Tag> UpdateAsync(Tag entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Tag Delete(Tag entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Tag> DeleteAsync(Tag entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Tag Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Tag> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Tag FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Tag> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Tag Activate(Tag entity)
		{
			return repository.Activate(entity);
		}
		
		public Tag Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Tag Deactivate(Tag entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Tag Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Tag> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Tag> GetActive(Expression<Func<Tag, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Tag FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Tag FirstOrDefault(Expression<Func<Tag, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Tag> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Tag> FirstOrDefaultAsync(Expression<Func<Tag, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public TagService()
		{
			repository = G.TContainer.Resolve<ITagRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~TagService()
		{
			Dispose(false);
		}
		#endregion
	}
}
