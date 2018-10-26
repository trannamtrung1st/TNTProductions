﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoterDataService.Global;
using PromoterDataService.Models;
using Newtonsoft.Json;

namespace PromoterDataService.ViewModels
{
	public partial class RedemptionViewModel: BaseViewModel<Redemption>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> Date { get; set; }
		[JsonProperty("customerId", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> CustomerId { get; set; }
		[JsonProperty("metadataObject", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string MetadataObject { get; set; }
		[JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> Status { get; set; }
		[JsonProperty("failureCode", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> FailureCode { get; set; }
		[JsonProperty("customer", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public CustomerViewModel CustomerVM { get; set; }
		[JsonProperty("promotionAppliedDetails", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<PromotionAppliedDetailViewModel> PromotionAppliedDetailsVM { get; set; }
		[JsonProperty("redemptionRollbacks", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<RedemptionRollbackViewModel> RedemptionRollbacksVM { get; set; }
		
		public RedemptionViewModel(Redemption entity) : this()
		{
			FromEntity(entity);
		}
		
		public RedemptionViewModel()
		{
			this.PromotionAppliedDetailsVM = new HashSet<PromotionAppliedDetailViewModel>();
			this.RedemptionRollbacksVM = new HashSet<RedemptionRollbackViewModel>();
		}
		
	}
}
