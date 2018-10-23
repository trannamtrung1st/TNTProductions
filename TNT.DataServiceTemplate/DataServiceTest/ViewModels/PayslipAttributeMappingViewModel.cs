﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.Global;
using DataServiceTest.Models;
using Newtonsoft.Json;

namespace DataServiceTest.ViewModels
{
	public partial class PayslipAttributeMappingViewModel: BaseViewModel<PayslipAttributeMapping>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("payslipId")]
		public Nullable<int> PayslipId { get; set; }
		[JsonProperty("attributeId")]
		public Nullable<int> AttributeId { get; set; }
		[JsonProperty("value")]
		public Nullable<int> Value { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("paySlip")]
		public PaySlipViewModel PaySlipVM { get; set; }
		[JsonProperty("payslipAttribute")]
		public PayslipAttributeViewModel PayslipAttributeVM { get; set; }
		
		public PayslipAttributeMappingViewModel(PayslipAttributeMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public PayslipAttributeMappingViewModel()
		{
		}
		
	}
}
