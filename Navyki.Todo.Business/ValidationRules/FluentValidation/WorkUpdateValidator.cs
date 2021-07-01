using FluentValidation;
using Navyki.Todo.DTO.DTOs.WorkDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navyki.Todo.Business.ValidationRules.FluentValidation
{
    public class WorkUpdateValidator : AbstractValidator<WorkUpdateDto>
    {
        public WorkUpdateValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Ad alanı gereklidir.");
            RuleFor(x => x.UrgencyId).ExclusiveBetween(0, int.MaxValue).WithMessage("Lütfen bir aciliyet durumu seçiniz.");
        }
    }
}
