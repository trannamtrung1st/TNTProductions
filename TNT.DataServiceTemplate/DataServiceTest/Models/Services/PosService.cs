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
	public partial interface IPosService : IBaseService<Pos, PosViewModel, int>
	{
	}
	
	public partial class PosService : BaseService, IPosService
	{
		private IPosRepository repository;
		
		public PosService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPosRepository>(uow);
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
		public Pos Add(Pos entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Pos> AddAsync(Pos entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Pos Update(Pos entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Pos> UpdateAsync(Pos entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Pos Delete(Pos entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Pos> DeleteAsync(Pos entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Pos Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Pos> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Pos FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Pos> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Pos Activate(Pos entity)
		{
			return repository.Activate(entity);
		}
		
		public Pos Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Pos Deactivate(Pos entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Pos Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Pos> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Pos> GetActive(Expression<Func<Pos, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Pos FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Pos FirstOrDefault(Expression<Func<Pos, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Pos> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Pos> FirstOrDefaultAsync(Expression<Func<Pos, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public PosService()
		{
			repository = G.TContainer.Resolve<IPosRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PosService()
		{
			Dispose(false);
		}
		#endregion
	}
}
