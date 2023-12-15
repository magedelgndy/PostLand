using Microsoft.EntityFrameworkCore;
using PostLand.Application.Interfaces;
using PostLand.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLand.Persistence.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(PostDbContext postDbContext) : base(postDbContext)
        {
        }

        public async Task<IReadOnlyList<Post>> GetAllPostsAsync(bool includeCategory)
        {
            List<Post> posts = new List<Post>();
            posts = includeCategory ? await _postDbContext.posts.Include(x => x.Category).ToListAsync() : await _postDbContext.posts.ToListAsync();
            return posts;
        }

        public async Task<Post> GetPostByIdAsync(Guid id, bool includeCategory)
        {
            Post post = new Post();
            post = includeCategory ? await _postDbContext.posts.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id) : await _postDbContext.posts.FirstOrDefaultAsync(x => x.Id == id);
            return post;
        }
    }
}
