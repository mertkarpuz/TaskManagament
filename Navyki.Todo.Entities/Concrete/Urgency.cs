using Navyki.Todo.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navyki.Todo.Entities.Concrete
{
    public class Urgency : ITable
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public List<Work> Works{ get; set; }
    }
}
