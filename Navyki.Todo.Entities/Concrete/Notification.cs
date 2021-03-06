using Navyki.Todo.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navyki.Todo.Entities.Concrete
{
    public class Notification : ITable
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
