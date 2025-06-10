﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Domain.Abstractions
{
    public interface IRepository<T> where T : class
    {
        Task<T> Update(T obj);
        Task<T> Add(T  obj);
        Task Delete(int id);
    }
}
