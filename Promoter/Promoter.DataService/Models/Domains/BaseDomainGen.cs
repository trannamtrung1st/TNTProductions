using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Promoter.DataService.Models.Services;
using Promoter.DataService.ViewModels;
using Promoter.DataService.Managers;
using Promoter.DataService.Utilities;
using Promoter.DataService.Models;
using Promoter.DataService.Global;
using System.Data.Entity;
using System.Linq.Expressions;
using TNT.IoContainer.Wrapper;

namespace Promoter.DataService.Models.Domains
{
	public abstract partial class BaseDomain
	{
		public BaseDomain()
		{
			_uow = G.TContainer.ResolveRequestScope<IUnitOfWork>();
		}
		
		public BaseDomain(IUnitOfWork uow)
		{
			_uow = uow;
		}
		
		private IUnitOfWork _uow;
		protected IUnitOfWork UoW
		{
			get
			{
				return _uow;
			}
		}
		
		public BaseDomain(DbContext context)
		{
			_context = context;
		}
		
		private DbContext _context;
		protected DbContext Context
		{
			get
			{
				return _context;
			}
		}
		
	}
}
