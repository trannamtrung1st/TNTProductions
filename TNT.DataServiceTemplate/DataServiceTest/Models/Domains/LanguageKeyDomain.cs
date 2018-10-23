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
	public partial class LanguageKeyDomain : BaseDomain<Models.LanguageKey, LanguageKeyViewModel, int, ILanguageKeyService>
	{
		public LanguageKeyDomain() : base()
		{
		}
		public LanguageKeyDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
