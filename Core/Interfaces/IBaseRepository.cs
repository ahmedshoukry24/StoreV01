﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<T> GetByIdAsync(Guid id);
        //Task<T> GetBySerial(string serial);
        //Task Save();
        Task Update(T entity);
        Task Delete(T entity);
        Task<T> Add( T entity);

    }
}
