using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orchard.Blogs.Models;
using Orchard.Blogs.Services;
using Orchard.ContentManagement;
using System.IO;

namespace JanVNL.Migrate.Controllers
{
	internal class Retriever
	{
		internal static BlogPart GetBlog(IBlogService blogService)
		{
			var blogPart = blogService.Get(VersionOptions.Published).FirstOrDefault();
			if (blogPart == null)
				throw new FileNotFoundException();

			return blogPart;
		}
	}
}