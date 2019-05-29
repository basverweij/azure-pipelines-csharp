using System;

using AzurePipelines.Application.Interfaces;

namespace AzurePipelines.Application.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommand
    {
        private readonly IBlogRepository _blogRepository;

        public CreateBlogCommand(
            IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository ?? throw new ArgumentNullException(nameof(blogRepository));
        }

        public CreateBlogResult Execute(
            CreateBlogModel model)
        {
            var blog = _blogRepository.Create(model.Name);

            return new CreateBlogResult()
            {
                Blog = blog,
            };
        }
    }
}
