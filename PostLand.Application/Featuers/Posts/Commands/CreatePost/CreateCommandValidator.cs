using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLand.Application.Featuers.Posts.Commands.CreatePost
{
    public class CreateCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(e => e.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);
            RuleFor(e => e.Content)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);
        }
    }
}
