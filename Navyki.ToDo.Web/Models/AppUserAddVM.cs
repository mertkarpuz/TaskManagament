using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Navyki.ToDo.Web.Models
{
    public class AppUserAddVM
    {
        [Required(ErrorMessage = "Kullanıcı Adı boş geçilemez.")]
        [Display(Name="Kullanıcı Adı :")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Parola alanı boş geçilemez")]
        [Display(Name = "Şifre :")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Parolalar eşleşmiyor.")]
        [Display(Name = "Parola tekrarı :")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Email :")]

        [Required(ErrorMessage = "Email alanı boş geçilemez")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Ad alanı boş geçilemez")]
        [Display(Name = "Adınız :")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad alanı boş geçilemez")]
        [Display(Name = "Soyadınız :")]
        public string Surname { get; set; }
    }
}
