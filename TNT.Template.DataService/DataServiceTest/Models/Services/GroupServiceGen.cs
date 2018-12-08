﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DataServiceTest.Utilities;
using DataServiceTest.Managers;
using DataServiceTest.Models.Repositories;
using DataServiceTest.Global;
using TNT.IoContainer.Wrapper;
using System.Data.Entity;

namespace DataServiceTest.Models.Services
{
	public partial interface IGroupService : IBaseService<Group, int>
	{
	}
	
	public partial class GroupService : BaseService<Group, int>, IGroupService
	{
		public GroupService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IGroupRepository>(uow);
		}
		
		public GroupService(DbContext context)
		{
			repository = G.TContainer.Resolve<IGroupRepository>(context);
		}
		
	}
}
