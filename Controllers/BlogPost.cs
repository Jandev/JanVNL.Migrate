using System;


namespace JanVNL.Migrate.Controllers {
	public class BlogPost {
		public BlogPost() {
			ID = Guid.NewGuid().ToString();
			Title = "My new post";
			Content = "the content";
			PubDate = DateTime.UtcNow;
			LastModified = DateTime.UtcNow;
			Categories = new string[0];
			IsPublished = true;
		}

		public string ID { get; set; }

		public string Title { get; set; }

		public string Author { get; set; }

		public string Slug { get; set; }

		public string Content { get; set; }

		public DateTime PubDate { get; set; }

		public DateTime LastModified { get; set; }

		public bool IsPublished { get; set; }

		public string[] Categories { get; set; }

	}
}