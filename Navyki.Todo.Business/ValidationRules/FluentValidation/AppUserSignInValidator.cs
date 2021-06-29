using FluentValidation;
using Navyki.Todo.DTO.DTOs.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navyki.Todo.Business.ValidationRules.FluentValidation
{
    public class AppUserSignInValidator : AbstractValidator<AppUserSignInDto>
    {
        public AppUserSignInValidator()
        {
            RuleFor(x => x.UserName).NotNull().WithMessage("Kullanıcı adı boş geçilemez.");
            RuleFor(x => x.Password).NotNull().WithMessage("Şifre alanı boş geçilemez.");
        }
    }
}
