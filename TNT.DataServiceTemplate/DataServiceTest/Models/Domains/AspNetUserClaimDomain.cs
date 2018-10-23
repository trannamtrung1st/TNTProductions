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
	public partial class AspNetUserClaimDomain : BaseDomain<Models.AspNetUserClaim, AspNetUserClaimViewModel, int, IAspNetUserClaimService>
	{
		public AspNetUserClaimDomain() : base()
		{
		}
		public AspNetUserClaimDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
