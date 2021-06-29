using System;
using System.Collections.Generic;
using System.Text;

namespace Navyki.Todo.DTO.DTOs.WorkDtos
{
    public class WorkAddDto
    {
        //[Required(ErrorMessage = "Ad alanı gereklidir")]eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee
        public string Name { get; set; }

        public string Description { get; set; }
        //[Range(0, int.MaxValue, ErrorMessage = "Lütfen bir aciliyet durumu seçiniz")]
        public int UrgencyId { get; set; }
    }
}
