using FluentValidation;
using SportAPI.Sport.Data;
using SportAPI.Sport.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Validators
{
  public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
  {
    public RegisterUserDtoValidator(SportDbContext dbContext)
    {
      RuleFor(x => x.Login).NotEmpty().EmailAddress();
      
      RuleFor(x => x.Password).NotEmpty().MinimumLength(8);

      RuleFor(x => x.ConfirmPassword).Equal(e => e.Password);

      RuleFor(x => x.Login)
        .Custom((value, context) =>
        {
          var loginInUse = dbContext.Users.Any(u => u.Login == value);
          if(loginInUse)
          {
            context.AddFailure("Login","That Login is taken");
          }
        });
    }
  }
}
