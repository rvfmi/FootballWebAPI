using FluentValidation;
using Infrastructure.ModelsDTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Database;

namespace Infrastructure.ModelsDTO.Validators
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDTO>
    {

        public CreateUserDtoValidator(DatabaseContext dbContext)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.Password).MinimumLength(7);
            RuleFor(x => x.Password).Equal(c => c.ConfirmPassword);

            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var emailInUse = dbContext.users.Any(x => x.Email == value);
                    if (emailInUse)
                    {
                        context.AddFailure("That email is taken");
                    }
                });
        }
    }
}
