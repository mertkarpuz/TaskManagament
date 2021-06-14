using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Navyki.ToDo.Web.Areas.Admin.Models
{
    public class UrgencyAddVM
    {
        [Display(Name ="Tanım")]
        [Required(ErrorMessage ="Tanım alanı boş geçilemez")]
        public string Description { get; set; }
    }
}
