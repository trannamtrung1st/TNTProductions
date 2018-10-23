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
	public partial interface IAttendanceService : IBaseService<Attendance, AttendanceViewModel, int>
	{
	}
	
	public partial class AttendanceService : BaseService, IAttendanceService
	{
		private IAttendanceRepository repository;
		
		public AttendanceService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IAttendanceRepository>(uow);
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
		public Attendance Add(Attendance entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Attendance> AddAsync(Attendance entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Attendance Update(Attendance entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Attendance> UpdateAsync(Attendance entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Attendance Delete(Attendance entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Attendance> DeleteAsync(Attendance entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Attendance Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Attendance> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Attendance FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Attendance> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Attendance Activate(Attendance entity)
		{
			return repository.Activate(entity);
		}
		
		public Attendance Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Attendance Deactivate(Attendance entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Attendance Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Attendance> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Attendance> GetActive(Expression<Func<Attendance, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Attendance FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Attendance FirstOrDefault(Expression<Func<Attendance, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Attendance> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Attendance> FirstOrDefaultAsync(Expression<Func<Attendance, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public AttendanceService()
		{
			repository = G.TContainer.Resolve<IAttendanceRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~AttendanceService()
		{
			Dispose(false);
		}
		#endregion
	}
}
