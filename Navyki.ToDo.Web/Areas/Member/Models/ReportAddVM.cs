using Navyki.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Navyki.ToDo.Web.Areas.Member.Models
{
    public class ReportAddVM
    {
        [Display(Name = "Tanım: ")]
        [Required(ErrorMessage ="Tanım alanı boş geçilemez")]
        public string Description { get; set; }
        [Display(Name = "Detay: ")]
        [Required(ErrorMessage = "Detay alanı boş geçilemez")]
        public string Detail { get; set; }
        public Work Work { get; set; }
        public int WorkId { get; set; }
    }
}
