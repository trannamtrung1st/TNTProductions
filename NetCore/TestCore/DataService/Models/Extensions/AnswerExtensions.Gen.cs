using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService.ViewModels;
using DataService.Global;

namespace DataService.Models
{
	public partial class AnswerPK
	{
		public int OfUserId { get; set; }
		public int ToPostId { get; set; }
	}
	
	public partial class Answer : BaseEntity
	{
	}
	
}