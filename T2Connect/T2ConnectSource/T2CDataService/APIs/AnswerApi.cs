using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2CDataService.ViewModels;
using T2CDataService.Models.Services;
using T2CDataService.Models;

namespace T2CDataService.APIs
{
	public partial class AnswerApi : BaseApi<Answer, AnswerViewModel, int, IAnswerService>
	{
	}
	
}
