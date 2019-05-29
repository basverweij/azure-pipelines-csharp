using System;
using System.Linq;

using AzurePipelines.Application.Blogs.Commands.CreateBlog;
using AzurePipelines.Infra.Emit;

namespace AzurePipelines.Runner
{
    static class Program
    {
        static void Main(
            string[] args)
        {
            var blogName = "Blog Name";

            if (args != null &&
                args.Any())
            {
                blogName = args[0];
            }

            var blogRepository = new EmitBlogRepository();

            var createBlog = new CreateBlogCommand(blogRepository);

            var blog = createBlog.Execute(
                new CreateBlogModel()
                {
                    Name = blogName,
                })
                .Blog;

            Console.WriteLine(blog);
        }
    }
}
