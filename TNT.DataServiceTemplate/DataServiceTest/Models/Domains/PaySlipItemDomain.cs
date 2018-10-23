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
	public partial class PaySlipItemDomain : BaseDomain<Models.PaySlipItem, PaySlipItemViewModel, int, IPaySlipItemService>
	{
		public PaySlipItemDomain() : base()
		{
		}
		public PaySlipItemDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
