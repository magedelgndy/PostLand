using AutoMapper;
using PostLand.Application.Featuers.Posts.Commands.CreatePost;
using PostLand.Application.Featuers.Posts.Commands.DeletePost;
using PostLand.Application.Featuers.Posts.Commands.UpdatePost;
using PostLand.Application.Featuers.Posts.Queries.Dto;
using PostLand.Application.Featuers.Posts.Queries.GetPostDetail;
using PostLand.Application.Featuers.Posts.Queries.GetPostList;
using PostLand.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLand.Application.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
           CreateMap<Post,GetPostListViewModel>().ReverseMap();
           CreateMap<Post,GetPostDetailViewModel>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
           CreateMap<Post,CreatePostCommand>().ReverseMap();
           CreateMap<Post,UpdatePostCommand>().ReverseMap();
           CreateMap<Post,DeletePostCommand>().ReverseMap();

        }
    }
}
