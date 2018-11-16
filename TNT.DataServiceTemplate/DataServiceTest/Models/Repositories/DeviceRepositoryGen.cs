using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.Models;
using DataServiceTest.Managers;
using System.Linq.Expressions;
using System.Data.Entity;

namespace DataServiceTest.Models.Repositories
{
	public partial interface IDeviceRepository : IBaseRepository<Device, int>
	{
	}
	
	public partial class DeviceRepository : BaseRepository<Device, int>, IDeviceRepository
	{
		public DeviceRepository() : base()
		{
		}
		
		public DeviceRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Device Add(Device entity)
		{
			
			entity = context.Devices.Add(entity);
			return entity;
		}
		
		public override Device Remove(Device entity)
		{
			context.Devices.Attach(entity);
			entity = context.Devices.Remove(entity);
			return entity;
		}
		
		public override Device Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Devices.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<Device> RemoveIf(Expression<Func<Device, bool>> expr)
		{
			return context.Devices.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<Device> RemoveRange(IEnumerable<Device> list)
		{
			return context.Devices.RemoveRange(list);
		}
		
		public override Device FindById(int key)
		{
			var entity = context.Devices.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override Device FindActiveById(int key)
		{
			var entity = context.Devices.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Device> FindByIdAsync(int key)
		{
			var entity = await context.Devices.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Device> FindActiveByIdAsync(int key)
		{
			var entity = await context.Devices.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override Device FindByIdInclude<TProperty>(int key, params Expression<Func<Device, TProperty>>[] members)
		{
			IQueryable<Device> dbSet = context.Devices;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<Device> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Device, TProperty>>[] members)
		{
			IQueryable<Device> dbSet = context.Devices;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override Device Activate(Device entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Device Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Device Deactivate(Device entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Device Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Device> GetActive()
		{
			return context.Devices;
		}
		
		public override IQueryable<Device> GetActive(Expression<Func<Device, bool>> expr)
		{
			return context.Devices.Where(expr);
		}
		
		public override Device FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Device FirstOrDefault(Expression<Func<Device, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Device> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Device> FirstOrDefaultAsync(Expression<Func<Device, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Device SingleOrDefault(Expression<Func<Device, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Device> SingleOrDefaultAsync(Expression<Func<Device, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Device Update(Device entity)
		{
			entity = context.Devices.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
