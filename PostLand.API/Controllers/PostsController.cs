using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostLand.Application.Featuers.Posts.Commands.CreatePost;
using PostLand.Application.Featuers.Posts.Commands.DeletePost;
using PostLand.Application.Featuers.Posts.Commands.UpdatePost;
using PostLand.Application.Featuers.Posts.Queries.GetPostDetail;
using PostLand.Application.Featuers.Posts.Queries.GetPostList;

namespace PostLand.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: all
        [HttpGet("all",Name ="GetAllPosts")]
        public async Task<ActionResult<List<GetPostListViewModel>>> GetAllPosts()
        {
            var dtos = await _mediator.Send(new GetPostsListQuery ());
            return Ok(dtos);
        }

        // GET: all/5
        [HttpGet("{id}", Name = "GetPostById")]
        public async Task<ActionResult<GetPostDetailViewModel>> GetPostById(Guid id)
        {
            var dtos = new GetPostDetailQuery() { PostId = id };
            return Ok(await _mediator.Send(dtos));
        }

        [HttpPost(Name ="AddPost")]
        public async Task<ActionResult<Guid>> Create([FromBody]CreatePostCommand createPostCommand)
        {
            Guid postId = await _mediator.Send(createPostCommand);
            return Ok(postId);
        }


        // POST: PostsController/Edit/5
        [HttpPut(Name ="UpdatePost")]
        public async Task<ActionResult> Update([FromBody]UpdatePostCommand updatePostCommand)
        {
            await _mediator.Send(updatePostCommand);
            return NoContent();
        }

        [HttpDelete("{id}",Name ="DeletePost")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deletedPostCommand = new DeletePostCommand() { PostId=id};
            await _mediator.Send(deletedPostCommand);
            return NoContent();
        }

    }
}
