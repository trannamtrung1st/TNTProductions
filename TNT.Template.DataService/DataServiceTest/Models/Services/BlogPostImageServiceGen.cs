﻿using System;
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
	public partial interface IBlogPostImageService : IBaseService<BlogPostImage, int>
	{
	}
	
	public partial class BlogPostImageService : BaseService<BlogPostImage, int>, IBlogPostImageService
	{
		public BlogPostImageService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IBlogPostImageRepository>(uow);
		}
		
		public BlogPostImageService(DbContext context)
		{
			repository = G.TContainer.Resolve<IBlogPostImageRepository>(context);
		}
		
	}
}
