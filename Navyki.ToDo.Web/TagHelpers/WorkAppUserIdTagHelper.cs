using Microsoft.AspNetCore.Razor.TagHelpers;
using Navyki.Todo.Business.Interfaces;
using Navyki.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Navyki.ToDo.Web.TagHelpers
{
    [HtmlTargetElement("GetWorkAppUserId")]
    public class WorkAppUserIdTagHelper : TagHelper
    {
        private readonly IWorkService _workService;
        public WorkAppUserIdTagHelper(IWorkService workService)
        {
            _workService = workService;
        }
        public int AppUserId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            List<Work> works = _workService.GetWAppUserId(AppUserId);
            int completed = works.Where(x => x.State).Count();
            int nonCompleted = works.Where(x => !x.State).Count();

            string htmlString = $"<strong> Tamamlandığı görev sayısı :</strong> {completed} <br> <strong> Üstünde çalıştığı görev sayısı: </strong> {nonCompleted}";


            output.Content.SetHtmlContent(htmlString);
        }
    }
}
