NOTES:
- Add a config class that will use config methods of G class
- Add PreStartApplicationMethod attribute on the class (type: [configClass], method: [configMethod])
- UnitOfWork will manage the DbContext, Scope IoC, and Transaction for you 
  so you don't need to explicit dispose them
- To use Request scope (app server required) UnitOfWork: 
	+ DO: var uow = G.TContainer.ResolveRequestScope<IUnitOfWork>(); for each work
(The uow will dispose in the end of a request)
	+ (Each domain will auto resolve one when initialized)
- Normal use of UnitOfWork:
	+ using (var u = G.TContainer.Resolve<IUnitOfWork>([scope]))
	+ using (var u = new UnitOfWork([scope]))
- Don't remove the Templates folder (or you won't be able to regenerate files)
- Almost classes are partial by default. Extend them if you want
HAVE A GOOD PROGRAMMING LIFE <3