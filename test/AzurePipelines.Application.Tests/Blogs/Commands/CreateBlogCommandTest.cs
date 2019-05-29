using AzurePipelines.Application.Blogs.Commands.CreateBlog;
using AzurePipelines.Application.Interfaces;
using AzurePipelines.Domain.Blogs;

using Moq;

using NUnit.Framework;

namespace AzurePipelines.Application.Tests.Blogs.Commands
{
    [TestFixture]
    public class CreateBlogCommandTest
    {
        private Mock<IBlogRepository> _blogRepository;

        private CreateBlogCommand _sut;

        [SetUp]
        public void SetUp()
        {
            _blogRepository = new Mock<IBlogRepository>(MockBehavior.Strict);

            _blogRepository
                .Setup(br => br.Create(It.IsAny<string>()))
                .Returns(
                    (string name) =>
                        new Blog()
                        {
                            Name = name,
                        });

            _sut = new CreateBlogCommand(_blogRepository.Object);
        }


        [Test]
        public void ConstructorShouldCheckPreConditions()
        {
            Assert.That(
                () => new CreateBlogCommand(null),
                Throws.ArgumentNullException);
        }

        [Test]
        public void CreateShouldCallRepositoryWithNameFromModel()
        {
            var blog = _sut.Execute(
                new CreateBlogModel()
                {
                    Name = "name",
                })
                .Blog;

            Assert.That(
                blog.Name,
                Is.EqualTo("name"));
        }
    }
}
