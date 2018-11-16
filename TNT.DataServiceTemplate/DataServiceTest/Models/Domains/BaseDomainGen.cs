using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.Models.Services;
using DataServiceTest.ViewModels;
using DataServiceTest.Managers;
using DataServiceTest.Utilities;
using DataServiceTest.Models;
using DataServiceTest.Global;
using System.Linq.Expressions;
using TNT.IoContainer.Wrapper;

namespace DataServiceTest.Models.Domains
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
