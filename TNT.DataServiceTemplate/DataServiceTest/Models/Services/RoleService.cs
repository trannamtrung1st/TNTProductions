﻿using System;
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
	public partial interface IRoleService : IBaseService<Role, RoleViewModel, System.Guid>
	{
	}
	
	public partial class RoleService : BaseService<Role, RoleViewModel, System.Guid>, IRoleService
	{
		public RoleService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IRoleRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public RoleService()
		{
			repository = G.TContainer.Resolve<IRoleRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~RoleService()
		{
			Dispose(false);
		}
		#endregion
	}
}
