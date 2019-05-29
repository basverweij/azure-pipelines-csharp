using System.Collections.Generic;

namespace AzurePipelines.Domain.Blogs
{
    public class Blog
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; }

        public override string ToString() => $"{nameof(Blog)}: '{Name}'";
    }
}
