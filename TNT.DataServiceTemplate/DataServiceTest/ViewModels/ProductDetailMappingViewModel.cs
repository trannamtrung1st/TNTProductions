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
	public partial class ProductDetailMappingViewModel: BaseViewModel<ProductDetailMapping>
	{
		[JsonProperty("productDetailID")]
		public int ProductDetailID { get; set; }
		[JsonProperty("productID")]
		public Nullable<int> ProductID { get; set; }
		[JsonProperty("storeID")]
		public Nullable<int> StoreID { get; set; }
		[JsonProperty("price")]
		public Nullable<double> Price { get; set; }
		[JsonProperty("discountPrice")]
		public Nullable<double> DiscountPrice { get; set; }
		[JsonProperty("discountPercent")]
		public Nullable<double> DiscountPercent { get; set; }
		[JsonProperty("active")]
		public Nullable<bool> Active { get; set; }
		[JsonProperty("product")]
		public ProductViewModel ProductVM { get; set; }
		[JsonProperty("store")]
		public StoreViewModel StoreVM { get; set; }
		
		public ProductDetailMappingViewModel(ProductDetailMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public ProductDetailMappingViewModel()
		{
		}
		
	}
}
