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
	public partial class FavoritedViewModel: BaseViewModel<Favorited>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("userID")]
		public string UserID { get; set; }
		[JsonProperty("productID")]
		public int ProductID { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("favoriteStt")]
		public Nullable<bool> FavoriteStt { get; set; }
		[JsonProperty("product")]
		public ProductViewModel ProductVM { get; set; }
		
		public FavoritedViewModel(Favorited entity) : this()
		{
			FromEntity(entity);
		}
		
		public FavoritedViewModel()
		{
		}
		
	}
}
