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
	public partial interface ISegmentService : IBaseService<Segment, SegmentViewModel, int>
	{
	}
	
	public partial class SegmentService : BaseService, ISegmentService
	{
		private ISegmentRepository repository;
		
		public SegmentService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ISegmentRepository>(uow);
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
		public Segment Add(Segment entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Segment> AddAsync(Segment entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Segment Update(Segment entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Segment> UpdateAsync(Segment entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Segment Delete(Segment entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Segment> DeleteAsync(Segment entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Segment Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Segment> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Segment FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Segment> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Segment Activate(Segment entity)
		{
			return repository.Activate(entity);
		}
		
		public Segment Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Segment Deactivate(Segment entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Segment Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Segment> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Segment> GetActive(Expression<Func<Segment, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Segment FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Segment FirstOrDefault(Expression<Func<Segment, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Segment> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Segment> FirstOrDefaultAsync(Expression<Func<Segment, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
	}
}
