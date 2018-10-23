using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Global;

namespace DataServiceTest.Models
{
	public partial class C__MigrationHistoryPK
	{
		public string MigrationId { get; set; }
		public string ContextKey { get; set; }
	}
	
	public partial class C__MigrationHistory : BaseEntity<C__MigrationHistoryViewModel>
	{
		public override C__MigrationHistoryViewModel ToViewModel()
		{
			return new C__MigrationHistoryViewModel(this);
		}
		
	}
}
