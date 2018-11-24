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
		
		public BaseDomain(PromoterEntities context)
		{
			_context = context;
		}
		
		private PromoterEntities _context;
		protected PromoterEntities Context
		{
			get
			{
				return _context;
			}
		}
		
	}
}
