using FluentValidation;
using Navyki.Todo.DTO.DTOs.WorkDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navyki.Todo.Business.ValidationRules.FluentValidation
{
    public class WorkAddValidator : AbstractValidator<WorkAddDto>
    {
        public WorkAddValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Ad alanı gereklidir.");
            RuleFor(x => x.UrgencyId).ExclusiveBetween(1, int.MaxValue).WithMessage("Lütfen bir aciliyet durumu seçiniz.");
             
        }
    }
}
