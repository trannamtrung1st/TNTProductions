using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.Global;
using DataServiceTest.Models;
using Newtonsoft.Json;

namespace DataServiceTest.ViewModels
{
	public partial class C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4ViewModel: BaseViewModel<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public System.Guid Id { get; set; }
		
		public C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4ViewModel(C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 entity) : this()
		{
			FromEntity(entity);
		}
		
		public C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4ViewModel()
		{
		}
		
	}
}
