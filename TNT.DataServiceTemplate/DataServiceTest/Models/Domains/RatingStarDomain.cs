using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Models.Services;
using DataServiceTest.Managers;
using DataServiceTest.Models;

namespace DataServiceTest.Models.Domains
{
	public partial class RatingStarDomain : BaseDomain<Models.RatingStar, RatingStarViewModel, int, IRatingStarService>
	{
		public RatingStarDomain() : base()
		{
		}
		public RatingStarDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
