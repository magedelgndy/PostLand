using PostLand.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLand.Application.Interfaces
{
    public interface IPostRepository : IAsyncRepository<Post>
    {
        Task<IReadOnlyList<Post>> GetAllPostsAsync(bool includeCategory);
        Task<Post> GetPostByIdAsync(Guid id, bool includeCategory);
    }
}
