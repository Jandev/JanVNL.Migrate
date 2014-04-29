using System;
using System.Linq;
using System.Web.Mvc;
using Orchard.Collections;
using Orchard.ContentManagement;
using Orchard.DisplayManagement;
using Orchard.Indexing;
using Orchard.Localization;
using Orchard.Logging;
using Orchard.Settings;
using Orchard.Themes;
using Orchard.UI.Navigation;
using Orchard.UI.Notify;
using Orchard.Blogs.Models;
using Orchard.Blogs.Routing;
using Orchard.Blogs.Services;


namespace JanVNL.Migrate.Controllers
{
	public class MigrateController : Controller
	{
		private readonly IArchiveConstraint _archiveConstraint;
		private readonly IBlogService _blogService;
		private readonly IBlogPostService _blogPostService;

		public MigrateController(IArchiveConstraint archiveConstraint, IBlogService blogService, IBlogPostService blogPostService)
        {
            _archiveConstraint = archiveConstraint;
            _blogService = blogService;
            _blogPostService = blogPostService;
        }

		public ActionResult Index()
		{
			var getBlogPosts = new GetBlogPost(_blogService, _blogPostService);
			var allPosts = getBlogPosts.Initialize(false);

			return View();
		}

		public ActionResult Redirect()
		{
			var getBlogPosts = new GetBlogPost(_blogService, _blogPostService);
			var allPosts = getBlogPosts.Initialize(true);

			return View();
		}
	}
}