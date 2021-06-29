using FluentValidation;
using Navyki.Todo.DTO.DTOs.ReportDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navyki.Todo.Business.ValidationRules.FluentValidation
{
    public class ReportAddValidator : AbstractValidator<ReportAddDto>
    {
        public ReportAddValidator()
        {
            RuleFor(x => x.Description).NotNull().WithMessage("Tanım alanı boş geçilemez.");
            RuleFor(x => x.Detail).NotNull().WithMessage("Detay alanı boş geçilemez.");
        }
    }
}
