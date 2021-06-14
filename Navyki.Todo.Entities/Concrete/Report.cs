using Navyki.Todo.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navyki.Todo.Entities.Concrete
{
    public class Report : ITable
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }

        public int WorkId { get; set; }
        public Work Work { get; set; }
    }
}
