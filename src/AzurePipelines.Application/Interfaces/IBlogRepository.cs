using AzurePipelines.Domain.Blogs;

namespace AzurePipelines.Application.Interfaces
{
    public interface IBlogRepository
    {
        Blog Create(
            string name);
    }
}
