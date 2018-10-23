using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Global;

namespace DataServiceTest.Models
{
	public partial class PosFile : BaseEntity<PosFileViewModel>
	{
		public override PosFileViewModel ToViewModel()
		{
			return new PosFileViewModel(this);
		}
		
	}
}
