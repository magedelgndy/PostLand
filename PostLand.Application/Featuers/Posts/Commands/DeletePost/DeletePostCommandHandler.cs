using AutoMapper;
using MediatR;
using PostLand.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLand.Application.Featuers.Posts.Commands.DeletePost
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
    {
        private readonly IPostRepository _postRepository;

        public DeletePostCommandHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var Post = await _postRepository.GetByIdAsync(request.PostId);
            await _postRepository.DeleteAsync(Post);
        }
    }
}
