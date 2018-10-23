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
	public partial interface IPosFileService : IBaseService<PosFile, PosFileViewModel, int>
	{
	}
	
	public partial class PosFileService : BaseService, IPosFileService
	{
		private IPosFileRepository repository;
		
		public PosFileService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPosFileRepository>(uow);
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
		public PosFile Add(PosFile entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<PosFile> AddAsync(PosFile entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public PosFile Update(PosFile entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<PosFile> UpdateAsync(PosFile entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public PosFile Delete(PosFile entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<PosFile> DeleteAsync(PosFile entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public PosFile Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<PosFile> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public PosFile FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<PosFile> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public PosFile Activate(PosFile entity)
		{
			return repository.Activate(entity);
		}
		
		public PosFile Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public PosFile Deactivate(PosFile entity)
		{
			return repository.Deactivate(entity);
		}
		
		public PosFile Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<PosFile> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<PosFile> GetActive(Expression<Func<PosFile, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public PosFile FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public PosFile FirstOrDefault(Expression<Func<PosFile, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<PosFile> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<PosFile> FirstOrDefaultAsync(Expression<Func<PosFile, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public PosFileService()
		{
			repository = G.TContainer.Resolve<IPosFileRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PosFileService()
		{
			Dispose(false);
		}
		#endregion
	}
}
