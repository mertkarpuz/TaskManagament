using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Navyki.ToDo.Web.Areas.Admin.Models
{
    public class WorkAddVM
    {
        [Required(ErrorMessage ="Ad alanı gereklidir")]
        public string Name { get; set; }
        
        public string Description { get; set; }
        [Range(0,int.MaxValue,ErrorMessage ="Lütfen bir aciliyet durumu seçiniz")]
        public int UrgencyId { get; set; }
    }
}
