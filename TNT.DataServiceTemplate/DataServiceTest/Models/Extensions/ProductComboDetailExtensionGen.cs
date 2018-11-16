using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Global;

namespace DataServiceTest.Models
{
	public partial class ProductComboDetailPK
	{
		public int ComboID { get; set; }
		public int ProductID { get; set; }
	}
	
	public partial class ProductComboDetail : BaseEntity
	{
	}
}
