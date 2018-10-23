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
	public partial class ProvinceDomain : BaseDomain<Models.Province, ProvinceViewModel, int, IProvinceService>
	{
		public ProvinceDomain() : base()
		{
		}
		public ProvinceDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
