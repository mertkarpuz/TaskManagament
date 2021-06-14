﻿using Navyki.Todo.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navyki.Todo.Business.Interfaces
{
    public interface IGenericService<Table> where Table:class,ITable,new()
    {
        void Create(Table T);
        void Delete(Table T);
        void Update(Table T);
        Table GetById(int id);
        List<Table> GetAll();
    }
}
