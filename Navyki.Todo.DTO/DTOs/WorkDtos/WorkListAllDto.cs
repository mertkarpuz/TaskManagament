using Navyki.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navyki.Todo.DTO.DTOs.WorkDtos
{
    public class WorkListAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public Urgency Urgency { get; set; }
        public AppUser AppUser { get; set; }
        public List<Report> Reports { get; set; }
    }
}
