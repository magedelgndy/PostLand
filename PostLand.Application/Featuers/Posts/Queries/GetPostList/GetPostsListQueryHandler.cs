using AutoMapper;
using MediatR;
using PostLand.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLand.Application.Featuers.Posts.Queries.GetPostList
{
    public class GetPostsListQueryHandler : IRequestHandler<GetPostsListQuery, List<GetPostListViewModel>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetPostsListQueryHandler(IPostRepository postRepository,IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<List<GetPostListViewModel>> Handle(GetPostsListQuery request, CancellationToken cancellationToken)
        {
            var allPosts = await _postRepository.GetAllPostsAsync(true);
            return _mapper.Map<List<GetPostListViewModel>>(allPosts);
        }
    }
}
