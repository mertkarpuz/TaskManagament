using Navyki.Todo.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Navyki.Todo.Entities.Concrete
{
    public class Work : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public int? AppUserId { get; set; }
        public AppUser AppUser{ get; set; }
        public Urgency Urgency { get; set; }
        public int UrgencyId { get; set; }

        public List<Report> Reports { get; set; }
    }
}
