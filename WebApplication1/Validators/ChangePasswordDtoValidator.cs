using FluentValidation;
using Infrastructure.ModelsDTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Validators
{
    public class ChangePasswordDtoValidator : AbstractValidator<ChangePasswordDTO>
    {
        public ChangePasswordDtoValidator()
        {
            RuleFor(x => x.Password).MinimumLength(7);
            RuleFor(c => c.ConfirmPassword).Equal(x => x.Password);
            RuleFor(x => x.Password).NotEqual(o => o.OldPassword);
        }
    }
}
