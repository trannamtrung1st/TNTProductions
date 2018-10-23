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
	public partial class CategoryExtraDomain : BaseDomain<Models.CategoryExtra, CategoryExtraViewModel, int, ICategoryExtraService>
	{
		public CategoryExtraDomain() : base()
		{
		}
		public CategoryExtraDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
