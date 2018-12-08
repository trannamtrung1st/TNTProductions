using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Promoter.DataService.ViewModels;
using Promoter.DataService.Global;

namespace Promoter.DataService.Models
{
	public partial class PC_StoreFilterPK
	{
		public int StoreId { get; set; }
		public int ConstraintId { get; set; }
	}
	
	public partial class PC_StoreFilter : BaseEntity
	{
	}
}
