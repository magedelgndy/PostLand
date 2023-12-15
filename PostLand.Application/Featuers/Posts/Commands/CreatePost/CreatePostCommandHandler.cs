using AutoMapper;
using MediatR;
using PostLand.Domain;
using PostLand.Application.Interfaces;

namespace PostLand.Application.Featuers.Posts.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Guid>
    {
        private readonly IAsyncRepository<Post> _postRepository;
        private readonly IMapper _mapper;

        public CreatePostCommandHandler(IAsyncRepository<Post> postRepository,IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            CreateCommandValidator validator = new CreateCommandValidator();
            var result = await validator.ValidateAsync(request);

            if (result.Errors.Any())
            {
                throw new Exception("Post Is Not Valid");
            }

            var mappedPost = _mapper.Map<Post>(request);
            Post post = await _postRepository.AddAsync(mappedPost);

            return post.Id;
        }
    }
}
