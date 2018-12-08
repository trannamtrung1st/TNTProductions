using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DataServiceTest.Utilities;
using DataServiceTest.Managers;
using DataServiceTest.Models.Repositories;
using DataServiceTest.Global;
using TNT.IoContainer.Wrapper;
using System.Data.Entity;

namespace DataServiceTest.Models.Services
{
	public partial interface IContactService : IBaseService<Contact, int>
	{
	}
	
	public partial class ContactService : BaseService<Contact, int>, IContactService
	{
		public ContactService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IContactRepository>(uow);
		}
		
		public ContactService(DbContext context)
		{
			repository = G.TContainer.Resolve<IContactRepository>(context);
		}
		
	}
}
