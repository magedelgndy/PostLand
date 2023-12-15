using AutoMapper;
using MediatR;
using PostLand.Application.Interfaces;
using PostLand.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLand.Application.Featuers.Posts.Queries.GetPostDetail
{
    public class GetPostDetailQueryHandler : IRequestHandler<GetPostDetailQuery, GetPostDetailViewModel>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetPostDetailQueryHandler(IPostRepository postRepository , IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<GetPostDetailViewModel> Handle(GetPostDetailQuery request, CancellationToken cancellationToken)
        {
            var postDetail = await _postRepository.GetByIdAsync(request.PostId);
            return _mapper.Map<GetPostDetailViewModel>(postDetail);
        
        }
    }
}
