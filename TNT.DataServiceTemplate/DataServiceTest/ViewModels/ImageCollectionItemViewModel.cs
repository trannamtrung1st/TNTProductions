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
	public partial class ImageCollectionItemViewModel: BaseViewModel<ImageCollectionItem>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("imageCollectionId")]
		public int ImageCollectionId { get; set; }
		[JsonProperty("title")]
		public string Title { get; set; }
		[JsonProperty("imageUrl")]
		public string ImageUrl { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("position")]
		public int Position { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("link")]
		public string Link { get; set; }
		[JsonProperty("imageCollection")]
		public ImageCollectionViewModel ImageCollectionVM { get; set; }
		
		public ImageCollectionItemViewModel(ImageCollectionItem entity) : this()
		{
			FromEntity(entity);
		}
		
		public ImageCollectionItemViewModel()
		{
		}
		
	}
}
