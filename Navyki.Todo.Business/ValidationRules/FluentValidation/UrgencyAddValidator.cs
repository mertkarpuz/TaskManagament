using FluentValidation;
using Navyki.Todo.DTO.DTOs.UrgencyDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navyki.Todo.Business.ValidationRules.FluentValidation
{
    public class UrgencyAddValidator : AbstractValidator<UrgencyAddDto>
    {
        public UrgencyAddValidator()
        {
            RuleFor(x => x.Description).NotNull().WithMessage("Tanım alanı boş geçilemez");
        }
    }
}
