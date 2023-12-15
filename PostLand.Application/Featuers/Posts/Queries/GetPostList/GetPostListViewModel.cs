using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostLand.Application.Featuers.Posts.Queries.Dto;

namespace PostLand.Application.Featuers.Posts.Queries.GetPostList
{
    public class GetPostListViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }
        public CategoryDto Category { get; set; }
    }
}
