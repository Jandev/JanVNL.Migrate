using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using Orchard;
using Orchard.Autoroute.Models;
using Orchard.Blogs.Models;
using Orchard.Blogs.Services;
using Orchard.ContentManagement;

namespace JanVNL.Migrate.Controllers
{
	public class GetBlogPost
	{
		private readonly IBlogService _blogService;
		private readonly IBlogPostService _blogPostService;

		private ICollection<BlogPost> _allBlogPosts;

		public GetBlogPost(
						IBlogService blogService,
						IBlogPostService blogPostService
						)
		{
			_blogService = blogService;
			_blogPostService = blogPostService;
		}

		/// <summary>
		/// Retrieving all blog posts here, so this only has to be called once.
		/// </summary>
		internal ICollection<BlogPost> Initialize(bool redirect)
		{
			var blog = Retriever.GetBlog(_blogService);
			var blogPosts = _blogPostService.Get(blog, VersionOptions.Published);
			_allBlogPosts = new List<BlogPost>();
			string redirects = string.Empty;
			foreach (var blogPostPart in blogPosts)
			{
				if (redirect) 
				{
					string currentSlug = GetUrl(blogPostPart);
					string redirectRule = "<location path=\"{0}\"><system.webServer><httpRedirect enabled=\"true\" destination=\"http://jan-v.nl/post/{0}\" httpResponseStatus=\"Permanent\" /></system.webServer></location>";
					redirects = redirects + string.Format(redirectRule, currentSlug);
				}
				else {

					var blogPost = new BlogPost();
					blogPost.Title = blogPostPart.Title;
					blogPost.Content = blogPostPart.Text;
					blogPost.PubDate = blogPostPart.PublishedUtc.Value;
					blogPost.LastModified = blogPostPart.PublishedUtc.Value;
					//blogPost.Categories = blogPostPart.;
					blogPost.Slug = GetUrl(blogPostPart);
					blogPost.Author = blogPostPart.Creator.UserName;
					blogPost.IsPublished = true;

					_allBlogPosts.Add(blogPost);
					Storage.Save(blogPost, string.Format("C:\\BlogPosts\\{0}.xml", blogPost.Slug));
				}
				
			}
			return _allBlogPosts;
		}

		private static string GetUrl([NotNull] IContent blogPostPart)
		{
			if (blogPostPart == null) throw new ArgumentNullException("blogPostPart");

			var autoRouteItem = blogPostPart.ContentItem.Parts.FirstOrDefault(p => p is AutoroutePart) as AutoroutePart;
			if (autoRouteItem != null)
			{
				return autoRouteItem.Path;
			}
			return string.Empty;
		}
	}
}