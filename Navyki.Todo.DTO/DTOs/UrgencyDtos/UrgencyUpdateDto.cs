using System;
using System.Collections.Generic;
using System.Text;

namespace Navyki.Todo.DTO.DTOs.UrgencyDtos
{
    public class UrgencyUpdateDto
    {
        public int Id { get; set; }
        //[Display(Name = "Tanım: ")]
        //[Required(ErrorMessage = "Tanım alanı gereklidir")]
        public string Description { get; set; }
    }
}
