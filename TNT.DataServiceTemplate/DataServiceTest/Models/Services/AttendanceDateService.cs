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
	public partial interface IAttendanceDateService : IBaseService<AttendanceDate, AttendanceDateViewModel, int>
	{
	}
	
	public partial class AttendanceDateService : BaseService, IAttendanceDateService
	{
		private IAttendanceDateRepository repository;
		
		public AttendanceDateService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IAttendanceDateRepository>(uow);
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
		public AttendanceDate Add(AttendanceDate entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<AttendanceDate> AddAsync(AttendanceDate entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public AttendanceDate Update(AttendanceDate entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<AttendanceDate> UpdateAsync(AttendanceDate entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public AttendanceDate Delete(AttendanceDate entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<AttendanceDate> DeleteAsync(AttendanceDate entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public AttendanceDate Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<AttendanceDate> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public AttendanceDate FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<AttendanceDate> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public AttendanceDate Activate(AttendanceDate entity)
		{
			return repository.Activate(entity);
		}
		
		public AttendanceDate Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public AttendanceDate Deactivate(AttendanceDate entity)
		{
			return repository.Deactivate(entity);
		}
		
		public AttendanceDate Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<AttendanceDate> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<AttendanceDate> GetActive(Expression<Func<AttendanceDate, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public AttendanceDate FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public AttendanceDate FirstOrDefault(Expression<Func<AttendanceDate, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<AttendanceDate> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<AttendanceDate> FirstOrDefaultAsync(Expression<Func<AttendanceDate, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public AttendanceDateService()
		{
			repository = G.TContainer.Resolve<IAttendanceDateRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~AttendanceDateService()
		{
			Dispose(false);
		}
		#endregion
	}
}
