using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Navyki.ToDo.Web.Models
{
    public class AppUserSignInModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı boş geçilemez.")]
        [Display(Name = "Kullanıcı Adı :")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Parola alanı boş geçilemez")]
        [Display(Name = "Şifre :")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Beni hatırla")]
        public bool RememberMe { get; set; }

    }
}
