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
	public partial interface IFingerScanMachineService : IBaseService<FingerScanMachine, FingerScanMachineViewModel, int>
	{
	}
	
	public partial class FingerScanMachineService : BaseService<FingerScanMachine, FingerScanMachineViewModel, int>, IFingerScanMachineService
	{
		public FingerScanMachineService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IFingerScanMachineRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public FingerScanMachineService()
		{
			repository = G.TContainer.Resolve<IFingerScanMachineRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~FingerScanMachineService()
		{
			Dispose(false);
		}
		#endregion
	}
}
