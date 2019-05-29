using NUnit.Framework;

namespace AzurePipelines.Infra.Emit.Tests
{
    [TestFixture]
    public class EmitBlogRepositoryTest
    {
        private EmitBlogRepository _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new EmitBlogRepository();
        }

        [Test]
        public void ShouldCreateBlog()
        {
            var blog = _sut.Create("test");

            Assert.That(
                blog.Name,
                Is.EqualTo("test"));
        }
    }
}
