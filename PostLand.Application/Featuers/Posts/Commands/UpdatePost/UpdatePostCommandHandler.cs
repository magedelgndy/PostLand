using AutoMapper;
using MediatR;
using PostLand.Application.Interfaces;
using PostLand.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLand.Application.Featuers.Posts.Commands.UpdatePost
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand>
    {
        private readonly IAsyncRepository<Post> _postRepository;
        private readonly IMapper _mapper;

        public UpdatePostCommandHandler(IAsyncRepository<Post> postRepository,IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {

            Post mappedPost = _mapper.Map<Post>(request);
            await _postRepository.UpdateAsync(mappedPost);


        }
    }
}
