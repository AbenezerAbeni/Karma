﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DagusBlog.Services.Contracts
{
   public interface IService<T>
    {
        IQueryable<T> GetAll();

        T Find(object id);

        void Update(T entity);

        void Add(T entity);

        void Delete(object id);

        void SaveChanges();
    }
}
