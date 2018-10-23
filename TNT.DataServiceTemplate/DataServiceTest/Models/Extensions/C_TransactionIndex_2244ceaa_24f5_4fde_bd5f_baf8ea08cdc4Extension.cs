using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Global;

namespace DataServiceTest.Models
{
	public partial class C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 : BaseEntity<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4ViewModel>
	{
		public override C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4ViewModel ToViewModel()
		{
			return new C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4ViewModel(this);
		}
		
	}
}
