using System;
using System.Collections.Generic;
using System.Text;

namespace Navyki.Todo.DTO.DTOs.AppUserDtos
{
    public class AppUserSignInDto
    {
        //[Required(ErrorMessage = "Kullanıcı Adı boş geçilemez.")]
        //[Display(Name = "Kullanıcı Adı :")]
        public string UserName { get; set; }

        //[Required(ErrorMessage = "Parola alanı boş geçilemez")]
        //[Display(Name = "Şifre :")]
        //[DataType(DataType.Password)]
        public string Password { get; set; }
        //[Display(Name = "Beni hatırla")]
        public bool RememberMe { get; set; }
    }
}
