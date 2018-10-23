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
	public partial class FavoritedDomain : BaseDomain<Models.Favorited, FavoritedViewModel, int, IFavoritedService>
	{
		public FavoritedDomain() : base()
		{
		}
		public FavoritedDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
