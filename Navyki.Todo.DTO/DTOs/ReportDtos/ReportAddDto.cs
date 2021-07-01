using Navyki.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navyki.Todo.DTO.DTOs.ReportDtos
{
    public class ReportAddDto
    {
        //[Display(Name = "Tanım: ")]
        //[Required(ErrorMessage = "Tanım alanı boş geçilemez")]
        public string Description { get; set; }
        //[Display(Name = "Detay: ")]
        //[Required(ErrorMessage = "Detay alanı boş geçilemez")]
        public string Detail { get; set; }
        public Work Work { get; set; }
        public int WorkId { get; set; }
    }
}
