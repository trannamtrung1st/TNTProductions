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
	public partial interface ICouponService : IBaseService<Coupon, CouponViewModel, int>
	{
	}
	
	public partial class CouponService : BaseService, ICouponService
	{
		private ICouponRepository repository;
		
		public CouponService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICouponRepository>(uow);
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
		public Coupon Add(Coupon entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Coupon> AddAsync(Coupon entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Coupon Update(Coupon entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Coupon> UpdateAsync(Coupon entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Coupon Delete(Coupon entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Coupon> DeleteAsync(Coupon entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Coupon Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Coupon> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Coupon FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Coupon> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Coupon Activate(Coupon entity)
		{
			return repository.Activate(entity);
		}
		
		public Coupon Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Coupon Deactivate(Coupon entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Coupon Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Coupon> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Coupon> GetActive(Expression<Func<Coupon, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Coupon FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Coupon FirstOrDefault(Expression<Func<Coupon, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Coupon> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Coupon> FirstOrDefaultAsync(Expression<Func<Coupon, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public CouponService()
		{
			repository = G.TContainer.Resolve<ICouponRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~CouponService()
		{
			Dispose(false);
		}
		#endregion
	}
}
