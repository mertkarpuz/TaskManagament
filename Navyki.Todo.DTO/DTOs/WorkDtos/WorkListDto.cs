using System;
using System.Collections.Generic;
using System.Text;

namespace Navyki.Todo.DTO.DTOs.WorkDtos
{
    public class WorkListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }
        public DateTime CreatedTime { get; set; }
        public int UrgencyId { get; set; }
        //public Urgency Urgency { get; set; }
    }
}
