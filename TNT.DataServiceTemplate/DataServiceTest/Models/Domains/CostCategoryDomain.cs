﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Models.Services;
using DataServiceTest.Managers;
using DataServiceTest.Models;

namespace DataServiceTest.Models.Domains
{
	public partial class CostCategoryDomain : BaseDomain<Models.CostCategory, CostCategoryViewModel, int, ICostCategoryService>
	{
		public CostCategoryDomain() : base()
		{
		}
		public CostCategoryDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
