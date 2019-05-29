using System;

namespace AzurePipelines.Domain.Blogs
{
    public class Post
    {
        public int Id { get; set; }

        public DateTime PublishedOn { get; set; }

        public string Title { get; set; }

        public string Contents { get; set; }
    }
}