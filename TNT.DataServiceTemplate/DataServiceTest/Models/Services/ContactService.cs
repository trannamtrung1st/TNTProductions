using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DataServiceTest.Utilities;
using DataServiceTest.Managers;
using DataServiceTest.ViewModels;
using DataServiceTest.Models.Repositories;
using DataServiceTest.Global;
using TNT.IoContainer.Wrapper;

namespace DataServiceTest.Models.Services
{
	public partial interface IContactService : IBaseService<Contact, ContactViewModel, int>
	{
	}
	
	public partial class ContactService : BaseService<Contact, ContactViewModel, int>, IContactService
	{
		public ContactService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IContactRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public ContactService()
		{
			repository = G.TContainer.Resolve<IContactRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ContactService()
		{
			Dispose(false);
		}
		#endregion
	}
}
