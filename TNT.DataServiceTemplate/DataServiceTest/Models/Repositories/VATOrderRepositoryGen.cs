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
	public partial interface IVATOrderRepository : IBaseRepository<VATOrder, int>
	{
	}
	
	public partial class VATOrderRepository : BaseRepository<VATOrder, int>, IVATOrderRepository
	{
		public VATOrderRepository() : base()
		{
		}
		
		public VATOrderRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override VATOrder Add(VATOrder entity)
		{
			
			entity = context.VATOrders.Add(entity);
			return entity;
		}
		
		public override VATOrder Remove(VATOrder entity)
		{
			context.VATOrders.Attach(entity);
			entity = context.VATOrders.Remove(entity);
			return entity;
		}
		
		public override VATOrder Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.VATOrders.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<VATOrder> RemoveIf(Expression<Func<VATOrder, bool>> expr)
		{
			return context.VATOrders.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<VATOrder> RemoveRange(IEnumerable<VATOrder> list)
		{
			return context.VATOrders.RemoveRange(list);
		}
		
		public override VATOrder FindById(int key)
		{
			var entity = context.VATOrders.FirstOrDefault(
				e => e.InvoiceID == key);
			return entity;
		}
		
		public override VATOrder FindActiveById(int key)
		{
			var entity = context.VATOrders.FirstOrDefault(
				e => e.InvoiceID == key);
			return entity;
		}
		
		public override async Task<VATOrder> FindByIdAsync(int key)
		{
			var entity = await context.VATOrders.FirstOrDefaultAsync(
				e => e.InvoiceID == key);
			return entity;
		}
		
		public override async Task<VATOrder> FindActiveByIdAsync(int key)
		{
			var entity = await context.VATOrders.FirstOrDefaultAsync(
				e => e.InvoiceID == key);
			return entity;
		}
		
		public override VATOrder FindByIdInclude<TProperty>(int key, params Expression<Func<VATOrder, TProperty>>[] members)
		{
			IQueryable<VATOrder> dbSet = context.VATOrders;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.InvoiceID == key);
		}
		
		public override async Task<VATOrder> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<VATOrder, TProperty>>[] members)
		{
			IQueryable<VATOrder> dbSet = context.VATOrders;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.InvoiceID == key);
		}
		
		public override VATOrder Activate(VATOrder entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override VATOrder Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override VATOrder Deactivate(VATOrder entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override VATOrder Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<VATOrder> GetActive()
		{
			return context.VATOrders;
		}
		
		public override IQueryable<VATOrder> GetActive(Expression<Func<VATOrder, bool>> expr)
		{
			return context.VATOrders.Where(expr);
		}
		
		public override VATOrder FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override VATOrder FirstOrDefault(Expression<Func<VATOrder, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<VATOrder> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<VATOrder> FirstOrDefaultAsync(Expression<Func<VATOrder, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override VATOrder SingleOrDefault(Expression<Func<VATOrder, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<VATOrder> SingleOrDefaultAsync(Expression<Func<VATOrder, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override VATOrder Update(VATOrder entity)
		{
			entity = context.VATOrders.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
