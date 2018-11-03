﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoterDataService.ViewModels;
using PromoterDataService.Global;

namespace PromoterDataService.Models
{
	public partial class AffliatorCashbackDetail : BaseEntity<AffliatorCashbackDetailViewModel>
	{
		public override AffliatorCashbackDetailViewModel ToViewModel()
		{
			return new AffliatorCashbackDetailViewModel(this);
		}
		
	}
}
