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
	public partial class ContactDomain : BaseDomain<Models.Contact, ContactViewModel, int, IContactService>
	{
		public ContactDomain() : base()
		{
		}
		public ContactDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
