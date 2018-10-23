using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Global;

namespace DataServiceTest.Models
{
	public partial class BlogPost : BaseEntity<BlogPostViewModel>
	{
		public override BlogPostViewModel ToViewModel()
		{
			return new BlogPostViewModel(this);
		}
		
	}
}
