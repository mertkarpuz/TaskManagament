using System;
using System.Collections.Generic;
using System.Text;

namespace Navyki.Todo.DTO.DTOs.AppUserDtos
{
    public class AppUserListDto
    {
        public int Id { get; set; }
        //[Display(Name = "Ad :")]
        //[Required(ErrorMessage = "Ad alanı boş geçilemez")]
        public string Name { get; set; }
        //[Display(Name = "Soyad :")]
        //[Required(ErrorMessage = "Soyad alanı boş geçilemez")]
        public string Surname { get; set; }
        //[Display(Name = "Email :")]
        public string Email { get; set; }
        //[Display(Name = "Resim :")]
        public string Picture { get; set; }
    }
}
