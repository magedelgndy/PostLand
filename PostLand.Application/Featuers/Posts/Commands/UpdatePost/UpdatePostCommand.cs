using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLand.Application.Featuers.Posts.Commands.UpdatePost
{
    public class UpdatePostCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }
        public Guid CategoryId { get; set; }
    }
}
