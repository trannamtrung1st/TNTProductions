using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Global;

namespace DataServiceTest.Models
{
	public partial class CustomerFeedbackPK
	{
		public int Id { get; set; }
		public int StoreId { get; set; }
		public bool Active { get; set; }
	}
	
	public partial class CustomerFeedback : BaseEntity
	{
	}
}
