using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.Models.Services;
using TestDataService.ViewModels;
using TestDataService.Managers;
using TestDataService.Utilities;
using TestDataService.Models;
using TestDataService.Global;
using System.Linq.Expressions;
using TNT.IoContainer.Wrapper;

namespace TestDataService.Models.Domains
{
	public abstract partial class BaseDomain
	{
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
		
		public BaseDomain(EmployeeManagerEntities context)
		{
			_context = context;
		}
		
		private EmployeeManagerEntities _context;
		protected EmployeeManagerEntities Context
		{
			get
			{
				return _context;
			}
		}
		
	}
}
