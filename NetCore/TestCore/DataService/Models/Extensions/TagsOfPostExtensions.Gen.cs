using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService.ViewModels;
using DataService.Global;

namespace DataService.Models
{
	public partial class TagsOfPostPK
	{
		public int PostId { get; set; }
		public int TagId { get; set; }
	}
	
	public partial class TagsOfPost : BaseEntity
	{
	}
	
}
