using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoterDataService.ViewModels;
using PromoterDataService.Models.Services;
using PromoterDataService.Managers;
using PromoterDataService.Models;

namespace PromoterDataService.Models.Domains
{
	public partial class StoreDomain : BaseDomain<Models.Store, StoreViewModel, int, IStoreService>
	{
		public StoreDomain() : base()
		{
		}
		public StoreDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
