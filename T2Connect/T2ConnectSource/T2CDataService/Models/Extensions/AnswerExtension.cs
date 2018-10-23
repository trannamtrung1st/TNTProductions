using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2CDataService.ViewModels;
using T2CDataService.Global;

namespace T2CDataService.Models
{
	public partial class Answer : BaseEntity<AnswerViewModel>
	{
		public override AnswerViewModel ToViewModel()
		{
			return new AnswerViewModel(this);
		}
		
	}
}
