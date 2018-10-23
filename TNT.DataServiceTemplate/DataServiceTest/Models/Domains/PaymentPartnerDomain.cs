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
	public partial class PaymentPartnerDomain : BaseDomain<Models.PaymentPartner, PaymentPartnerViewModel, int, IPaymentPartnerService>
	{
		public PaymentPartnerDomain() : base()
		{
		}
		public PaymentPartnerDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
