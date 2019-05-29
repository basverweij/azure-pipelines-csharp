using System;
using System.Reflection.Emit;

using AzurePipelines.Application.Interfaces;
using AzurePipelines.Domain.Blogs;

using GrEmit;

namespace AzurePipelines.Infra.Emit
{
    public class EmitBlogRepository :
        IBlogRepository
    {
        delegate Blog CreateBlogDelegate(
            string name);

        public Blog Create(
            string name)
        {
            var createMethod = new DynamicMethod(
                "CreateBlog",
                typeof(Blog),
                new Type[] { typeof(string) });

            EmitCreate(createMethod);

            var createDelegate = (CreateBlogDelegate)createMethod.CreateDelegate(
                typeof(CreateBlogDelegate));

            return createDelegate(name);
        }

        private void EmitCreate(
            DynamicMethod method)
        {
            using (var il = new GroboIL(method))
            {
                var constructor = typeof(Blog)
                    .GetConstructor(Type.EmptyTypes);

                il.Newobj(constructor);

                il.Dup(); // for return

                il.Ldarg(0); // name

                var setName = typeof(Blog)
                    .GetProperty(nameof(Blog.Name))
                    .SetMethod;

                il.Call(setName);

                il.Ret();
            }
        }
    }
}
