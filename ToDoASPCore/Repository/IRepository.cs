﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoASPCore.Repository
{
    public interface IRepository<TEntity>
    {
        void Create(TEntity t);
        void Delete(int id);
        void Update(TEntity t);
        List<TEntity> GetAll();
        TEntity GetOne(int id);
    }
}
