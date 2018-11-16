using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoterDataService.Models.Services;
using PromoterDataService.ViewModels;
using PromoterDataService.Managers;
using PromoterDataService.Utilities;
using PromoterDataService.Models;
using PromoterDataService.Global;
using System.Linq.Expressions;
using TNT.IoContainer.Wrapper;

namespace PromoterDataService.Models.Domains
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
		
	}
}
