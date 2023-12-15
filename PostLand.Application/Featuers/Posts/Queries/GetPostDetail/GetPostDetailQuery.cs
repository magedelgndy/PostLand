using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLand.Application.Featuers.Posts.Queries.GetPostDetail
{
    public class GetPostDetailQuery:IRequest<GetPostDetailViewModel>
    {
        public Guid PostId { get; set; }    
    }
}
