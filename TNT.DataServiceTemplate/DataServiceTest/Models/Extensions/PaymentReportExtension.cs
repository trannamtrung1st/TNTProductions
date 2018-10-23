﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Global;

namespace DataServiceTest.Models
{
	public partial class PaymentReport : BaseEntity<PaymentReportViewModel>
	{
		public override PaymentReportViewModel ToViewModel()
		{
			return new PaymentReportViewModel(this);
		}
		
	}
}
